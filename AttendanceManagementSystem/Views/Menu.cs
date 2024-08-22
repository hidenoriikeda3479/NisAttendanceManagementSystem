using AttendanceManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceManagementSystem.Views
{
    public partial class Menu : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        public Menu(AttendanceManagementDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void btnShiftManagement_Click(object sender, EventArgs e)
        {

            int adminId = 1;
            var shift = new Shift(_context, adminId.ToString());
            shift.Show();
        }

        private void btnSalaryManagement_Click(object sender, EventArgs e)
        {

        }

        private void btnAttendanceManagement_Click(object sender, EventArgs e)
        {

        }

        private void btnAdminMenu_Click(object sender, EventArgs e)
        {
            var managementMenu = new ManagementMenu(_context);
            managementMenu.Show();
            Hide();
        }

        private void btnAttendanceDeparture_Click(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            int adminId = 2;
            var shift = new Shift(_context, adminId.ToString());
            shift.Show();
        }
    }
}
