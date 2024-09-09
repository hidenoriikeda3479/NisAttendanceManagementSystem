using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AttendanceManagementSystem.Views
{
    /// <summary>
    /// 従業員一覧画面
    /// </summary>
    public partial class EmployeeInformation : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context"></param>
        public EmployeeInformation(AttendanceManagementDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        /// <summary>
        /// ロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeInformation_Load(object sender, EventArgs e)
        {
            // フォームロード時に従業員データを表示
            DateList();
        }

        

        #region Clickイベント一覧

        /// <summary>
        /// 検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchbtn_Click(object sender, EventArgs e)
        {
            DateList();

            // ComboBoxで選択された性別の値を取得
            int selectedGender = (int)comboBox1.SelectedIndex;
        }

        /// <summary>
        /// 更新ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upbtn_Click(object sender, EventArgs e)
        {
            // 選択された行があるか確認
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //// 選択された従業員のIDを取得 TODO:更新画面に遷移後
                //int employeeId = (int)dataGridView1.SelectedRows[0].Cells["EmployeeId"].Value;
                //var EmployeeUpdate = new EmployeeUpdate(employeeId.ToString());
                //EmployeeUpdate.Show();
            }
            else
            {
                MessageBox.Show("更新する従業員を選択してください。");
            }     
        }

        /// <summary>
        /// 勤怠確認ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void atabtn_Click(object sender, EventArgs e)
        {
            // 選択された行があるか確認
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //// 選択された従業員のID、名前を取得 TODO:勤怠確認画面に遷移後
                //int employeeId = (int)dataGridView1.SelectedRows[0].Cells["EmployeeId"].Value;
                //var AttendAnce = new AttendAnce(employeeId.ToString(),employeename.ToString());
                //AttendAnce.Show();
            }
            else
            {
                MessageBox.Show("従業員を選択してください。");
            }
        }

        #endregion

        #region DataGridViewイベント

        /// <summary>
        /// DataGridView反映イベント
        /// </summary>
        private void DateList()
        {
            List<EmployeeInformationViewModel> list = new List<EmployeeInformationViewModel>();

            // ComboBoxで選択された性別の値を取得
            int selectedGender = comboBox1.SelectedIndex;

            var query = _context.Employees.AsQueryable();

            // 性別の選択に基づいてフィルタリング
            if (selectedGender > 0)
            {
                // 男または女が選ばれた場合、その性別でフィルタリング
                query = query.Where(e => e.Gender == selectedGender);
            }

            // 検索フィールドが空でない場合、名前でもフィルタリング
            if (!string.IsNullOrEmpty(searchTxt.Text))
            {
                query = query.Where(e => e.EmployeeName.Contains(searchTxt.Text));
            }

            var employeeList = query.Select(n => new EmployeeInformationViewModel
            {
                EmployeeId = n.EmployeeId,
                EmployeeName = n.EmployeeName,
                Gender = n.Gender,
                PhoneNumber = n.PhoneNumber,
                Address = n.PostCode + n.Address + n.BuildingName,
                HireDate = n.HireDate,
                ResignDate = n.ResignDate,
                UpdatedAt = n.UpdatedAt
            });

            // 結果をDataGridViewにバインド
            dataGridView1.DataSource = employeeList.ToList();
        }

        #endregion
    }
}
