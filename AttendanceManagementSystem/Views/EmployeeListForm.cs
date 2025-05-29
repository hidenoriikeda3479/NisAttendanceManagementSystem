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
            // 従業員のデータを表示
            dgvEmployees.DataSource = _context.Employees.ToList();
        }

        /// <summary>
        /// 従業員情報の検索画面
        /// </summary>
        private void FindEmployee()
        {
            // 検索クエリの初期化
            var queryClear = _context.Employees.AsQueryable();

            // 従業員名でフィルタリング
            if (!string.IsNullOrEmpty(txtSearchEmployeeName.Text))
            {
                queryClear = queryClear.Where(a => a.EmployeeName.Contains(txtSearchEmployeeName.Text));
            }

            // 生年月日でフィルタリング
            if (chbBirthday.Checked)
            {
                queryClear = queryClear.Where(b => b.BirthDate.Date == dtpSearchBirthDate.Value.Date);
            }

            // 電話番号でフィルタリング
            if (!string.IsNullOrEmpty(txtSearchContactNumber.Text))
            {
                queryClear = queryClear.Where(c => c.PhoneNumber == txtSearchContactNumber.Text);
            }

            // フィルタリングデータを表示
            dgvEmployees.DataSource = queryClear.ToList();
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
            if (btnClick.Columns[e.ColumnIndex].Name == "clearButton")
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
                dgvEmployees.DataSource = _context.Employees.ToList();
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
            Update2.Name = "clearButton";

            // 全てのボタンに「削除」と表示
            Update2.UseColumnTextForButtonValue = true;
            Update2.Text = "削除";

            // DataGridViewに追加
            dgvEmployees.Columns.Add(Update2);
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
            var cgId = dgvEmployees.Columns["EmployeeId"];
            cgId.HeaderText = "ID";

            var cgName = dgvEmployees.Columns["EmployeeName"];
            cgName.HeaderText = "従業員名";

            var cgGender = dgvEmployees.Columns["Gender"];
            cgGender.HeaderText = "性別";

            var cgPassword = dgvEmployees.Columns["Password"];
            cgPassword.HeaderText = "パスワード";

            var cgPhoneNumber = dgvEmployees.Columns["PhoneNumber"];
            cgPhoneNumber.HeaderText = "電話番号";

            var cgPostCode = dgvEmployees.Columns["PostCode"];
            cgPostCode.HeaderText = "郵便番号";

            var cgAddress = dgvEmployees.Columns["Address"];
            cgAddress.HeaderText = "住所";

            var cgBuildingName = dgvEmployees.Columns["BuildingName"];
            cgBuildingName.HeaderText = "建物名";

            var cgBirthDate = dgvEmployees.Columns["BirthDate"];
            cgBirthDate.HeaderText = "生年月日";

            var cgDepartmentId = dgvEmployees.Columns["DepartmentId"];
            cgDepartmentId.HeaderText = "部署ID";

            var cgRankId = dgvEmployees.Columns["RankId"];
            cgRankId.HeaderText = "ランク情報";

            var cgShiftId = dgvEmployees.Columns["ShiftId"];
            cgShiftId.HeaderText = "シフト情報";

            var cgHireDate = dgvEmployees.Columns["HireDate"];
            cgHireDate.HeaderText = "入社日";

            var cgResignDate = dgvEmployees.Columns["ResignDate"];
            cgResignDate.HeaderText = "退社日";

            var cgPermissionId = dgvEmployees.Columns["PermissionId"];
            cgPermissionId.HeaderText = "権限";

            var cgDepartment = dgvEmployees.Columns["CreatedAt"];
            cgDepartment.HeaderText = "作成日";

            var cgTitle = dgvEmployees.Columns["UpdatedAt"];
            cgTitle.HeaderText = "更新日";

            var cgEditButton = dgvEmployees.Columns["editButton"];
            cgEditButton.HeaderText = "編集";

            var cgClearButton = dgvEmployees.Columns["clearButton"];
            cgClearButton.HeaderText = "削除";
        }
    }
}

    
    


