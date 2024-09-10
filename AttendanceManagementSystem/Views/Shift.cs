using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace AttendanceManagementSystem.Views
{
    /// <summary>
    /// シフト画面
    /// </summary>
    public partial class Shift : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// 権限IDのグローバル変数
        /// </summary>
        private int _adminId;

        /// <summary>
        /// 現在の年月日を取得
        /// </summary>
        private DateTime _nowTarget = DateTime.Now;

        /// <summary>
        /// シフト画面の表示
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        public Shift(AttendanceManagementDbContext context, int adminId)
        {
            InitializeComponent();

            _context = context;
            _adminId = adminId;

            // カラム数を動的にする
            shiftDataGridView.AutoGenerateColumns = false;

            // 初期表示時にヘッダーに今現在の年月日を表示
            TargetMonth();

            // 社員の名前とシフトを表示
            DisprayShift();
        }

        #region ボタンイベント

        /// <summary>
        /// 先月/来月ボタンクリックイベント
        /// </summary>
        /// <param name="sender">コントロール情報</param>
        /// <param name="e">イベント情報</param>
        private void btnChangeMonth_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int n = 0;
            if(btn.Name == "btnNextMonth")
            {
                n++;
            }
            else
            {
                n--;
            }

            // 現在表示している月よりnの分変更して年月日をヘッダーに表示
            TargetMonth(n);

            // 社員の名前とシフトを表示
            DisprayShift();
        }
        
        #endregion

        #region データグリッドビューの処理

        /// <summary>
        /// DateGridViewのヘッダーに対象年月日を表示
        /// </summary>
        private void TargetMonth(int monthFlg = 0)
        {
            // データグリッドビューの中身をクリア
            shiftDataGridView.Columns.Clear();

            // 来月、先月ボタンを押した際月が切り替わるようにする
            _nowTarget = _nowTarget.AddMonths(monthFlg);

            int year = _nowTarget.Year;
            int month = _nowTarget.Month;

            // 対象の月が何日あるのか取得
            int days = DateTime.DaysInMonth(_nowTarget.Year, _nowTarget.Month);

            // ヘッダーの最初に年月を表示
            DataGridViewTextBoxColumn headColumn = new DataGridViewTextBoxColumn();
            headColumn.DataPropertyName = String.Format("column{0}", 0);
            headColumn.Name = String.Format("column{0}", 0);
            headColumn.HeaderText = String.Format("{0}年{1}月", year, month);
            shiftDataGridView.Columns.Add(headColumn);

            // 日数分ヘッダーに列を追加
            foreach (var i in Enumerable.Range(1, days + 1))
            {
                DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
                textColumn.DataPropertyName = String.Format("column{0}", i);
                textColumn.Name = String.Format("column{0}", i);
                textColumn.HeaderText = String.Format("{0}日", i);
                shiftDataGridView.Columns.Add(textColumn);
            }
        }

        /// <summary>
        /// シフト登録イベント
        /// </summary>
        /// <param name="sender">コントロール情報</param>
        /// <param name="e">イベント情報</param>
        private void shiftDaraGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 現在の日付を取得
            DateTime today = DateTime.Now;

            // 管理者権限の場合の処理
            if (e.ColumnIndex >= 1 && e.RowIndex >= 0 && _adminId == 1 && 
               (today.ToString("yyyy/MM/dd") == _nowTarget.ToString("yyyy/MM/dd") && today.Day <= e.ColumnIndex || today < _nowTarget))
            {
                var color = shiftDataGridView[e.ColumnIndex, e.RowIndex].Style;
                int targetRow = e.RowIndex;
                int targetColumn = e.ColumnIndex;
                int dayCount = DateTime.DaysInMonth(_nowTarget.Year, _nowTarget.Month) + 1;
                int targetCell = int.Parse(shiftDataGridView[dayCount, targetRow].Value.ToString());

                // 社員テーブルにシフトテーブルを結合してシフト名を取得
                var result = _context.Employees.Join(_context.Shifts,
                                                       n => n.ShiftId,
                                                       s => s.ShiftId,
                                                       (emp, sft) => new
                                                       {
                                                           empId = emp.EmployeeId,
                                                           sftSftName = sft.ShiftTypeName
                                                       }).Where(n => n.empId == targetCell).Select(
                                                        n => n.sftSftName).ToList();

                // 取得したシフト名をリスト型から文字列に直す
                string shiftType = result.First();

                if (color.BackColor == Color.Empty) // 対象日付にシフトが登録されていない場合
                {
                    // セルの背景色を変更
                    color.BackColor = ChangeColor(shiftType, color);

                    // シフト登録(INSERT)
                    var newShiftManagement = new ShiftManagementModel
                    {
                        EmployeeId = targetCell,
                        Year = _nowTarget.Year,
                        Month = _nowTarget.Month,
                        Day = targetColumn,
                        CreatedAt = DateTime.Now,
                    };

                    // 新しい従業員データを追加
                    _context.ShiftManagements.Add(newShiftManagement);
                }
                else // 対象日付にシフトが既に登録されている場合
                {
                    // セルの背景色を初期状態に変更
                    color.BackColor = Color.Empty;

                    // シフト削除対象のデータを取得
                    var targetRecord = _context.ShiftManagements
                                       .Single(n => n.EmployeeId == targetCell &&
                                                    n.Year == _nowTarget.Year &&
                                                    n.Month == _nowTarget.Month &&
                                                    n.Day == targetColumn);

                    // 取得データを削除
                    _context.ShiftManagements.Remove(targetRecord);
                }

                // 追加したデータをコミット
                _context.SaveChanges();
            }

            // 選択している状態の背景色を対象の色に合わせる
            shiftDataGridView.ClearSelection();
        }

        /// <summary>
        /// 社員名、出勤予定日を表示
        /// </summary>
        private void DisprayShift()
        {
            // 社員テーブル、シフト管理テーブル、シフトテーブルを結合して対象月のシフト情報を取得
            var result = _context.Employees.Where(n => (n.HireDate.Year <= _nowTarget.Year && n.HireDate.Month <= _nowTarget.Month) &&
                                           (!n.ResignDate.HasValue || (n.ResignDate.Value.Year >= _nowTarget.Year && n.ResignDate.Value.Month >= _nowTarget.Month)))
                                           .GroupJoin(_context.ShiftManagements
                                           .Where(n => n.Year == _nowTarget.Year && n.Month == _nowTarget.Month), // 対象月分のシフトだけ取得
                                           em => em.EmployeeId,
                                           s => s.EmployeeId,
                                           (Emp, Sft) => new
                                           {
                                               EmpID = Emp.EmployeeId, // 社員ID
                                               EmpNm = Emp.EmployeeName, // 社員名
                                               EmpSftId = Emp.ShiftId, // シフトID
                                               SftMg = Sft // シフト管理テーブル情報
                                           }).Join(_context.Shifts,
                                               em => em.EmpSftId,
                                               s => s.ShiftId,
                                               (empSft, sSft) => new
                                               {
                                                   EmpSft = empSft, // 結合したテーブル情報
                                                   SftTypeName = sSft.ShiftTypeName // シフト名
                                               }).ToList();
            // 取得した情報分行を追加
            int namecount = result.Count;
            shiftDataGridView.RowCount = namecount;

            // 社員IDを保持するために日数+1の列を作成
            int dayCount = DateTime.DaysInMonth(_nowTarget.Year, _nowTarget.Month) + 1;
            int i = 0;

            // データグリッドビューにデータ表示
            foreach (var name in result)
            {
                // 社員名を左の列に追加
                shiftDataGridView[0, i].Value = name.EmpSft.EmpNm;
                string typeName = name.SftTypeName;
                shiftDataGridView[dayCount, i].Value = name.EmpSft.EmpID;

                // 登録されているシフトを表示
                foreach (var workDate in name.EmpSft.SftMg)
                {
                    // シフトの色を変更するための入れ子
                    var shiftColor = shiftDataGridView[workDate.Day, i].Style;

                    // セルの背景色をシフトに対応した色に変更
                    shiftColor.BackColor = ChangeColor(typeName, shiftColor);
                }
                i++;
            }

            // データグリッドビューの最後の列を非表示
            shiftDataGridView.Columns[dayCount].Visible = false;

            // shiftDataGridView の すべてのカラムで ソート を 無効化
            foreach (DataGridViewColumn column in this.shiftDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        /// <summary>
        /// シフトごとの色分け処理
        /// </summary>
        /// <param name="typeName">シフトの種類</param>
        /// <param name="color">セルの背景色</param>
        private Color ChangeColor(string typeName, DataGridViewCellStyle color)
        {
            switch (typeName)
            {
                // 早番なら黄色
                case "Morning":
                    return Color.Yellow;

                // 中番なら青色
                case "Noon":
                    return Color.DodgerBlue;

                // 遅番なら緑色
                case "Evening":
                    return Color.ForestGreen;

                // デフォルト
                default:
                    return Color.Empty;
            }
        }
        #endregion

        
    }
}
