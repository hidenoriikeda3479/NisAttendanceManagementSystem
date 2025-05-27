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

namespace AttendanceManagementSystem
{
    /// <summary>
    /// 従業員登録画面
    /// </summary>
    public partial class AddEmployeeForm : Form
    {
        // <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AddEmployeeForm(AttendanceManagementDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        /// <summary>
        /// 登録ボタン押下処理
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

            // 従業員登録
            RegisterEmployee();
        }

        /// <summary>
        /// 従業員登録情報の登録
        /// </summary>
        private void RegisterEmployee()
        {
            // 新しい従業員データの作成
            var newEmployeeData = new EmployeeModel
            {
                EmployeeName = txtEmployeeName.Text,        // 従業員名
                Gender = cbGender.SelectedIndex,            // 性別
                PhoneNumber = txtSearchContactNumber.Text,  // 電話番号
                Password = txbPass.Text,                    // パスワード
                PostCode = txtPhoneNumber.Text,             // 郵便番号
                Address = txtMailingAddress.Text,           // 住所
                BuildingName = txtBuildingName.Text,        // 建物名
                BirthDate = dtpSearchBirthDate.Value,       // 生年月日
                CreatedAt = DateTime.Now,                   // 作成日
            };

            // 新しい従業員データを追加
            _context.Employees.Add(newEmployeeData);

            // 追加したデータをコミット
            _context.SaveChanges();

            // データグリッドを更新して通知
            MessageBox.Show("新しい従業員が追加されました。");

            // 従業員登録画面を閉じる
            this.Close();
        }

        /// <summary>
        /// テキストボックスが空白の場合
        /// </summary>
        private bool CheckEmployee()
        {
            // 従業員名が未入力の場合
            if (!string.IsNullOrEmpty(txtEmployeeName.Text))
            {
                MessageBox.Show("従業員名のの入力がありません。記載してください");
                return false;
            }

            // 性別が未入力の場合
            if (!string.IsNullOrEmpty(cbGender.Text))
            {
                MessageBox.Show("性別の入力がありません。記載してください");
                return false;
            }

            // パスワードが未入力の場合
            if (!string.IsNullOrEmpty(txbPass.Text))
            {
                MessageBox.Show("パスワードを選択してください");
                return false;
            }

            // 電話番号が未入力の場合
            if (!string.IsNullOrEmpty(txtSearchContactNumber.Text))
            {
                MessageBox.Show("電話番号を選択してください");
                return false;
            }

            // 郵便番号が未入力の場合
            if (!string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                MessageBox.Show("郵便番号を選択してください");
                return false;
            }

            // 住所が未入力の場合
            if (!string.IsNullOrEmpty(txtMailingAddress.Text))
            {
                MessageBox.Show("住所を選択してください");
                return false;
            }

            // 建物名が未入力の場合
            if (!string.IsNullOrEmpty(txtBuildingName.Text))
            {
                MessageBox.Show("建物名を選択してください");
                return false;
            }
            return true;
        }
    }
}
