using AttendanceManagementSystem.Common;
using AttendanceManagementSystem.Data;
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
        /// ログイン登録した社員ID
        /// </summary>
        private int Id;

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
        }

        /// <summary>
        /// 入力状態チェック
        /// </summary>
        private void TextInputCheck()
        {

            //従業員名、パスワード入力チェック
            if (string.IsNullOrEmpty(employeenameTextBox1.Text) ||
                string.IsNullOrEmpty(passwordTextBox2.Text))
            {
                //ボックス内容に未入力表示
                MessageBox.Show("必須項目が未入力です");
                return;
            }

            //入力されたパスワードのハッシュ化
            string hash = HashHelper.sha512(passwordTextBox2.Text);

            //従業員名とパスワードを照合、一致する社員を取得
            var matchrecord = _context.Employees.SingleOrDefault(n => n.EmployeeName == employeenameTextBox1.Text &&
                                                                 n.Password == hash);

            //入力情報が間違っていた場合
            if (matchrecord == null)
            {
                //ボックス内容にエラー表示
                MessageBox.Show("従業員名またはパスワードが間違っています");
                return;
            }
            else
            {
                //一致した社員のIDを取得
                Id = matchrecord.EmployeeId;
            }

            //ログインした社員IDを取得して、メニュー画面へ遷移
            var menu = new Menu(_context, Id);

            menu.Show();

            Hide();

        }

    }
}
