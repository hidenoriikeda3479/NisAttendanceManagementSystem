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

namespace AttendanceManagementSystem.Views
{
    public partial class DepartmentListForm : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        public DepartmentListForm(AttendanceManagementDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepartmentListForm_Load(object sender, EventArgs e)
        {
            // 部署情報の表示
            GetDepartment();

            // カラムにボタン追加
            ModifyButton();

            // カラム名の変更
            ChangingName();
        }

        /// <summary>
        /// 検索ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 部署検索
            FindDepartment();
        }

        /// <summary>
        /// データグリップビューにあるボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgbDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView btnClick = (DataGridView)sender;

            // 編集ボタンががクリックされた場合(編集ボタン)
            if (btnClick.Columns[e.ColumnIndex].Name == "編集")
            {
                // 選択された従業員のIDを取得
                int departmentId = (int)dgvDepartment.Rows[e.RowIndex].Cells["DepartmentId"].Value;
                EditDepartmentForm updateDepartment = new EditDepartmentForm(_context, departmentId);
                updateDepartment.Show();
            }

            // 削除ボタンがクリックされた場合(クリアボタン)
            if (btnClick.Columns[e.ColumnIndex].Name == "削除")
            {
                // 選択された従業員のIDを取得
                int dmployeeId = (int)dgvDepartment.Rows[e.RowIndex].Cells["DepartmentId"].Value;

                // IDで従業員を検索
                var upDepartment = _context.department.Single(a => a.DepartmentId == dmployeeId);

                // 選択行を削除
                _context.department.Remove(upDepartment);

                // 削除したデータをコミット
                _context.SaveChanges();

                // データグリッドを更新して通知
                MessageBox.Show("削除されました。");

                // データグリッド再取得
                dgvDepartment.DataSource = _context.department.ToList();
            }
        }

        /// <summary>
        /// 部署登録ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            // 部署登録画面
            ShowDepartmentAddForm();
        }

        /// <summary>
        /// 部署情報の検索画面
        /// </summary>
        private void FindDepartment()
        {
            // 検索クエリの初期化
            var queryClear = _context.department.AsQueryable();

            // 部署名でフィルタリング
            if (!string.IsNullOrEmpty(txtDepartment.Text))
            {
                queryClear = queryClear.Where(a => a.DepartmentName.Contains(txtDepartment.Text));
            }

            // フィルタリングデータを表示
            dgvDepartment.DataSource = queryClear.ToList();
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
            dgvDepartment.Columns.Add(Update1);

            // 削除ボタン
            DataGridViewButtonColumn Update2 = new DataGridViewButtonColumn();
            Update2.Name = "削除";

            // 全てのボタンに「編集」と表示
            Update2.UseColumnTextForButtonValue = true;
            Update2.Text = "削除";

            // DataGridViewに追加
            dgvDepartment.Columns.Add(Update2);

            // すべての列の幅を自動で調整する
            dgvDepartment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// フォームロード時に部署のデータを表示
        /// </summary>
        private void GetDepartment()
        {
            // 部署のデータを表示
            dgvDepartment.DataSource = _context.department.ToList();
        }

        /// <summary>
        /// 部署登録画面へ画面遷移
        /// </summary>
        private void ShowDepartmentAddForm()
        {
            // 部署新規登録フォームへ画面遷移する処理
            DepartmentScreenForm departmentScreenForm = new DepartmentScreenForm(_context);
            departmentScreenForm.Show();
        }

        /// <summary>
        /// 部署のカラム名の変更
        /// </summary>
        private void ChangingName()
        {
            // カラムの表示名の変更
            var cgId = dgvDepartment.Columns["DepartmentId"];
            cgId.HeaderText = "ID";

            var cgName = dgvDepartment.Columns["DepartmentName"];
            cgName.HeaderText = "部署";

            var cgDepartment = dgvDepartment.Columns["CreatedAt"];
            cgDepartment.HeaderText = "作成日";

            var cgTitle = dgvDepartment.Columns["UpdatedAt"];
            cgTitle.HeaderText = "更新日";
        }
    }
}
