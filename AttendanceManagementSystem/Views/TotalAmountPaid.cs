﻿using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Models;
using System.Data;

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
        private int selectYear;

        /// <summary>
        /// ユーザー閲覧
        /// </summary>
        private int targetId;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        /// <param name="id">ユーザー閲覧</param>
        public TotalAmountPaid(AttendanceManagementDbContext context, int id = 0)
        {
            InitializeComponent();
            _context = context;
            selectYear = DateTime.Now.Year;
            targetId = id;
        }

        #region ロード・表示

        /// <summary>
        /// ロード画面
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void TotalAmountPaid_Load(object sender, EventArgs e)
        {
            // 画面表記変更フラグ
            bool visibleflag = VisileEvent(targetId);

            //画面表記変更イベントを実行し、表示状態を取得
            if (visibleflag)
            {
                //給料画面表示
                SalaryConfirmation();
            }
            else
            {
                // dataGridView の初期表示（今年の西暦）
                DateList(selectYear);
            }
        }

        /// <summary>
        /// 画面表記変更イベント
        /// </summary>
        /// <param name="visibleUpdate">フラグ固定値</param>
        /// <returns>画面遷移結果</returns>
        private bool VisileEvent(int visibleTotal)
        {
            //画面表記変更フラグ
            bool visibleflag;

            // 画面表記変更フラグ分岐
            if (visibleTotal == 0)
            {
                // 総支給額集計ボタン押下時、総合集計表非表示
                salaryConfirmationLabel.Visible = false;

                visibleflag = false;
                return visibleflag;
            }
            else
            {
                // 給料確認ボタン押下時、総合集計表非表示
                totallingLabel.Visible = false;
                totalSalaryDgv.Visible = false;
                monthlyTotalLabel.Visible = false;

                // foamサイズ変更
                this.Size = new Size(1095, 274);
                visibleflag = true;
                return visibleflag;
            }
        }

        /// <summary>
        /// 管理メニュー再表示
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void TotalAmountPaid_FormClosing(object sender, FormClosingEventArgs e)
        {
            //画面表記変更フラグ
            int visibleflag = targetId;

            if (visibleflag == 0)
            {
                var managementMenu = new ManagementMenu(_context, targetId);
                managementMenu.Show();
            }
            return;
        }
        #endregion

        #region clickイベント

        /// <summary>
        /// 検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void searchBtn_Click(object sender, EventArgs e)
        {
            // 選択したカレンダーをラベルに表示
            labelyear.Text = yeardtp.Value.ToString("yyyy年");

            // カレンダー選択年
            int searchYear = yeardtp.Value.Year;

            selectYear = searchYear;

            // DateTimePickerの選択年を設定
            yeardtp.Value = new DateTime(selectYear, 1, 1);

            // 個人の給与画面表示
            if (targetId != 0)
            {
                SalaryConfirmation();
            }
            else
            {
                // 給与 dataGridView 反映イベント
                DateList(selectYear);
            }
            return;
        }

        /// <summary>
        /// 左矢印ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void btnLastyear_Click(object sender, EventArgs e)
        {
            // 現在選択されている年から1年引く
            int lastYear = yeardtp.Value.Year - 1;

            selectYear = lastYear;

            // DateTimePickerの年を1年前に設定
            yeardtp.Value = new DateTime(selectYear, 1, 1);

            // 個人の給与画面表示
            if (targetId != 0)
            {
                SalaryConfirmation();
            }
            else
            {
                // 給与 dataGridView 反映イベント
                DateList(selectYear);
            }
            return;
        }

        /// <summary>
        /// 右矢印ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void btnNextyear_Click(object sender, EventArgs e)
        {
            // 次の年給与を表示
            int nextYear = yeardtp.Value.Year + 1;

            // ボタン押下時、現在の年より未来年の表示不可
            if (nextYear <= DateTime.Now.Year)
            {
                selectYear = nextYear;
                yeardtp.Value = new DateTime(selectYear, 1, 1);
                DateList(selectYear);

                // 個人の給与画面表示
                if (targetId != 0)
                {
                    SalaryConfirmation();
                }
                return;
            }
        }
        #endregion

        #region dataGridView 反映

        /// <summary>
        /// 給与 dataGridView 反映イベント
        /// </summary>
        /// <param name="targetYear">選択年格納</param>
        /// <returns>`TotalAmountPaidViewModel` オブジェクトのリスト</returns>
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
                    Year = a != null ? a.Year : (decimal?)null,
                    Month = a != null ? a.Month : (decimal?)null,
                    Day = a != null ? a.Day : (decimal?)null,
                    WorkStartTime = a != null ? a.WorkStartTime : null,
                    WorkEndTime = a != null ? a.WorkEndTime : null,
                    BreakTime = a != null ? a.BreakTime : null,
                })
                .GroupJoin(
                _context.Ranks,
                ea => ea.RankId,
                r => r.RankId,
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

                    // １月の給与計算
                    January = n.Where(x => x.Year! == targetYear && x.Month == 1 && x.WorkEndTime != null)
                    .Sum(x => (decimal)((x.WorkEndTime.GetValueOrDefault() - x.WorkStartTime.GetValueOrDefault() - x.BreakTime.GetValueOrDefault())
                    .TotalHours * x.HourlyPay)),

                    // ２月の給与計算
                    February = n.Where(x => x.Year == targetYear && x.Month == 2 && x.WorkEndTime != null)
                    .Sum(x => (decimal)((x.WorkEndTime.GetValueOrDefault() - x.WorkStartTime.GetValueOrDefault() - x.BreakTime.GetValueOrDefault())
                    .TotalHours * x.HourlyPay)),

                    // ３月の給与計算
                    March = n.Where(x => x.Year == targetYear && x.Month == 3 && x.WorkEndTime != null)
                    .Sum(x => (decimal)((x.WorkEndTime.GetValueOrDefault() - x.WorkStartTime.GetValueOrDefault() - x.BreakTime.GetValueOrDefault())
                    .TotalHours * x.HourlyPay)),

                    // ４月の給与計算
                    April = n.Where(x => x.Year == targetYear && x.Month == 4 && x.WorkEndTime != null)
                    .Sum(x => (decimal)((x.WorkEndTime.GetValueOrDefault() - x.WorkStartTime.GetValueOrDefault() - x.BreakTime.GetValueOrDefault())
                    .TotalHours * x.HourlyPay)),

                    // ５月の給与計算
                    May = n.Where(x => x.Year == targetYear && x.Month == 5 && x.WorkEndTime != null)
                    .Sum(x => (decimal)((x.WorkEndTime.GetValueOrDefault() - x.WorkStartTime.GetValueOrDefault() - x.BreakTime.GetValueOrDefault())
                    .TotalHours * x.HourlyPay)),

                    // ６月の給与計算
                    June = n.Where(x => x.Year == targetYear && x.Month == 6 && x.WorkEndTime != null)
                    .Sum(x => (decimal)((x.WorkEndTime.GetValueOrDefault() - x.WorkStartTime.GetValueOrDefault() - x.BreakTime.GetValueOrDefault())
                    .TotalHours * x.HourlyPay)),

                    // ７月の給与計算
                    July = n.Where(x => x.Year == targetYear && x.Month == 7 && x.WorkEndTime != null)
                    .Sum(x => (decimal)((x.WorkEndTime.GetValueOrDefault() - x.WorkStartTime.GetValueOrDefault() - x.BreakTime.GetValueOrDefault())
                    .TotalHours * x.HourlyPay)),

                    // ８月の給与計算
                    August = n.Where(x => x.Year == targetYear && x.Month == 8 && x.WorkEndTime != null)
                    .Sum(x => (decimal)((x.WorkEndTime.GetValueOrDefault() - x.WorkStartTime.GetValueOrDefault() - x.BreakTime.GetValueOrDefault())
                    .TotalHours * x.HourlyPay)),

                    // ９月の給与計算
                    September = n.Where(x => x.Year == targetYear && x.Month == 9 && x.WorkEndTime != null)
                    .Sum(x => (decimal)((x.WorkEndTime.GetValueOrDefault() - x.WorkStartTime.GetValueOrDefault() - x.BreakTime.GetValueOrDefault())
                    .TotalHours * x.HourlyPay)),

                    // １０月の給与計算
                    October = n.Where(x => x.Year == targetYear && x.Month == 10 && x.WorkEndTime != null)
                    .Sum(x => (decimal)((x.WorkEndTime.GetValueOrDefault() - x.WorkStartTime.GetValueOrDefault() - x.BreakTime.GetValueOrDefault())
                    .TotalHours * x.HourlyPay)),

                    // １１月の給与計算
                    November = n.Where(x => x.Year == targetYear && x.Month == 11 && x.WorkEndTime != null)
                    .Sum(x => (decimal)((x.WorkEndTime.GetValueOrDefault() - x.WorkStartTime.GetValueOrDefault() - x.BreakTime.GetValueOrDefault())
                    .TotalHours * x.HourlyPay)),

                    // １２月の給与計算
                    December = n.Where(x => x.Year == targetYear && x.Month == 12 && x.WorkEndTime != null)
                    .Sum(x => (decimal)((x.WorkEndTime.GetValueOrDefault() - x.WorkStartTime.GetValueOrDefault() - x.BreakTime.GetValueOrDefault())
                    .TotalHours * x.HourlyPay)),

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
            totalTable.Columns.Add("January", typeof(decimal));
            totalTable.Columns.Add("February", typeof(decimal));
            totalTable.Columns.Add("March", typeof(decimal));
            totalTable.Columns.Add("April", typeof(decimal));
            totalTable.Columns.Add("May", typeof(decimal));
            totalTable.Columns.Add("June", typeof(decimal));
            totalTable.Columns.Add("July", typeof(decimal));
            totalTable.Columns.Add("August", typeof(decimal));
            totalTable.Columns.Add("September", typeof(decimal));
            totalTable.Columns.Add("October", typeof(decimal));
            totalTable.Columns.Add("November", typeof(decimal));
            totalTable.Columns.Add("December", typeof(decimal));
            totalTable.Columns.Add("Totalsalary", typeof(decimal));

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
        /// 給与 dataGridView の日本通貨設定、年月取得
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void DtpSalary_ValueChanged(object sender, EventArgs e)
        {
            // 列のセルの書式を日本通貨に設定
            foreach (DataGridViewColumn column in salaryDgv.Columns)
            {
                if (column.Index >= 1 && column.Index <= 14)
                {
                    column.DefaultCellStyle.Format = "c";
                }
            }
            labelyear.Text = yeardtp.Value.ToString("yyyy年");
        }

        /// <summary>
        /// 給与合計 dataGridView の日本通貨設定
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void DtpTotalSalary_ValueChanged(object sender, EventArgs e)
        {
            // 列のセルの書式を日本通貨に設定
            foreach (DataGridViewColumn column in totalSalaryDgv.Columns)
            {
                if (column.Index >= 0 && column.Index <= 13)
                {
                    column.DefaultCellStyle.Format = "c";
                }
            }
        }

        /// <summary>
        /// 個人給料表示
        /// </summary>
        private void SalaryConfirmation()
        {
            // DateListメソッドを呼び出し、結果を取得
            List<TotalAmountPaidViewModel> result = DateList(selectYear);

            // ログインIDから従業員名を取得
            var searchname = _context.Employees.Where(n => n.EmployeeId == targetId).Select(n => n.EmployeeName).ToList();

            // 対象社員名を取得
            var targetname = searchname.First();

            // 対象社員の照合
            var matchrecord = result.Where(n => n.EmployeeName == targetname).ToList();

            // 給与 dataGridView を表示
            salaryDgv.DataSource = matchrecord;
        }
        #endregion
    }
}