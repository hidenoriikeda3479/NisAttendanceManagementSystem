using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Models;
using System.Data;


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
        /// ログイン従業員ID
        /// </summary>
        private readonly int _loginEmployeeId;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        /// <param name="loginEmployeeId">従業員ID</param>
        public EmployeeInformation(AttendanceManagementDbContext context, int loginEmployeeId)
        {
            InitializeComponent();
            _context = context;
            _loginEmployeeId = loginEmployeeId;
        }

        #region ロード・表示

        /// <summary>
        /// ロードイベント
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void EmployeeInformation_Load(object sender, EventArgs e)
        {
            // フォームロード時に従業員データを表示
            var employeeList = DateList();

            // 結果をDataGridViewにバインド
            Employeedgv.DataSource = employeeList;

            // コンボボックス初期選択状態を性別（ダミー）にする
            cmbgender.SelectedIndex = 0;

            // 縦スクロールバーのみ表示
            Employeedgv.ScrollBars = ScrollBars.Vertical;
        }

        /// <summary>
        /// 管理メニュー再表示
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void EmployeeInformation_FormClosing(object sender, FormClosingEventArgs e)
        {
            //  従業員一覧画面が閉じられた際に管理メニュー表示
            var managementMenu = new ManagementMenu(_context, _loginEmployeeId);
            managementMenu.Show();
        }
        #endregion

        #region Clickイベント

        /// <summary>
        /// 検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void Searchbtn_Click(object sender, EventArgs e)
        {
            // ComboBoxで選択された性別の値を取得
            int selectedGender = (int)cmbgender.SelectedIndex;

            // フィルタリングされたリストを取得
            var employeeList = DateList();

            // 結果をDataGridViewにバインド
            Employeedgv.DataSource = employeeList;
        }

        /// <summary>
        /// 更新ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void Updatebtn_Click(object sender, EventArgs e)
        {
            // 選択された行があるか確認
            if (Employeedgv.SelectedRows.Count > 0)
            {
                // 社員情報（更新）画面を表示
                int employeeId = (int)Employeedgv.SelectedRows[0].Cells["Column1"].Value;
                var employeeRegUpdate = new EmployeeRegUpdate(_context, employeeId);
                employeeRegUpdate.Show();

                var managementMenu = new ManagementMenu(_context, _loginEmployeeId);
                managementMenu.Close();
            }
            else
            {
                MessageBox.Show("更新する従業員を選択してください。");
            }
        }

        /// <summary>
        /// 勤怠確認ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void Ateendbtn_Click(object sender, EventArgs e)
        {
            // 選択された行があるか確認
            if (Employeedgv.SelectedRows.Count > 0)
            {
                // 勤怠確認画面を表示
                int employeeId = (int)Employeedgv.SelectedRows[0].Cells["Column1"].Value;
                var attendance = new Attendance(_context, _loginEmployeeId, employeeId);
                attendance.Show();
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
        List<EmployeeInformationViewModel> DateList()
        {
            List<EmployeeInformationViewModel> list = new List<EmployeeInformationViewModel>();

            // ComboBoxで選択された性別のインデックスを取得
            int selectedGender = cmbgender.SelectedIndex;

            // 従業員テーブルからのデータをクエリ可能な形式で取得 
            var query = _context.Employees.AsQueryable();

            // 性別の選択に基づいてフィルタリング
            if (selectedGender > 0) // 0 は通常「未選択」を意味する場合があります
            {
                query = query.Where(e => e.Gender == selectedGender);
            }

            // 検索フィールドが空でない場合、名前でもフィルタリング
            if (!string.IsNullOrEmpty(Searchtxt.Text))
            {
                query = query.Where(e => e.EmployeeName.Contains(Searchtxt.Text));
            }

            var employeeList = query.Select(n => new EmployeeInformationViewModel
            {
                EmployeeId = n.EmployeeId,
                EmployeeName = n.EmployeeName,
                Gender = n.Gender == 1 ? "男" : "女",
                PhoneNumber = n.PhoneNumber,
                Address = n.PostCode + n.Address + n.BuildingName,
                HireDate = n.HireDate,
                ResignDate = n.ResignDate,
                UpdatedAt = n.UpdatedAt

            }).ToList();

            return employeeList;
        }
        #endregion
    }
}
