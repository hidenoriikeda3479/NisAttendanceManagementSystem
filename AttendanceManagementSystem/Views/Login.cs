using AttendanceManagementSystem.Common;
using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Views;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace AttendanceManagementSystem
{
    /// <summary>
    /// ���O�C�����
    /// </summary>
    public partial class Login : Form
    {
        /// <summary>
        /// DB�R���e�L�X�g
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// ���O�C���o�^�����Ј�ID
        /// </summary>
        private int Id;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="context">DB�R���e�L�X�g</param>
        public Login(AttendanceManagementDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        /// <summary>
        /// ���O�C���{�^���N���b�N
        /// </summary>
        /// <param name="sender">�R���g���[�����</param>
        /// <param name="e">�C�x���g���</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //���͏�ԃ`�F�b�N
            TextInputCheck();
        }

        /// <summary>
        /// ���͏�ԃ`�F�b�N
        /// </summary>
        private void TextInputCheck()
        {

            //�]�ƈ����A�p�X���[�h���̓`�F�b�N
            if (string.IsNullOrEmpty(employeenameTextBox1.Text) ||
                string.IsNullOrEmpty(passwordTextBox2.Text))
            {
                //�{�b�N�X���e�ɖ����͕\��
                MessageBox.Show("�K�{���ڂ������͂ł�");
                return;
            }

            //���͂��ꂽ�p�X���[�h�̃n�b�V����
            string hash = HashHelper.sha512(passwordTextBox2.Text);

            //�]�ƈ����ƃp�X���[�h���ƍ��A��v����Ј����擾
            var matchrecord = _context.Employees.SingleOrDefault(n => n.EmployeeName == employeenameTextBox1.Text &&
                                                                 n.Password == hash);

            //���͏�񂪊Ԉ���Ă����ꍇ
            if (matchrecord == null)
            {
                //�{�b�N�X���e�ɃG���[�\��
                MessageBox.Show("�]�ƈ����܂��̓p�X���[�h���Ԉ���Ă��܂�");
                return;
            }
            else
            {
                //��v�����Ј���ID���擾
                Id = matchrecord.EmployeeId;
            }

            //���O�C�������Ј�ID���擾���āA���j���[��ʂ֑J��
            var menu = new Menu(_context, Id);

            menu.Show();

            Hide();

        }

    }
}
