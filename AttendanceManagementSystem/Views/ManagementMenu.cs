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
    /// <summary>
    /// 管理者メニュー
    /// </summary>
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

        /// <summary>
        /// 従業員登録・更新画面遷移
        /// </summary>
        /// <param name="sender">コントロール情報</param>
        /// <param name="e">イベント情報</param>
        private void btnEmployeeRegUpdate_Click(object sender, EventArgs e)
        {
            //従業員登録・更新画面遷移
            var employeeRegUpdate = new EmployeeRegUpdate(_context);
            employeeRegUpdate.Show();
            Hide();
        }

        /// <summary>
        /// 従業員一覧画面遷移
        /// </summary>
        /// <param name="sender">コントロール情報</param>
        /// <param name="e">イベント情報</param>
        private void btnEmployeeInformation_Click(object sender, EventArgs e)
        {
            //従業員一覧画面遷移
            var employeeInformation = new EmployeeInformation(_context);
            employeeInformation.Show();
            Hide();
        }

        /// <summary>
        /// 総支給額画面遷移
        /// </summary>
        /// <param name="sender">コントロール情報</param>
        /// <param name="e">イベント情報</param>
        private void btnTotalAmountPaid_Click_1(object sender, EventArgs e)
        {
            //総支給額画面遷移
            var totalAmountPaid = new TotalAmountPaid(_context);
            totalAmountPaid.Show();
            Hide();
        }
    }
}
