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
        /// ログイン成功のフラグ
        /// </summary>
        private bool _success;

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
            //入力状態チェック
            TextInputCheck();

            //ログイン成功時、メニュー画面へ遷移
            if (_success) 
            {
                var menu = new Menu(_context, int.Parse(employeeIdTextBox1.Text));
                menu.Show();
                Hide();
            }


        }

        /// <summary>
        /// 入力状態チェック
        /// </summary>
        private bool TextInputCheck()
        {

            //ID、パスワード入力チェック
            if (string.IsNullOrEmpty(employeeIdTextBox1.Text) ||
                string.IsNullOrEmpty(passwordTextBox2.Text))
            {
                //ボックス内容にエラーメッセージ表示
                MessageBox.Show("必須項目が未入力です");
                _success = false;
                return _success;
            }


            //入力されたパスワードのハッシュ化
            string hash = HashHelper.sha512(passwordTextBox2.Text);

            //IDとパスワード照合
            var searchpassword = _context.Employees.Where(n => n.EmployeeId == int.Parse(employeeIdTextBox1.Text)).Select(n => n.Password).ToList();


            //パスワード一致している場合
            if (hash == searchpassword.FirstOrDefault())
            {
                //ログイン成功
                _success = true;
                return _success;

            }
            else
            {
                //ボックス内容にエラーメッセージ表示
                MessageBox.Show("IDもしくはパスワードが間違っています");
                
                //ログイン失敗
                _success = false;
                return _success;
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
