using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AttendanceManagementSystem
{
    /// <summary>
    /// 従業員編集画面
    /// </summary>
    public partial class UpdateEmployeeForm : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// 従業員ID
        /// </summary>
        int employeeId;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        /// <param name="employee">従業員ID</param>
        public UpdateEmployeeForm(AttendanceManagementDbContext context , int employee)
        {
            InitializeComponent();
            _context = context;
            employeeId = employee;
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateEmployeeForm_Load(object sender, EventArgs e)
        {
            // 取得の表示設定
            GetEmployee();
        }

        /// <summary>
        /// 編集ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // 空白のチェック
            if (!CheckEmployee())
            {
                // 空白がある場合、処理を停止
                return;
            }

            // アップデート
            EditEmployee();
        }

        /// <summary>
        /// テキストボックスが空白の場合
        /// </summary>
        private bool CheckEmployee()
        {
            // 従業員名が未入力の場合
            if (string.IsNullOrEmpty(txtEmployeeName.Text))
                {
                MessageBox.Show("従業員名のの入力がありません。記載してください");
                return false;
            }

            // 性別が未入力の場合
            if (string.IsNullOrEmpty(cbGender.Text))
            {
                MessageBox.Show("性別の入力がありません。記載してください");
                return false;
            }

            // パスワードが未入力の場合
            if (string.IsNullOrEmpty(txbPass.Text))
            {
                MessageBox.Show("パスワードを選択してください");
                return false;
            }

            // 電話番号が未入力の場合
            if (string.IsNullOrEmpty(txtSearchContactNumber.Text))
            {
                MessageBox.Show("電話番号を選択してください");
                return false;
            }

            // 郵便番号が未入力の場合
            if (string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                MessageBox.Show("郵便番号を選択してください");
                return false;
            }

            // 住所が未入力の場合
            if (string.IsNullOrEmpty(txtMailingAddress.Text))
            {
                MessageBox.Show("住所を選択してください");
                return false;
            }

            // 建物名が未入力の場合
            if (string.IsNullOrEmpty(txtBuildingName.Text))
            {
                MessageBox.Show("建物名を選択してください");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 従業員の取得値の表示
        /// </summary>
        private void GetEmployee()
        {
            var employee = _context.Employees.Single(a => a.EmployeeId == employeeId);

            txtEmployeeName.Text = employee.EmployeeName;        // 従業員名
            cbGender.SelectedIndex = employee.Gender;            // 性別
            txtSearchContactNumber.Text = employee.PhoneNumber;  // 電話番号
            txbPass.Text = employee.Password;                    //パスワード
            txtPhoneNumber.Text = employee.PostCode;             // 郵便番号
            txtMailingAddress.Text = employee.Address;           // 住所
            txtBuildingName.Text = employee.BuildingName;        // 建物名
            dtpSearchBirthDate.Value = employee.BirthDate;       // 生年月日
        }

        /// <summary>
        /// 従業員の編集処理
        /// </summary>
        private void EditEmployee()
        {
            // IDで従業員を検索
            var employee = _context.Employees.Single(a => a.EmployeeId == employeeId);

            // 従業員情報を固定値で更新
            employee.EmployeeName = txtEmployeeName.Text;        // 従業員名
            employee.Gender = cbGender.SelectedIndex;            // 性別
            employee.PhoneNumber = txtSearchContactNumber.Text;  // 電話番号
            employee.Password = txbPass.Text;                    //パスワード
            employee.PostCode = txtPhoneNumber.Text;             // 郵便番号
            employee.Address = txtMailingAddress.Text;           // 住所
            employee.BuildingName = txtBuildingName.Text;        // 建物名
            employee.BirthDate = dtpSearchBirthDate.Value;       // 生年月日
            employee.UpdatedAt = DateTime.Now;                   // 更新日

            // 追加したデータをコミット
            _context.SaveChanges();

            // データグリッドを更新して通知
            MessageBox.Show("従業員情報が更新されました。");

            // 従業員編集画面を閉じる
            this.Close();
        }
    }
}
