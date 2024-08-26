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
    public partial class Menu : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// ログイン画面から受け取った社員ID
        /// </summary>
        private string _id;

        /// <summary>
        /// 社員IDに紐づいている権限ID
        /// </summary>
        private int _permissionId;

        /// <summary>
        /// メニュー画面
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        /// <param name="id">社員ID</param>
        public Menu(AttendanceManagementDbContext context, string id)
        {
            InitializeComponent();
            _context = context;
            _id = id;
            // 現在時刻を取得
            DateTime now = DateTime.Now;
            string lblText = AttendanceCheck(now);

            // ログインした社員情報
            var empInfo = _context.Employees.Where(n => n.EmployeeId == int.Parse(_id)).Select(n => n.PermissionId).ToList();

            // 権限IDを格納
            _permissionId = empInfo.First();

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

        /// <summary>
        /// ロードイベント
        /// </summary>
        /// <param name="sender">コントロール情報</param>
        /// <param name="e">イベント情報</param>
        private void Menu_Load(object sender, EventArgs e)
        {
            // ロード時に画面サイズ固定
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
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
            // var shift = new Shift(_context,_permissionId.ToString());
            // shift.Show();
        }

        /// <summary>
        /// 給料ボタン
        /// </summary>
        /// <param name="sender">コントロール情報</param>
        /// <param name="e">イベント情報</param>
        private void btnSalaryManagement_Click(object sender, EventArgs e)
        {
            // 給料画面へ遷移
            // var salary = new Salary(_context, _Id);
            // salary.show();
        }

        /// <summary>
        /// 勤怠ボタン
        /// </summary>
        /// <param name="sender">コントロール情報</param>
        /// <param name="e">イベント情報</param>
        private void btnAttendanceManagement_Click(object sender, EventArgs e)
        {
            // 勤怠画面へ遷移
            // var attendance = new Attendance(_context, _permissionId.ToString(), _Id);
            // attendance.show();
        }

        /// <summary>
        /// 管理ボタン
        /// </summary>
        /// <param name="sender">コントロール情報</param>
        /// <param name="e">イベント情報</param>
        private void btnAdminMenu_Click(object sender, EventArgs e)
        {
            var managementMenu = new ManagementMenu(_context, _permissionId.ToString());
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
                    var reslut = _context.Attendances.Single(n => n.EmployeeId == int.Parse(_id) &&
                                                              n.Year == now.Year && n.Month == now.Month && n.Day == now.Day);
                    // 退勤時間と更新時間を追加
                    reslut.WorkEndTime = now;
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
                    EmployeeId = int.Parse(_id),
                    Year = now.Year,
                    Month = now.Month,
                    Day = now.Day,
                    WorkStartTime = now,
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
            int attendanceRecord = _context.Attendances.Where(n => n.EmployeeId == int.Parse(_id) &&
                                                              n.Year == now.Year && n.Month == now.Month && n.Day == now.Day).Count();
            // 当日のレコードがあるか
            if (attendanceRecord > 0) 
            {
                // 退勤の情報がnullかどうか
                var check = _context.Attendances.Any(n => n.EmployeeId == int.Parse(_id) &&
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
    }
}
