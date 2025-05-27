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
    public partial class ManagementMenu : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        public ManagementMenu(AttendanceManagementDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void btnEmployeeRegistration_Click(object sender, EventArgs e)
        {
            // サンプル
            //(new Sample(_context)).Show();
        }

        /// <summary>
        /// 検索条件一覧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmployeeList_Click(object sender, EventArgs e)
        {
            // 従業員の検索フォームへ画面遷移
            (new EmployeeListForm(_context)).Show();
        }

        private void btnSalaryList_Click(object sender, EventArgs e)
        {

        }
    }
}
