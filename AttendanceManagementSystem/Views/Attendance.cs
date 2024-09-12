using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AttendanceManagementSystem.Views
{
    /// <summary>
    /// 勤怠管理画面
    /// </summary>
    public partial class Attendance : Form
    {
        #region メンバ変数

        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// 従業員情報
        /// </summary>
        private readonly EmployeeModel _employeeModel;

        /// <summary>
        /// 管理者権限
        /// </summary>
        private const int PermissionAdmin = 1;

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context">データベースコンテキスト</param>
        /// <param name="employeeId">従業員ID</param>
        public Attendance(AttendanceManagementDbContext context, int employeeId)
        {
            InitializeComponent();

            // DBコンテキストと従業員情報を設定
            _context = context;
            _employeeModel = LoadEmployee(employeeId);
        }

        #endregion

        #region アクションイベント

        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">オブジェクト情報</param>
        /// <param name="e">イベント情報</param>
        private void Attendance_Load(object sender, EventArgs e)
        {
            // 勤怠情報を表示
            attendanceDataGridView.DataSource = ListAttendance(_employeeModel.EmployeeId, DateTime.Now.Year, DateTime.Now.Month);

            // 権限に応じて操作を制御
            attendanceDataGridView.Enabled = _employeeModel.PermissionId == PermissionAdmin;
            btnUpdate.Visible = _employeeModel.PermissionId == PermissionAdmin;
        }

        /// <summary>
        /// 検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender">オブジェクト情報</param>
        /// <param name="e">イベント情報</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 指定された月の勤怠情報を表示
            attendanceDataGridView.DataSource = ListAttendance(_employeeModel.EmployeeId, SearchDate.Value.Year, SearchDate.Value.Month);

            // 過去日付は編集不可
            attendanceDataGridView.Enabled = DateTime.Now.Year == SearchDate.Value.Year && DateTime.Now.Month == SearchDate.Value.Month && _employeeModel.PermissionId == PermissionAdmin;
            btnUpdate.Enabled = DateTime.Now.Year == SearchDate.Value.Year && DateTime.Now.Month == SearchDate.Value.Month;
        }

        /// <summary>
        /// 更新ボタンクリックイベント
        /// </summary>
        /// <param name="sender">オブジェクト情報</param>
        /// <param name="e">イベント情報</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 表示されている勤怠情報を取得
            var updatedAttendanceList = attendanceDataGridView.DataSource as List<AttendanceViewModel>;

            // 勤怠情報の検証
            if (!CheckAttendance(updatedAttendanceList!))
                return;

            // DBに新規追加、削除、更新を反映
            ProcessDatabaseChanges(updatedAttendanceList!);

            // 変更を保存
            _context.SaveChanges();

            // 処理完了メッセージを表示
            MessageBox.Show("更新が完了しました");

            // 更新結果を再取得
            attendanceDataGridView.DataSource = ListAttendance(_employeeModel.EmployeeId, SearchDate.Value.Year, SearchDate.Value.Month);
        }

        /// <summary>
        /// セル描画前のフォーマットを設定イベント
        /// </summary>
        /// <param name="sender">オブジェクト情報</param>
        /// <param name="e">イベント情報</param>
        private void attendanceDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 曜日列のみを対象
            if (attendanceDataGridView.Columns[e.ColumnIndex].DataPropertyName == "DayOfWeek")
            {
                // 曜日を取得し、土日かどうか判定
                switch (e.Value?.ToString())
                {
                    case "土":
                        e.CellStyle!.BackColor = Color.LightBlue;
                        break;
                    case "日":
                        e.CellStyle!.BackColor = Color.LightCoral;
                        break;
                }
            }
        }

        #endregion

        #region privateメソッド

        /// <summary>
        /// 勤怠情報の新規追加、削除、更新を処理
        /// </summary>
        /// <param name="attendanceList">勤怠情報リスト</param>
        private void ProcessDatabaseChanges(List<AttendanceViewModel> attendanceList)
        {
            // 新規追加処理
            var insertAttendanceList = attendanceList
                .Where(n => !n.AttendanceId.HasValue && !string.IsNullOrEmpty(n.WorkStartTimeHour))
                .ToList();

            if (insertAttendanceList.Any())
            {
                _context.Attendances.AddRange(SetCreateAttendanceModels(insertAttendanceList));
            }

            // 削除と更新の処理
            foreach (var attendance in attendanceList.Where(n => n.AttendanceId.HasValue).ToList())
            {
                // DBから該当の勤怠情報を取得
                var existingAttendance = _context.Attendances.Single(a => a.EmployeeId == _employeeModel.EmployeeId && a.Year == attendance.Year && a.Month == attendance.Month && a.Day == attendance.Date);

                // 削除処理
                if (string.IsNullOrEmpty(attendance.WorkStartTimeHour))
                {
                    _context.Attendances.Remove(existingAttendance);
                }
                // 更新処理
                else
                {
                    UpdateAttendanceModel(existingAttendance, attendance);
                    _context.Entry(existingAttendance).State = EntityState.Modified;
                }
            }
        }

        /// <summary>
        /// 勤怠新規登録情報を作成
        /// </summary>
        /// <param name="attendanceList">勤怠情報のリスト</param>
        /// <returns>勤怠作成情報リスト</returns>
        private List<AttendanceModel> SetCreateAttendanceModels(List<AttendanceViewModel> attendanceList) =>
            attendanceList.Select(attendance => new AttendanceModel
            {
                EmployeeId = _employeeModel.EmployeeId,
                Year = attendance.Year,
                Month = attendance.Month,
                Day = attendance.Date,
                WorkStartTime = attendance.WorkStartTimeHour != null
                                ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, attendance.Date,
                                    int.Parse(attendance.WorkStartTimeHour!), int.Parse(attendance.WorkStartTimeMinutes!), 0)
                                : null,
                WorkEndTime = attendance.WorkEndTimeHour != null
                                ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, attendance.Date,
                                    int.Parse(attendance.WorkEndTimeHour!), int.Parse(attendance.WorkEndTimeMinutes!), 0)
                                : null,
                BreakTime = attendance.BreakTimeHour != null
                                ? new TimeSpan(int.Parse(attendance.BreakTimeHour!), int.Parse(attendance.BreakTimeMinutes!), 0)
                                : null,
                Remarks = attendance.Remarks,
                CreatedAt = DateTime.Now
            }).ToList();

        /// <summary>
        /// 勤怠情報更新
        /// </summary>
        /// <param name="existingAttendance">既存のDBデータ</param>
        /// <param name="updatedAttendance">更新するデータ</param>
        private void UpdateAttendanceModel(AttendanceModel existingAttendance, AttendanceViewModel updatedAttendance)
        {
            existingAttendance.WorkStartTime = updatedAttendance.WorkStartTimeHour != null
                ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, updatedAttendance.Date,
                    int.Parse(updatedAttendance.WorkStartTimeHour!), int.Parse(updatedAttendance.WorkStartTimeMinutes!), 0)
                : null;

            existingAttendance.WorkEndTime = updatedAttendance.WorkEndTimeHour != null
                ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, updatedAttendance.Date,
                    int.Parse(updatedAttendance.WorkEndTimeHour!), int.Parse(updatedAttendance.WorkEndTimeMinutes!), 0)
                : null;

            existingAttendance.BreakTime = updatedAttendance.BreakTimeHour != null
                ? new TimeSpan(int.Parse(updatedAttendance.BreakTimeHour!), int.Parse(updatedAttendance.BreakTimeMinutes!), 0)
                : null;

            existingAttendance.Remarks = updatedAttendance.Remarks;
            existingAttendance.UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// 勤怠情報の入力検証
        /// </summary>
        /// <param name="updatedAttendanceList">更新された勤怠情報のリスト</param>
        /// <returns>検証結果（true: 正常, false: エラー）</returns>
        private bool CheckAttendance(List<AttendanceViewModel> updatedAttendanceList)
        {
            // 時間の不正な入力をチェック
            if (updatedAttendanceList.Any(n => (string.IsNullOrEmpty(n.WorkStartTimeHour) != string.IsNullOrEmpty(n.WorkStartTimeMinutes)) ||
                                               (string.IsNullOrEmpty(n.WorkEndTimeHour) != string.IsNullOrEmpty(n.WorkEndTimeMinutes)) ||
                                               (string.IsNullOrEmpty(n.BreakTimeHour) != string.IsNullOrEmpty(n.BreakTimeMinutes))))
            {
                MessageBox.Show("時刻が正しく入力されていません。");
                return false;
            }

            // 出社時間がない場合に、退社時間または休憩時間、備考が入力されているかどうかをチェック
            if (updatedAttendanceList.Any(n => string.IsNullOrEmpty(n.WorkStartTimeHour) && (!string.IsNullOrEmpty(n.WorkEndTimeHour) || !string.IsNullOrEmpty(n.BreakTimeHour) || !string.IsNullOrEmpty(n.Remarks))))
            {
                MessageBox.Show("出社時間を入力してください。");
                return false;
            }

            // 退社時間がある場合に、休憩時間が正しく入力されているかチェック
            if (updatedAttendanceList.Any(n => !string.IsNullOrEmpty(n.WorkEndTimeHour) && string.IsNullOrEmpty(n.BreakTimeHour)))
            {
                MessageBox.Show("休憩時間を入力してください。");
                return false;
            }

            // 出社時間より退社時間が早くないかをチェック
            if (updatedAttendanceList.Any(n => !string.IsNullOrEmpty(n.WorkEndTimeHour) && (CalculateMinutes(n.WorkStartTimeHour, n.WorkStartTimeMinutes) > CalculateMinutes(n.WorkEndTimeHour, n.WorkEndTimeMinutes))))
            {
                MessageBox.Show("退社時間が出社時間より早いです。");
                return false;
            }

            // 稼働時間より休憩時間が多すぎないかをチェック
            if (updatedAttendanceList.Any(n => !string.IsNullOrEmpty(n.BreakTimeHour) && !string.IsNullOrEmpty(n.WorkEndTimeHour) && (CalculateMinutes(n.BreakTimeHour, n.BreakTimeMinutes) > CalculateMinutes(n.WorkEndTimeHour, n.WorkEndTimeMinutes) - CalculateMinutes(n.WorkStartTimeHour, n.WorkStartTimeMinutes))))
            {
                MessageBox.Show("休憩時間が稼働時間を超えています。");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 時間を分に変換
        /// </summary>
        /// <param name="hour">時間</param>
        /// <param name="minute">分</param>
        /// <returns>分に変換された時間</returns>
        private static int CalculateMinutes(string? hour, string? minute)
        {
            int parsedHour = int.TryParse(hour, out int h) ? h : 0;
            int parsedMinute = int.TryParse(minute, out int m) ? m : 0;
            return parsedHour * 60 + parsedMinute;
        }

        /// <summary>
        /// 従業員情報を取得
        /// </summary>
        /// <param name="employeeId">従業員ID</param>
        /// <returns>従業員情報</returns>
        private EmployeeModel LoadEmployee(int employeeId) =>
            _context.Employees.Single(n => n.EmployeeId == employeeId);

        /// <summary>
        /// 勤怠情報を取得
        /// </summary>
        /// <param name="employeeId">従業員ID</param>
        /// <param name="year">対象年</param>
        /// <param name="month">対象月</param>
        /// <returns>勤怠情報リスト</returns>
        private IList<AttendanceViewModel> ListAttendance(int employeeId, int year, int month) =>
            (from day in Enumerable.Range(1, DateTime.DaysInMonth(year, month)).ToList()
             join attendance in _context.Attendances.Where(n => n.EmployeeId == employeeId && n.Year == year && n.Month == month).AsNoTracking()
                 on day equals attendance.Day into attendances
             from attendance in attendances.DefaultIfEmpty()
             select new AttendanceViewModel()
             {
                 AttendanceId = attendance?.EmployeeId,
                 WorkStartTimeHour = attendance?.WorkStartTime.HasValue == true ? attendance.WorkStartTime.Value.Hour.ToString("00") : null,
                 WorkStartTimeMinutes = attendance?.WorkStartTime.HasValue == true ? (Math.Round(attendance.WorkStartTime.Value.Minute / 10.0) * 10).ToString("00") : null,
                 WorkEndTimeHour = attendance?.WorkEndTime.HasValue == true ? attendance.WorkEndTime.Value.Hour.ToString("00") : null,
                 WorkEndTimeMinutes = attendance?.WorkEndTime.HasValue == true ? (Math.Round(attendance.WorkEndTime.Value.Minute / 10.0) * 10).ToString("00") : null,
                 BreakTimeHour = attendance?.BreakTime.HasValue == true ? attendance.BreakTime.Value.Hours.ToString("00") : null,
                 BreakTimeMinutes = attendance?.BreakTime.HasValue == true ? (Math.Round(attendance.BreakTime.Value.Minutes / 10.0) * 10).ToString("00") : null,
                 Remarks = attendance?.Remarks,
                 WorkingHours = attendance?.WorkEndTime.HasValue == true && attendance?.WorkStartTime.HasValue == true
                     ? attendance.WorkEndTime - attendance.WorkStartTime - (attendance.BreakTime ?? TimeSpan.Zero)
                     : null,
                 Year = year,
                 Month = month,
                 Date = attendance?.Day ?? day,
                 DayOfWeek = attendance != null
                     ? new DateTime(attendance.Year, attendance.Month, attendance.Day).ToString("ddd")
                     : new DateTime(year, month, day).ToString("ddd"),
             }).ToList();

        #endregion
    }
}
