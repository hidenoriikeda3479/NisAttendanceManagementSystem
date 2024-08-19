using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AttendanceManagementSystem.Views
{
    /// <summary>
    /// サンプル画面
    /// </summary>
    public partial class Sample : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        public Sample(AttendanceManagementDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        /// <summary>
        /// ロードイベント
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void Sample_Load(object sender, EventArgs e)
        {
            // フォームロード時に従業員データを表示
            dgvEmployees.DataSource = _context.Employees.ToList();
        }

        /// <summary>
        /// 検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 検索クエリの初期化
            var query = _context.Employees.AsQueryable();

            // 従業員名でフィルタリング
            if (!string.IsNullOrEmpty(txtSearchEmployeeName.Text))
            {
                query = query.Where(e => e.EmployeeName == txtSearchEmployeeName.Text);
            }

            // フィルタリング結果を表示
            dgvEmployees.DataSource = query.ToList();
        }

        /// <summary>
        /// 追加ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 新しい従業員データの作成
            var newEmployee = new EmployeeModel
            {
                EmployeeName = "固定名",
                Gender = 1,  
                Password = "fixedpassword",  
                PhoneNumber = "09012345678",  
                PostCode = "1234567",  
                Address = "固定住所",  
                BirthDate = new DateTime(1990, 1, 1),  
                RankId = 1,  
                ShiftId = 1,  
                HireDate = DateTime.Now,
                PermissionId = 1,  
                CreatedAt = DateTime.Now,
            };

            // 新しい従業員データを追加
            _context.Employees.Add(newEmployee);

            // 追加したデータをコミット
            _context.SaveChanges();

            // データグリッドを更新して通知
            MessageBox.Show("新しい従業員が追加されました。");

            // データグリッド再取得
            dgvEmployees.DataSource = _context.Employees.ToList();
        }

        /// <summary>
        /// 更新ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 選択された行があるか確認
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                // 選択された従業員のIDを取得
                int employeeId = (int)dgvEmployees.SelectedRows[0].Cells["EmployeeId"].Value;

                // IDで従業員を検索
                var employee = _context.Employees.Single(n => n.EmployeeId == employeeId);

                if (employee != null)
                {
                    // 従業員情報を固定値で更新
                    employee.EmployeeName = txtEditEmployeeName.Text;
                    employee.UpdatedAt = DateTime.Now;

                    // 追加したデータをコミット
                    _context.SaveChanges();

                    // データグリッドを更新して通知
                    MessageBox.Show("従業員情報が更新されました。");

                    // データグリッド再取得
                    dgvEmployees.DataSource = _context.Employees.ToList();
                }
            }
            else
            {
                MessageBox.Show("更新する従業員を選択してください。");
            }
        }
    }
}
