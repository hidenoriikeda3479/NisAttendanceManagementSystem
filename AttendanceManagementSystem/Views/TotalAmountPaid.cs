using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Models;
using System.Data;
using System.Windows.Forms;

namespace AttendanceManagementSystem.Views
{
    /// <summary>
    /// 総支給額集計画面
    /// </summary>
    public partial class TotalAmountPaid : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// 選択年格納
        /// </summary>
        private int targetYear;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        /// <param name="visibleflag">画面表記フラグ</param>
        public TotalAmountPaid(AttendanceManagementDbContext context,int visibleflag)
        {
            InitializeComponent();
            _context = context;
            targetYear = DateTime.Now.Year;

            // 押下時、画面表記変更イベント
            VisileEvent(visibleflag);
        }

        /// <summary>
        /// ロード画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TotalAmountPaid_Load(object sender, EventArgs e)
        {
            // ラベル初期表示（今年の西暦）
            UpdateYearLabel();

            // dataGridView の初期表示（今年の西暦）
            DateList(targetYear);
        }

        #region ボタンイベント

        /// <summary>
        /// 検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBtn_Click(object sender, EventArgs e)
        {
            UpdateYearLabel();

            // DateTimePickerの年を取得
            int searchyear = dateTimePicker1.Value.Year;

            // DateTimePickerの値を検索結果の年に設定
            dateTimePicker1.Value = new DateTime(searchyear, 1, 1);

            // 給与 dataGridView 反映イベント
            DateList(searchyear);
        }

        /// <summary>
        /// 左矢印ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLastyear_Click(object sender, EventArgs e)
        {
            // 現在選択されている年から1年引く
            int lastYear = dateTimePicker1.Value.Year - 1;

            // DateTimePickerの年を1年前に設定
            dateTimePicker1.Value = new DateTime(lastYear, 1, 1);

            // 過去年の給与表示(１年前を表示)
            DateList(lastYear);
        }

        /// <summary>
        /// 右矢印ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextyear_Click(object sender, EventArgs e)
        {
            // 次の年給与を表示
            int nextYear = dateTimePicker1.Value.Year + 1;

            // ボタン押下時、現在の年より未来年の表示不可
            if (nextYear <= DateTime.Now.Year)
            {
                targetYear = nextYear;
                dateTimePicker1.Value = new DateTime(targetYear, 1, 1);
                DateList(targetYear);

                return;
            }
        }

        #endregion

        #region 表示イベント

        /// <summary>
        /// 画面表記変更イベント
        /// </summary>
        /// <param name="visibleUpdate">フラグ固定値</param>
        private void VisileEvent(int visibleUpdate)
        {
            // 画面表記変更フラグ分岐
            if (visibleUpdate == 1)
            {
                // 総支給額集計ボタン押下時、総合集計表非表示
                salaryConfirmationLabel.Visible = false;
            }
            else
            {
                // 給料確認ボタン押下時、総合集計表非表示
                totallingLabel.Visible = false;
                totalSalaryDgv.Visible = false;
                monthlyTotalLabel.Visible = false;

                // foamサイズ変更
                this.Size = new Size(1100, 274);
            }
            return;
        }

        /// <summary>
        /// ラベル表示イベント
        /// </summary>
        private void UpdateYearLabel()
        {
            // 選択した年を表示
            labelyear.Text = dateTimePicker1.Value.ToString("yyyy年");
        }

        #endregion

        #region dataGridView 反映

