using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AttendanceManagementSystem
{
    /// <summary>
    /// 従業員検索画面
    /// </summary>
    public partial class EmployeeListForm : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        public EmployeeListForm(AttendanceManagementDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeListForm_Load(object sender, EventArgs e)
        {
            // 従業員情報の表示
            GetEmployee();

            // カラムにボタン追加
            ModifyButton();
        }

        /// <summary>
        /// 検索ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getEmployeeButton_Click(object sender, EventArgs e)
        {
            // 従業員検索
            FindEmployee();
        }

        /// <summary>
        /// 生年月日のチェックボックス処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbBirthday_CheckedChanged(object sender, EventArgs e)
        {
            // 生年月日の表示
            CheckedBirthday();
        }

        /// <summary>
        /// 従業員登録ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            // 従業員登録画面
            ShowEmployeeEditFome();
        }

        /// <summary>
        /// フォームロード時に従業員のデータを表示
        /// </summary>
        private void GetEmployee()
        {
            // 従業員のデータを表示
            dgvEmployees.DataSource = _context.Employees.ToList();
        }

        /// <summary>
        /// 従業員情報の検索画面
        /// </summary>
        private void FindEmployee()
        {
            // 検索クエリの初期化
            var queryClear = _context.Employees.AsQueryable();

            // 従業員名でフィルタリング
            if (!string.IsNullOrEmpty(txtSearchEmployeeName.Text))
            {
                queryClear = queryClear.Where(a => a.EmployeeName.Contains(txtSearchEmployeeName.Text));
            }

            // 生年月日でフィルタリング
            if (chbBirthday.Checked)
            {
                queryClear = queryClear.Where(b => b.BirthDate.Date == dtpSearchBirthDate.Value.Date);
            }

            // 電話番号でフィルタリング
            if (!string.IsNullOrEmpty(txtSearchContactNumber.Text))
            {
                queryClear = queryClear.Where(c => c.PhoneNumber == txtSearchContactNumber.Text);
            }

            // フィルタリングデータを表示
            dgvEmployees.DataSource = queryClear.ToList();
        }

        /// <summary>
        /// 生年月日の入力チェックボックスのチェンジイベント
        /// </summary>
        private void CheckedBirthday()
        {

            dtpSearchBirthDate.Enabled = chbBirthday.Checked;
        }

        /// <summary>
        /// データグリップビューにあるボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView btnClick = (DataGridView)sender;

            //「Button1」列がクリックされた場合(編集ボタン)
            if (btnClick.Columns[e.ColumnIndex].Name == "編集")
            {
                // 選択された従業員のIDを取得
                int employeeId = (int)dgvEmployees.Rows[e.RowIndex].Cells["EmployeeId"].Value;
                UpdateEmployeeForm updateEmployee = new UpdateEmployeeForm(_context, employeeId);
                updateEmployee.Show();
            }

            //「Button2の行がクリックされた場合(クリアボタン)
            if (btnClick.Columns[e.ColumnIndex].Name == "削除")
            {
                // 選択された従業員のIDを取得
                int employeeId = (int)dgvEmployees.Rows[e.RowIndex].Cells["EmployeeId"].Value;

                // IDで従業員を検索
                var upEmployee = _context.Employees.Single(a => a.EmployeeId == employeeId);

                // 選択行を削除
                _context.Employees.Remove(upEmployee);

                // 削除したデータをコミット
                _context.SaveChanges();

                // データグリッドを更新して通知
                MessageBox.Show("削除されました。");

                // データグリッド再取得
                dgvEmployees.DataSource = _context.Employees.ToList();
            }
        }

        /// <summary>
        /// カラムに編集ボタンの追加
        /// </summary>
        private void ModifyButton()
        {
            // DataGridViewButtonColumnの作成
            // 編集ボタン
            DataGridViewButtonColumn Update1 = new DataGridViewButtonColumn();
            Update1.Name = "編集";

            // 全てのボタンに「編集」と表示
            Update1.UseColumnTextForButtonValue = true;
            Update1.Text = "編集";

            // DataGridViewに追加
            dgvEmployees.Columns.Add(Update1);

            // 削除ボタン
            DataGridViewButtonColumn Update2 = new DataGridViewButtonColumn();
            Update2.Name = "削除";

            // 全てのボタンに「編集」と表示
            Update2.UseColumnTextForButtonValue = true;
            Update2.Text = "削除";

            // DataGridViewに追加
            dgvEmployees.Columns.Add(Update2);
        }

        /// <summary>
        /// 従業員登録画面へ画面遷移
        /// </summary>
        private void ShowEmployeeEditFome()
        {
            // 従業員の登録フォームへ画面遷移
            (new AddEmployeeForm(_context)).Show();
        }
    }
}

    
    


