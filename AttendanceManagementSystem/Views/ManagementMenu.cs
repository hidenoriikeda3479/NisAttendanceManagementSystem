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
    /// 初期選択画面
    /// </summary>
    public partial class ManagementMenu : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
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
        /// 就業院検索条件一覧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmployeeList_Click(object sender, EventArgs e)
        {
            // 従業員の検索フォームへ画面遷移
            (new EmployeeListForm(_context)).Show();
        }

        /// <summary>
        /// 部署検索条件一覧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDepartment_Click(object sender, EventArgs e)
        {
            // 部署のフォームへ画面遷移
            DepartmentListForm departmentListForm = new DepartmentListForm(_context);
            departmentListForm.Show();
        }

        /// <summary>
        /// 権限検索条件一覧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPermission_Click(object sender, EventArgs e)
        {
            // 権限のフォームへ画面遷移
            PermissionListForm permissionListForm = new PermissionListForm(_context);
            permissionListForm.Show();
        }

        /// <summary>
        /// 時給検索条件一覧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRank_Click(object sender, EventArgs e)
        {
            // 時給のフォームへ画面遷移
            RankListForm rankListForm = new RankListForm(_context);
            rankListForm.Show();
        }
    }
}