        /// <summary>
        /// 給与 dataGridView 反映イベント
        /// </summary>
        private List<TotalAmountPaidViewModel> DateList(int targetYear)
        {
            var employees = _context.Employees
                .GroupJoin(
                _context.Attendances,
                e => e.EmployeeId,
                a => a.EmployeeId,
                (e, a) => new { e, a })
                .SelectMany(
                x => x.a.DefaultIfEmpty(),
                (e, a) => new
                {
                    e.e.EmployeeName,
                    e.e.EmployeeId,
                    e.e.RankId,
                    a.Year,
                    a.Month,
                    a.Day,
                    a.WorkStartTime,
                    a.WorkEndTime,
                    a.BreakTime,
                })
                .GroupJoin(
                _context.Ranks,
                ea => ea.RankId, r => r.RankId,
                (ea, r) => new { ea, r })
                .SelectMany(
                x => x.r.DefaultIfEmpty(),
                (ea, r) => new
                {
                    ea.ea.EmployeeName,
                    ea.ea.EmployeeId,
                    r.RankId,
                    r.HourlyPay,
                    ea.ea.Year,
                    ea.ea.Month,
                    ea.ea.Day,
                    ea.ea.WorkStartTime,
                    ea.ea.WorkEndTime,
                    ea.ea.BreakTime,

                }).ToList()
                .GroupBy(x => new { x.RankId, x.EmployeeId, x.EmployeeName })
                .Select(n => new TotalAmountPaidViewModel
                {
                    EmployeeName = n.Key.EmployeeName,

                    // 各月の計算式
                    January = n.Where(x => x.Year! == targetYear && x.Month == 1)
                    .Sum(x => (int)((x.WorkEndTime! - x.WorkStartTime! - x.BreakTime!).Value.TotalHours! * x.HourlyPay)),
                    February = n.Where(x => x.Year == targetYear && x.Month == 2)
                    .Sum(x => (int)((x.WorkEndTime! - x.WorkStartTime! - x.BreakTime!).Value.TotalHours! * x.HourlyPay)),
                    March = n.Where(x => x.Year == targetYear && x.Month == 3)
                    .Sum(x => (int)((x.WorkEndTime! - x.WorkStartTime! - x.BreakTime!).Value.TotalHours! * x.HourlyPay)),
                    April = n.Where(x => x.Year == targetYear && x.Month == 4)
                    .Sum(x => (int)((x.WorkEndTime! - x.WorkStartTime! - x.BreakTime!).Value.TotalHours! * x.HourlyPay)),
                    May = n.Where(x => x.Year == targetYear && x.Month == 5)
                    .Sum(x => (int)((x.WorkEndTime! - x.WorkStartTime! - x.BreakTime!).Value.TotalHours! * x.HourlyPay)),
                    June = n.Where(x => x.Year == targetYear && x.Month == 6)
                    .Sum(x => (int)((x.WorkEndTime! - x.WorkStartTime! - x.BreakTime!).Value.TotalHours! * x.HourlyPay)),
                    July = n.Where(x => x.Year == targetYear && x.Month == 7)
                    .Sum(x => (int)((x.WorkEndTime! - x.WorkStartTime! - x.BreakTime!).Value.TotalHours! * x.HourlyPay)),
                    August = n.Where(x => x.Year == targetYear && x.Month == 8)
                    .Sum(x => (int)((x.WorkEndTime! - x.WorkStartTime! - x.BreakTime!).Value.TotalHours! * x.HourlyPay)),
                    September = n.Where(x => x.Year == targetYear && x.Month == 9)
                    .Sum(x => (int)((x.WorkEndTime! - x.WorkStartTime! - x.BreakTime!).Value.TotalHours! * x.HourlyPay)),
                    October = n.Where(x => x.Year == targetYear && x.Month == 10)
                    .Sum(x => (int)((x.WorkEndTime! - x.WorkStartTime! - x.BreakTime!).Value.TotalHours! * x.HourlyPay)),
                    November = n.Where(x => x.Year == targetYear && x.Month == 11)
                    .Sum(x => (int)((x.WorkEndTime! - x.WorkStartTime! - x.BreakTime!).Value.TotalHours! * x.HourlyPay)),
                    December = n.Where(x => x.Year == targetYear && x.Month == 12)
                    .Sum(x => (int)((x.WorkEndTime! - x.WorkStartTime! - x.BreakTime!).Value.TotalHours! * x.HourlyPay))

                }).ToList();

            //  給与 dataGridView を表示
            salaryDgv.DataSource = employees;

            // 給与合計額を表示する
            Totalsalarydate(employees);

            return employees;
        }

        /// <summary>
        /// 給与合計 dataGridView 反映
        /// </summary>
        /// <param name="employees">List格納</param>
        private void Totalsalarydate(List<TotalAmountPaidViewModel> employees)
        {
            // DataTable 作成
            DataTable totalTable = new DataTable();
            totalTable.Columns.Add("January", typeof(int));
            totalTable.Columns.Add("February", typeof(int));
            totalTable.Columns.Add("March", typeof(int));
            totalTable.Columns.Add("April", typeof(int));
            totalTable.Columns.Add("May", typeof(int));
            totalTable.Columns.Add("June", typeof(int));
            totalTable.Columns.Add("July", typeof(int));
            totalTable.Columns.Add("August", typeof(int));
            totalTable.Columns.Add("September", typeof(int));
            totalTable.Columns.Add("October", typeof(int));
            totalTable.Columns.Add("November", typeof(int));
            totalTable.Columns.Add("December", typeof(int));
            totalTable.Columns.Add("Totalsalary", typeof(int));
        
            // 各月列の合計を計算
            DataRow row = totalTable.NewRow();
            row["January"] = employees.Sum(e => e.January);
            row["February"] = employees.Sum(e => e.February);
            row["March"] = employees.Sum(e => e.March);
            row["April"] = employees.Sum(e => e.April);
            row["May"] = employees.Sum(e => e.May);
            row["June"] = employees.Sum(e => e.June);
            row["July"] = employees.Sum(e => e.July);
            row["August"] = employees.Sum(e => e.August);
            row["September"] = employees.Sum(e => e.September);
            row["October"] = employees.Sum(e => e.October);
            row["November"] = employees.Sum(e => e.November);
            row["December"] = employees.Sum(e => e.December);

            // 給与総合計額
            row["Totalsalary"] = employees.Sum(e =>
                e.January + e.February + e.March + e.April + e.May + e.June +
                e.July + e.August + e.September + e.October + e.November + e.December);

            // DataTable に行を追加
            totalTable.Rows.Add(row);

            // 月合計 dataGridView にバインド
            totalSalaryDgv.DataSource = totalTable;
        }
        
        /// <summary>
        /// 給与 dataGridView の地域通貨設定、年月取得、
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // 列のセルの書式を地域通貨に設定
            foreach (DataGridViewColumn column in salaryDgv.Columns)
            {
                if (column.Index >= 1 && column.Index <= 14)
                {
                    column.DefaultCellStyle.Format = "c";
                }
            }
            // ラベル表示
            UpdateYearLabel();
        }

        /// <summary>
        /// 給与合計 dataGridView の地域通貨設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            // 列のセルの書式を地域通貨に設定
            foreach (DataGridViewColumn column in totalSalaryDgv.Columns)
            {
                if (column.Index >= 0 && column.Index <= 13)
                {
                    column.DefaultCellStyle.Format = "c";
                }
            }
        }

        #endregion
    }
}