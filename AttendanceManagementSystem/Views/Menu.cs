using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Models;
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
    /// メニュー画面
    /// </summary>
    public partial class Menu : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// ログイン画面から受け取った社員ID
        /// </summary>
        private int _id;

        /// <summary>
        /// 社員IDに紐づいている権限ID
        /// </summary>
        private int _permissionId;

        /// <summary>
        /// メニュー画面
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        /// <param name="id">社員ID</param>
        public Menu(AttendanceManagementDbContext context, int id)
        {
            InitializeComponent();
            _context = context;
            _id = id;

            // 現在時刻を取得
            DateTime now = DateTime.Now;
            string lblText = AttendanceCheck(now);

            var per = _context.Employees.Single(n => n.EmployeeId == _id);

            // 権限IDを格納
            _permissionId = per.PermissionId;

            // 管理者がログインすると管理ボタン表示
            if (_permissionId == 1)
            {
                btnAdminMenu.Visible = true;
            }

            // 当日退勤済みなら退勤中の表示にする
            if(lblText == "退勤済")
            {
                lblText = "退勤中";
            }

            // ラベルに勤務状態を表示する
            lblStatus.Text = lblText;
        }

        #region

        /// <summary>
        /// シフトボタン
        /// </summary>
        /// <param name="sender">コントロール情報</param>
        /// <param name="e">イベント情報</param>
        private void btnShiftManagement_Click(object sender, EventArgs e)
        {
            // シフト画面へ遷移
            var shift = new Shift(_context, _permissionId);
            shift.Show();
        }

        /// <summary>
        /// 給料ボタン
        /// </summary>
        /// <param name="sender">コントロール情報</param>
        /// <param name="e">イベント情報</param>
        private void btnSalaryManagement_Click(object sender, EventArgs e)
        {
            bool salaryflag = true;

            // 給料画面へ遷移
            var salary = new TotalAmountPaid(_context, _id , salaryflag);
            salary.Show();
        }

        /// <summary>
        /// 勤怠ボタン
        /// </summary>
        /// <param name="sender">コントロール情報</param>
        /// <param name="e">イベント情報</param>
        private void btnAttendanceManagement_Click(object sender, EventArgs e)
        {
            // 勤怠画面へ遷移
            var attendance = new Attendance(_context, _id, _id);
            attendance.Show();
        }

        /// <summary>
        /// 管理ボタン
        /// </summary>
        /// <param name="sender">コントロール情報</param>
        /// <param name="e">イベント情報</param>
        private void btnAdminMenu_Click(object sender, EventArgs e)
        {
            // 管理画面へ遷移
            var managementMenu = new ManagementMenu(_context, _id);
            managementMenu.Show();
            Hide();
        }

        /// <summary>
        /// 出勤/退勤ボタン
        /// </summary>
        /// <param name="sender">コントロール情報</param>
        /// <param name="e">イベント情報</param>
        private void btnAttendanceDeparture_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;　// 現在の年月日時間を取得
            string check = AttendanceCheck(now);　// 勤怠状態を取得

            if (check == "出勤中")
            {
                // 出勤中ならメッセージボックスを表示
                DialogResult dLog = MessageBox.Show("退勤してよろしいですか？","Menu",MessageBoxButtons.YesNo);

                if (dLog == DialogResult.Yes) // メッセージボックスで"Yes"を選択した場合
                {
                    // 更新する対象のレコードを取得
                    var reslut = _context.Attendances.Single(n => n.EmployeeId == _id &&
                                                              n.Year == now.Year && n.Month == now.Month && n.Day == now.Day);

                    // 10分切り捨てで開始時間を設定
                    var workEndTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute / 10 * 10, 0);

                    if (reslut.WorkStartTime  >= workEndTime)
                    {
                        MessageBox.Show("勤務終了時間が勤務開始時間と同じです。勤務時間が設定されていません。");
                        return;
                    }

                    // 退勤時間と更新時間を追加
                    reslut.WorkEndTime = workEndTime;
                    reslut.UpdatedAt = now;

                    // ラベルテキストを変更
                    lblStatus.Text = "退勤中";
                }
            }
            else if (check == "退勤済")
            {
                // 当日既に退勤していた場合は処理せず退勤済みのメッセージを表示
                MessageBox.Show("本日はすでに退勤済みです。");
            }
            else
            {
                // 勤怠データの作成
                var newAttendance = new AttendanceModel()
                {
                    EmployeeId = _id,
                    Year = now.Year,
                    Month = now.Month,
                    Day = now.Day,
                    
                    // 10分切り上げで開始時間を設定
                    WorkStartTime = now.Minute % 10 == 0
                                    ? new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0)
                                    : new DateTime(now.Year, now.Month, now.Day, now.Hour, ((now.Minute / 10) + 1) * 10, 0),
                    CreatedAt = DateTime.Now
                };

                // ラベルテキストを変更
                lblStatus.Text = "出勤中";

                // 勤怠データを追加
                _context.Attendances.Add(newAttendance);
            }
            // データをコミット
            _context.SaveChanges();
        }

        #endregion

        /// <summary>
        /// 勤務状態の判断
        /// </summary>
        /// <param name="now">現在時刻</param>
        /// <returns>勤怠状態の文字列</returns>
        private string AttendanceCheck(DateTime now)
        {
            // 当日の勤怠レコード件数を取得
            int attendanceRecord = _context.Attendances.Where(n => n.EmployeeId == _id &&
                                                              n.Year == now.Year && n.Month == now.Month && n.Day == now.Day).Count();
            // 当日のレコードがあるか
            if (attendanceRecord > 0) 
            {
                // 退勤の情報がnullかどうか
                var check = _context.Attendances.Any(n => n.EmployeeId == _id &&
                                                                    n.Year == now.Year && n.Month == now.Month && n.Day == now.Day
                                                                    && n.WorkEndTime.HasValue);
                // nullなら出勤中の文字列を返す
                if (!check) 
                {
                    return "出勤中";
                }
                // そうでなければ退勤済を返す
                else
                {
                    return "退勤済";
                }
            }
            // レコードがなければ退勤中を返す
            return "退勤中";
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            int adminId = 2;
            var shift = new Shift(_context, adminId);
            shift.Show();
        }
    }
}
