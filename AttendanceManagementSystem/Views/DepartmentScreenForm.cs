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

namespace AttendanceManagementSystem.Views
{
    /// <summary>
    /// 部署登録画面
    /// </summary>
    public partial class DepartmentScreenForm : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        public DepartmentScreenForm(AttendanceManagementDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        /// <summary>
        /// 部署登録ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegisterDepartment_Click(object sender, EventArgs e)
        {
            // 空白のチェック
            if (!CheckDepartment())
            {
                // 空白がある場合、処理を停止
                return;
            }

            // 新規部署登録
            RegisterDepartment();
        }

        /// <summary>
        /// 部署名の編集をする処理と作成日の適用処理
        /// </summary>
        private void RegisterDepartment()
        {
            // 新しい部署データの作成
            var newDepartmentData = new DepartmentModel
            {
                DepartmentName = txtRegisterDepartment.Text,    // 部署名
                CreatedAt = DateTime.Now,                       // 作成日
            };

            // 新しい部署データを追加
            _context.department.Add(newDepartmentData);

            // 追加したデータをコミット
            _context.SaveChanges();

            // データグリッドを更新して通知
            MessageBox.Show("新しい部署名が追加されました。");

            // 部署登録画面を閉じる
            this.Close();
        }

        /// <summary>
        /// テキストボックスが空白の場合
        /// </summary>
        /// <returns></returns>
        private bool CheckDepartment()
        {
            if (string.IsNullOrEmpty(txtRegisterDepartment.Text))
            {
                MessageBox.Show("部署名の入力がありません。記載してください");
                return false;
            }
            return true;
        }
    }
}
