using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AttendanceManagementSystem
{
    /// <summary>
    /// 従業員検索画面
    /// </summary>
    public partial class EmployeeListForm : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        public EmployeeListForm(AttendanceManagementDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeListForm_Load(object sender, EventArgs e)
        {
            // 従業員情報の表示
            GetEmployee();

            // カラムにボタン追加
            ModifyButton();

            // カラム名の変更
            SetHeaderColumn();
        }

        /// <summary>
        /// 検索ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getEmployeeButton_Click(object sender, EventArgs e)
        {
            // 従業員の検索処理
            FindEmployee();
        }

        /// <summary>
        /// 生年月日のチェックボックス処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbBirthday_CheckedChanged(object sender, EventArgs e)
        {
            // 生年月日チェックボックス表示確認
            CheckedBirthday();
        }

        /// <summary>
        /// 従業員登録ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            // 従業員登録画面
            ShowEmployeeEntryForm();
        }

        /// <summary>
        /// フォームロード時に従業員のデータを表示
        /// </summary>
        private void GetEmployee()
        {
            // 従業員のデータを表示かつ、部署IDを部署名へ設定、権限IDを権限名へ設定、時給IDを時給名へ設定
            dgvEmployees.DataSource = _context.Employees
             .Join(_context.department,
                  emp => emp.DepartmentId,
                  dept => dept.DepartmentId,
                  (emp, dept) => new { emp, dept })
             .Join(_context.Permissions,
                  tmp => tmp.emp.PermissionId,
                  per => per.PermissionId,
                  (tmp, per) => new { tmp.emp, tmp.dept, per })
             .Join(_context.Ranks,
                  tmp => tmp.emp.RankId,
                  rnk => rnk.RankId,
                  (tmp, rnk) => new
                  {
                      tmp.emp.EmployeeId,       // 従業員ID
                      tmp.emp.EmployeeName,     // 従業員名
                      tmp.emp.Gender,　　　　　 // 性別
                      tmp.emp.Password,         // パスワード
                      tmp.emp.PhoneNumber,      // 電話番号
                      tmp.emp.PostCode,         // 郵便番号
                      tmp.emp.Address,          // 住所
                      tmp.emp.BuildingName,     // 建物名
                      tmp.emp.BirthDate,        // 生年月日
                      tmp.dept.DepartmentName,  // 部署
                      rnk.HourlyPay,            // 時給
                      tmp.emp.HireDate,         // 入社日
                      tmp.emp.ResignDate,       // 退社日
                      tmp.per.PermissionName,   // 権限
                      tmp.emp.CreatedAt,        // 作成日時
                      tmp.emp.UpdatedAt,        // 更新日
                  })
             .ToList();
        }

        /// <summary>
        /// 従業員情報の検索画面
        /// </summary>
        private void FindEmployee()
        {
            // 検索クエリの初期化
            var queryDelete = _context.Employees
                .Join(_context.department,
                      emp => emp.DepartmentId,
                      dept => dept.DepartmentId,
                      (emp, dept) => new { emp, dept })
                .Join(_context.Permissions,
                      tmp => tmp.emp.PermissionId,
                      per => per.PermissionId,
                      (tmp, per) => new { tmp.emp, tmp.dept, per })
                .Join(_context.Ranks,
                      tmp => tmp.emp.RankId,
                      rnk => rnk.RankId,
                      (tmp, rnk) => new
                      {
                          tmp.emp.EmployeeId,       // 従業員ID
                          tmp.emp.EmployeeName,     // 従業員名
                          tmp.emp.Gender,           // 性別
                          tmp.emp.Password,         // パスワード
                          tmp.emp.PhoneNumber,      // 電話番号
                          tmp.emp.PostCode,         // 郵便番号
                          tmp.emp.Address,          // 住所
                          tmp.emp.BuildingName,     // 建物名
                          tmp.emp.BirthDate,        // 生年月日
                          tmp.dept.DepartmentName,  // 部署
                          rnk.HourlyPay,            // 時給
                          tmp.emp.HireDate,         // 入社日
                          tmp.emp.ResignDate,       // 退社日
                          tmp.per.PermissionName,   // 権限
                          tmp.emp.CreatedAt,        // 作成日時
                          tmp.emp.UpdatedAt,        // 更新日
                      })
                .AsQueryable();

            // 従業員名でフィルタリング
            if (!string.IsNullOrEmpty(txtSearchEmployeeName.Text))
            {
                queryDelete = queryDelete.Where(a => a.EmployeeName.Contains(txtSearchEmployeeName.Text));
            }

            // 生年月日でフィルタリング
            if (chbBirthday.Checked)
            {
                queryDelete = queryDelete.Where(b => b.BirthDate.Date == dtpSearchBirthDate.Value.Date);
            }

            // 電話番号でフィルタリング
            if (!string.IsNullOrEmpty(txtSearchContactNumber.Text))
            {
                queryDelete = queryDelete.Where(c => c.PhoneNumber == txtSearchContactNumber.Text);
            }

            // フィルタリングデータを表示
            dgvEmployees.DataSource = queryDelete.ToList();
        }

        /// <summary>
        /// 生年月日入力チェックボックスの変更処理
        /// </summary>
        private void CheckedBirthday()
        {
            // 誕生日チェックボックスがチェックの時
            dtpSearchBirthDate.Enabled = chbBirthday.Checked;
        }

        /// <summary>
        /// データグリップビューにあるボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView btnClick = (DataGridView)sender;

            // 編集ボタンがクリックされた場合
            if (btnClick.Columns[e.ColumnIndex].Name == "editButton")
            {
                // 編集ボタンを押した行からデータを取得し画面遷移先に受け渡す
                int employeeId = (int)dgvEmployees.Rows[e.RowIndex].Cells["EmployeeId"].Value;
                UpdateEmployeeForm updateEmployee = new UpdateEmployeeForm(_context, employeeId);
                updateEmployee.Show();
            }

            // 削除ボタンがクリックされた場合
            if (btnClick.Columns[e.ColumnIndex].Name == "deleteButton")
            {
                // 選択された従業員のIDを取得
                int employeeId = (int)dgvEmployees.Rows[e.RowIndex].Cells["EmployeeId"].Value;

                // IDで従業員を検索
                var upEmployee = _context.Employees.Single(a => a.EmployeeId == employeeId);

                // 選択行を削除
                _context.Employees.Remove(upEmployee);

                // 削除したデータをコミット
                _context.SaveChanges();

                // データグリッドを更新して通知
                MessageBox.Show("削除されました。");

                // データグリッド再取得
                GetEmployee();
            }
        }

        /// <summary>
        /// カラムに編集ボタンの追加
        /// </summary>
        private void ModifyButton()
        {
            // DataGridViewButtonColumnの作成
            // 編集ボタン
            DataGridViewButtonColumn Update1 = new DataGridViewButtonColumn();
            Update1.Name = "editButton";

            // 全てのボタンに「編集」と表示
            Update1.UseColumnTextForButtonValue = true;
            Update1.Text = "編集";

            // DataGridViewに追加
            dgvEmployees.Columns.Add(Update1);

            // 削除ボタン
            DataGridViewButtonColumn Update2 = new DataGridViewButtonColumn();
            Update2.Name = "deleteButton";

            // 全てのボタンに「削除」と表示
            Update2.UseColumnTextForButtonValue = true;
            Update2.Text = "削除";

            // DataGridViewに追加
            dgvEmployees.Columns.Add(Update2);

            // すべての列の幅を自動で調整する
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// 従業員登録画面へ画面遷移
        /// </summary>
        private void ShowEmployeeEntryForm()
        {
            // 従業員の登録フォームへ画面遷移
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm(_context);
            addEmployeeForm.Show();
        }

        /// <summary>
        /// 従業員のカラム名の変更
        /// </summary>
        private void SetHeaderColumn()
        {
            // カラムの表示名の変更
            dgvEmployees.Columns["EmployeeId"].HeaderText = "ID";

            dgvEmployees.Columns["EmployeeName"].HeaderText = "従業員名";

            dgvEmployees.Columns["Gender"].HeaderText = "性別";

            dgvEmployees.Columns["Password"].HeaderText = "パスワード";

            dgvEmployees.Columns["PhoneNumber"].HeaderText = "電話番号";

            dgvEmployees.Columns["PostCode"].HeaderText = "郵便番号";

            dgvEmployees.Columns["Address"].HeaderText = "住所";

            dgvEmployees.Columns["BuildingName"].HeaderText = "建物名";

            dgvEmployees.Columns["BirthDate"].HeaderText = "生年月日";

            dgvEmployees.Columns["DepartmentName"].HeaderText = "部署";

            dgvEmployees.Columns["HourlyPay"].HeaderText = "時給";

            dgvEmployees.Columns["HireDate"].HeaderText = "入社日";

            dgvEmployees.Columns["ResignDate"].HeaderText = "退社日";

            dgvEmployees.Columns["PermissionName"].HeaderText = "権限";

            dgvEmployees.Columns["CreatedAt"].HeaderText = "作成日";

            dgvEmployees.Columns["UpdatedAt"].HeaderText = "更新日";

            dgvEmployees.Columns["editButton"].HeaderText = "編集";

            dgvEmployees.Columns["deleteButton"].HeaderText = "削除";
        }
    }
}

    
    


