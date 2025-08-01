using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using static System.Net.Mime.MediaTypeNames;

namespace AttendanceManagementSystem.Views
{
    /// <summary>
    /// シフト管理一覧画面
    /// </summary>
    public partial class ShiftManagementListForm : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// バインディングソース
        /// </summary>
        private BindingSource _bindingSource = new BindingSource();

        /// <summary>
        /// シフトマスタ一覧（shiftTypes）
        /// </summary>
        private List<ShiftModel> shiftTypes = new List<ShiftModel>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        public ShiftManagementListForm(AttendanceManagementDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShiftManagementListForm_Load(object sender, EventArgs e)
        {
            // 今月の日数を取得
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            // 指定した年月の、月の日数を取得する（例：30や31）
            int daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);

            // Employeesテーブルから全従業員の情報を取得
            var employees = _context.Employees.ToList();

            // シフトテーブルからシフトの詳細データを取得
            // 各従業員がいつどのシフトだったかという情報
            var shiftDetails = _context.Set<ShiftManagementModel>().ToList(); // 日付ごとのシフト

            // シフトテーブルから全シフトの情報を取得
            var shifts = _context.Shifts.ToList();

            //  新しいDataTableを作成（シフト表を格納）
            var dt = new DataTable();

            // 従業員ID（数値）の列を追加
            dt.Columns.Add("EmployeeId", typeof(int));

            // 従業員名（文字列）の列を追加
            dt.Columns.Add("EmployeeName", typeof(string));

            // 日付ごとの列をDataTableに追加（例：06/01, 06/02, ...）
            for (int d = 0; d < daysInMonth; d++)
            {
                dt.Columns.Add(startDate.AddDays(d).ToString("MM/dd"), typeof(string));
            }

            // 各従業員ごとに1行ずつ作成
            foreach (var emp in employees)
            {
                // 新しい行（DataRow）を作成
                var row = dt.NewRow();

                // 従業員IDと名前を設定
                row["EmployeeId"] = emp.EmployeeId;
                row["EmployeeName"] = emp.EmployeeName;

                // 各日付ごとにシフトを確認
                for (int d = 0; d < daysInMonth; d++)
                {
                    var date = startDate.AddDays(d);

                    // その従業員のその日付のシフト情報を取得
                    var shiftRecord = shiftDetails.FirstOrDefault(s => s.EmployeeId == emp.EmployeeId && s.Year == date.Year && s.Month == date.Month && s.Day == date.Day);

                    if (shiftRecord != null)
                    {
                        // ShiftIdに対応するシフト名（例：「日勤」「夜勤」など）を取得
                        var shiftType = shifts.FirstOrDefault(s => s.ShiftId == shiftRecord.Year && s.ShiftId == shiftRecord.Month && s.ShiftId == shiftRecord.Day)?.ShiftTypeName ?? "不明";

                        // シフト名を行に設定。見つからなければ「不明」 
                        row[date.ToString("MM/dd")] = shiftType;
                    }

                    else
                    {
                        // シフトが登録されていなければ「-」にする
                        row[date.ToString("MM/dd")] = "-";
                    }
                }
                // 完成した行をDataTableに追加
                dt.Rows.Add(row);
            }

            // DataGridViewにデータを表示する
            dgvShift.DataSource = dt;

            // DataGridViewButtonColumnの作成
            DataGridViewButtonColumn Update1 = new DataGridViewButtonColumn();
            Update1.Name = "SaveButton";

            // 全てのボタンに「編集」と表示
            Update1.UseColumnTextForButtonValue = true;
            Update1.Text = "保存";

            // DataGridViewに追加
            dgvShift.Columns.Add(Update1);

            // カラムの表示名の変更
            dgvShift.Columns["EmployeeId"].HeaderText = "ID";

            dgvShift.Columns["EmployeeName"].HeaderText = "従業員名";

            // すべての列の幅を自動で調整する
            dgvShift.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// データグリップビュー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvShift_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 「保存」ボタンの列がクリックされたかつ、行インデックスが有効な場合のみ処理を実行
            if (e.ColumnIndex == dgvShift.Columns["SaveButton"].Index && e.RowIndex >= 0)
            {
                // 「SaveButton」列のセルがクリックされた、かつ行インデックスが有効なとき
                if (e.ColumnIndex == dgvShift.Columns["SaveButton"].Index && e.RowIndex >= 0)
                {
                    // 対象の従業員名を取得
                    var employeeName = dgvShift.Rows[e.RowIndex].Cells["EmployeeName"].Value.ToString();

                    // シフトIDからシフト名に変換して保持するリスト
                    List<string> shifts = new List<string>();

                    // 最初の3列（仮に 1～3 が日付列 or シフト列だと想定）を対象
                    //（私用めも：1～3を一か月分に設定する（例：30と31日分）（※以下の変更が必要？））
                    for (int i = 1; i <= 3; i++)
                    {
                        // セルの値（ShiftId）を取得
                        var shiftId = dgvShift.Rows[e.RowIndex].Cells[i].Value;

                        // ShiftId に対応するシフト名を取得（なければ「未設定」）
                        var shiftName = shiftTypes.FirstOrDefault(s => s.ShiftId.Equals(shiftId))?.ShiftTypeName ?? "未設定";

                        // シフト名をリストに追加
                        shifts.Add(shiftName);
                    }
                    // 結果をメッセージボックスで表示
                    MessageBox.Show($"{employeeName} さんのシフト:\n{string.Join(" / ", shifts)}", "保存内容確認");
                }
            }
        }
    }
}
