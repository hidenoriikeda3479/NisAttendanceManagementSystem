using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Views;
using System.Windows.Forms;

namespace AttendanceManagementSystem
{
    public partial class Login : Form
    {
        /// <summary>
        /// DB�R���e�L�X�g
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="context">DB�R���e�L�X�g</param>
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
