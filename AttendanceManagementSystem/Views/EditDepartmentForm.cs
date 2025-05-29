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

namespace AttendanceManagementSystem.Views
{
    /// <summary>
    /// 部署編集画面
    /// </summary>
    public partial class EditDepartmentForm : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// 部署ID
        /// </summary>
        int departmentId;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        /// <param name="department">部署ID</param>
        public EditDepartmentForm(AttendanceManagementDbContext context, int department)
        {
            InitializeComponent();
            _context = context;
            departmentId = department;
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditDepartmentForm_Load(object sender, EventArgs e)
        {
            // 取得データ表示
            ShowDepartment();
        }

        /// <summary>
        /// 部署の編集ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditDepartment_Click(object sender, EventArgs e)
        {
            // 空白のチェック
            if (!CheckDepartment())
            {
                // 空白がある場合、処理を停止
                return;
            }

            // 部署名の編集をする処理
            EditDepartment();
        }

        /// <summary>
        /// 部署名の編集をする処理と更新日の適用処理
        /// </summary>
        private void EditDepartment()
        {
            // IDで部署を検索
            var department = _context.department.Single(a => a.DepartmentId == departmentId);

            // 部署情報の更新
            department.DepartmentName = txtEditingDepartment.Text; // 部署名
            department.UpdatedAt = DateTime.Now;                   // 更新日

            // 追加したデータをコミット
            _context.SaveChanges();

            // データグリッドを更新して通知
            MessageBox.Show("部署名が変更されました。");

            // 部署編集画面を閉じる
            this.Close();
        }

        /// <summary>
        /// 部署の取得データ表示処理
        /// </summary>
        private void ShowDepartment()
        {
            var department = _context.department.Single(a => a.DepartmentId == departmentId);
            txtEditingDepartment.Text = department.DepartmentName;
        }

        /// <summary>
        /// 部署入力チェック処理
        /// </summary>
        private bool CheckDepartment()
        {
            // 部署名のテキストボックスが空白の場合
            if (string.IsNullOrEmpty(txtEditingDepartment.Text))
            {
                MessageBox.Show("部署名の入力がありません。記載してください");
                return false;
            }
            return true;
        }
    }
}
