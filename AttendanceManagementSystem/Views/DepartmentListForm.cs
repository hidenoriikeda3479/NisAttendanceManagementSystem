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
    /// <summary>
    /// 部署一覧画面
    /// </summary>
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
        /// フォームの初期処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepartmentListForm_Load(object sender, EventArgs e)
        {
            // 部署情報のすべて表示
            GetDepartment();

            // カラムにボタンを追加
            ModifyButton();

            // カラム名の変更
            SetHeaderColumn();
        }

        /// <summary>
        /// 部署の検索ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 部署名の検索処理
            FindDepartment();
        }

        /// <summary>
        /// データグリップビューにあるカラムボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgbDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView btnClick = (DataGridView)sender;

            // 「editButton」ボタンががクリックされた場合
            if (btnClick.Columns[e.ColumnIndex].Name == "editButton")
            {
                // 編集ボタンを押した行からデータを取得し画面遷移先に受け渡す
                int departmentId = (int)dgvDepartment.Rows[e.RowIndex].Cells["DepartmentId"].Value;
                EditDepartmentForm updateDepartment = new EditDepartmentForm(_context, departmentId);
                updateDepartment.Show();
            }

            // 「deleteButton」ボタンがクリックされた場合
            if (btnClick.Columns[e.ColumnIndex].Name == "deleteButton")
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
        /// 新規部署名の登録ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            // 部署登録画面へ移動する処理
            ShowDepartmentEditFome();
        }

        /// <summary>
        /// 部署情報の検索画面
        /// </summary>
        private void FindDepartment()
        {
            // 検索クエリの初期化
            var queryDelete = _context.department.AsQueryable();

            // 部署名でフィルタリング
            if (!string.IsNullOrEmpty(txtDepartment.Text))
            {
                queryDelete = queryDelete.Where(a => a.DepartmentName.Contains(txtDepartment.Text));
            }

            // フィルタリングデータを表示
            dgvDepartment.DataSource = queryDelete.ToList();
        }

        /// <summary>
        /// カラムに編集ボタンの追加
        /// </summary>
        private void ModifyButton()
        {
            // DataGridViewButtonColumnの作成
            // 編集ボタン
            DataGridViewButtonColumn Update1 = new DataGridViewButtonColumn();
            Update1.Name = "editButton";

            // 全てのボタンに「編集」と表示
            Update1.UseColumnTextForButtonValue = true;
            Update1.Text = "編集";

            // DataGridViewに追加
            dgvDepartment.Columns.Add(Update1);

            // 削除ボタン
            DataGridViewButtonColumn Update2 = new DataGridViewButtonColumn();
            Update2.Name = "deleteButton";

            // 全てのボタンに「削除」と表示
            Update2.UseColumnTextForButtonValue = true;
            Update2.Text = "削除";

            // DataGridViewに追加
            dgvDepartment.Columns.Add(Update2);

            // すべての列の幅を自動で調整する
            dgvDepartment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// フォームロード時に部署のデータをすべて表示
        /// </summary>
        private void GetDepartment()
        {
            // 部署のデータを表示
            dgvDepartment.DataSource = _context.department.ToList();
        }

        /// <summary>
        /// 新規部署名の登録画面へ画面遷移する処理
        /// </summary>
        private void ShowDepartmentEditFome()
        {
            // 部署新規登録フォームへ画面遷移する処理
            DepartmentScreenForm departmentScreenForm = new DepartmentScreenForm(_context);
            departmentScreenForm.Show();
        }

        /// <summary>
        /// 部署のカラム名の変更する処理
        /// </summary>
        private void SetHeaderColumn()
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

            var cgEditButton = dgvDepartment.Columns["editButton"];
            cgEditButton.HeaderText = "編集";

            var cgDeleteButton = dgvDepartment.Columns["deleteButton"];
            cgDeleteButton.HeaderText = "削除";
        }
    }
}
