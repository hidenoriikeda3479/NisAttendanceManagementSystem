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
        public Menu()
        {
            InitializeComponent();
        }

        private void btnShiftManagement_Click(object sender, EventArgs e)
        {

        }

        private void btnSalaryManagement_Click(object sender, EventArgs e)
        {

        }

        private void btnAttendanceManagement_Click(object sender, EventArgs e)
        {

        }

        private void btnAdminMenu_Click(object sender, EventArgs e)
        {
            var managementMenu = new ManagementMenu();
            managementMenu.Show();
            Hide();
        }

        private void btnAttendanceDeparture_Click(object sender, EventArgs e)
        {

        }
    }
}
