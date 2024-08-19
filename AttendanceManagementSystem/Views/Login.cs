using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Views;
using System.Windows.Forms;

namespace AttendanceManagementSystem
{
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

        private void button1_Click(object sender, EventArgs e)
        {
            var menu = new Menu();
            menu.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sample = new Sample(_context);
            sample.Show();
            Hide();
        }
    }
}
