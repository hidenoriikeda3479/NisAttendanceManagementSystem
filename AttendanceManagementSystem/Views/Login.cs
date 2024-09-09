using AttendanceManagementSystem.Common;
using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Models;
using AttendanceManagementSystem.Views;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace AttendanceManagementSystem
{
    /// <summary>
    /// ログイン画面
    /// </summary>
    public partial class Login : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        public Login(AttendanceManagementDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        /// <summary>
        /// ログインボタンクリック
        /// </summary>
        /// <param name="sender">コントロール情報</param>
        /// <param name="e">イベント情報</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //結果を取得
            bool success = TextInputCheck(employeeIdTextBox1.Text , passwordTextBox2.Text);

            //ログイン成功時、メニュー画面へ遷移
            if (success) 
            {
                var menu = new Menu(_context, int.Parse(employeeIdTextBox1.Text));
                menu.Show();
                Hide();
            }

        }

        /// <summary>
        /// 入力状態チェック
        /// </summary>
        private bool TextInputCheck(string id , string password)
        {
            //ログイン成功のフラグ
            bool success = false;

            //ID、パスワード入力チェック
            if (string.IsNullOrEmpty(id) ||
                string.IsNullOrEmpty(password))
            {
                //ボックス内容にエラーメッセージ表示
                MessageBox.Show("必須項目が未入力です");
                success = false;
                return success;
            }


            //入力されたパスワードのハッシュ化
            string hash = HashHelper.sha512(passwordTextBox2.Text);

            //IDとパスワード照合
            var searchpassword = _context.Employees.Where(n => n.EmployeeId == int.Parse(employeeIdTextBox1.Text)).Select(n => n.Password).ToList();


            //パスワード一致している場合
            if (hash == searchpassword.FirstOrDefault())
            {
                //ログイン成功
                success = true;
                return success;

            }
            else
            {
                //ボックス内容にエラーメッセージ表示
                MessageBox.Show("IDもしくはパスワードが間違っています");
                
                //ログイン失敗
                success = false;
                return success;
            };

        }

        /// <summary>
        /// ID入力制限
        /// </summary>
        /// <param name="sender">オブジェクト情報</param>
        /// <param name="e">イベント情報</param>
        private void employeeIdTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // バックスペースが押された時は有効（Deleteキーも有効）
            if (e.KeyChar == '\b')
            {
                return;
            }

            //数値0～9以外が押された時はイベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar))
            {
                e.Handled = true;
            }

        }

    }
}
