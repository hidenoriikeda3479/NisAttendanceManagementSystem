using AttendanceManagementSystem.Data;
using AttendanceManagementSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AttendanceManagementSystem.Views
{
    /// <summary>
    /// 勤怠管理画面表示
    /// </summary>
    public partial class Attendance : Form
    {
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private readonly AttendanceManagementDbContext _context;

        /// <summary>
        /// データグリッドビュー更新前情報保存
        /// </summary>
        List<AttendanceViewModel> viewModels = new List<AttendanceViewModel>();

        /// <summary>
        /// 一か月カレンダー情報取得
        /// </summary>
        List<int> OneMonth = new List<int>();

        //月選択が行われたかを判定するフラグ
        private bool isMonthSelected = false;

        /// <summary>
        /// ログイン画面から受け取った社員ID
        /// </summary>
        private int _id;

        /// <summary>
        /// 社員IDに紐づいている権限ID
        /// </summary>
        private int _permissionId;

        /// <summary>
        /// ログインした社員の情報を取得して権限IDを設定
        /// </summary>
        /// <param name="context">データベースコンテキスト</param>
        /// <param name="id">ログインした社員のID</param>
        public Attendance(AttendanceManagementDbContext context, int id)
        {
            InitializeComponent();
            _context = context;
            _id = id;

            // ログインした社員情報
            var empInfo = _context.Employees.Where(n => n.EmployeeId == _id).Select(n => n.PermissionId);

            // 権限IDを格納
            _permissionId = empInfo.First();

            attendanceDataGridView.CellEnter += new DataGridViewCellEventHandler(Dgv_CellEnter);


        }

        /// <summary>
        /// 初期表示イベント
        /// </summary>
        /// <param name="sender">オブジェクト情報</param>
        /// <param name="e">イベント情報</param>
        private void Attendance_Load(object sender, EventArgs e)
        {
            //データグリッドビュー表示設定
            ConfigureDataGridView();

            //// 現在の年と月の勤怠データを取得
            List<AttendanceViewModel> DisplayAttendanceViewModel = LoadAttendanceData(DateTime.Now.Year, DateTime.Now.Month);

            // DataGridViewにデータをバインドして表示
            attendanceDataGridView.DataSource = DisplayAttendanceViewModel;
        }

        /// <summary>
        /// 検索ボタンイベント
        /// </summary>
        /// <param name="sender">オブジェクト情報</param>
        /// <param name="e">イベント情報</param>    
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //検索対象月の勤怠表示
            LoadMonthlyAttendanceData();
        }

        /// <summary>
        /// 更新ボタンイベント
        /// </summary>
        /// <param name="sender">オブジェクト情報</param>
        /// <param name="e">イベント情報</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool result = false;

            //更新確認のメッセージボックスを表示し、Yes/Noの選択
            DialogResult dLog = MessageBox.Show("更新してよろしいですか？", "確認表示", MessageBoxButtons.YesNo);

            //メッセージボックスで"Yes"を選択した場合
            if (dLog == DialogResult.Yes)
            {
                //勤怠データの更新処理を実行
                result = ProcessAttendanceData();
            }

            if (result) 
            {
                MessageBox.Show("更新が完了しました。");
                _context.SaveChanges();
            }

            //更新されたデータを再取得
            var updatedAttendanceData = LoadAttendanceData(DateTime.Now.Year, DateTime.Now.Month);

            //DataGridViewに再バインド
            attendanceDataGridView.DataSource = updatedAttendanceData;
        }

        /// <summary>
        /// 月の勤怠データを取得
        /// </summary>
        /// <param name="year">取得する年</param>
        /// <param name="month">取得する月</param>
        /// <returns>勤怠データのリスト</returns>
        private List<AttendanceViewModel> LoadAttendanceData(int year, int month)
        {
            //指定した年と月の最終日（その月の日数）を取得
            int daysInMonth = DateTime.DaysInMonth(year, month);

            //指定した社員ID、年、月に該当する勤怠データをデータベースから取得
            var query = _context.Attendances.Where(n => n.EmployeeId == _id &&
                                                   n.Year == year &&
                                                   n.Month == month).ToList();

            TimeSpan nullDate = TimeSpan.Zero;

            //勤怠データをViewModelにマッピング
            var querylist = query.Select(n => new AttendanceViewModel
            {
                AttendanceId = n.EmployeeId,
                WorkStartTimeHour = n.WorkStartTime.HasValue ? n.WorkStartTime.Value.Hour.ToString("00") : "00",
                WorkStartTimeMinutes = n.WorkStartTime.HasValue ?
                (Math.Round(n.WorkStartTime.Value.Minute / 10.0) * 10).ToString("00") : "00", // 10分単位で四捨五入
                WorkEndTimeHour = n.WorkEndTime.HasValue ? n.WorkEndTime.Value.Hour.ToString("00") : "00",
                WorkEndTimeMinutes = n.WorkEndTime.HasValue ?
                (Math.Round(n.WorkEndTime.Value.Minute / 10.0) * 10).ToString("00") : "00", // 10分単位で四捨五入
                BreakTimeHour = n.BreakTime.HasValue ? n.BreakTime.Value.Hours.ToString("00") : "00",
                BreakTimeMinutes = n.BreakTime.HasValue ?
                (Math.Round(n.BreakTime.Value.Minutes / 10.0) * 10).ToString("00") : "00", // 10分単位で四捨五入
                Remarks = n.Remarks,
                Workinghours = n.WorkEndTime - n.WorkStartTime - n.BreakTime,
                Date = n.Day,
                DayOfWeek = (new DateTime(n.Year, n.Month, n.Day).ToString("ddd")),

            });

            //1ヶ月分の日付リストを作成（1日から月末まで）
            OneMonth = Enumerable.Range(1, daysInMonth).ToList();

            //1ヶ月分の日付リストと取得した勤怠データを日付で外部結合し、全日分の勤怠データを作成
            var result = OneMonth
                         .GroupJoin(
                             //勤怠リストのクエリ
                             querylist,
                             //OneMonthのキー（日付）
                             day => day,
                             //querylistのキー(日付)
                             vm => vm.Date,
                             (day, attendanceList) => new
                             {
                                 Date = day,
                                 Attendance = attendanceList.SingleOrDefault()  // 勤怠データがない場合は null
                             })
                         .Select(result => new AttendanceViewModel
                         {
                             //日付と曜日の情報を含めた勤怠データを作成
                             AttendanceId = result.Attendance?.AttendanceId,
                             Date = result.Date,
                             DayOfWeek = (new DateTime(year, month, result.Date)).ToString("ddd"),
                             WorkEndTimeHour = result.Attendance?.WorkEndTimeHour,
                             WorkEndTimeMinutes = result.Attendance?.WorkEndTimeMinutes,
                             WorkStartTimeHour = result.Attendance?.WorkStartTimeHour,
                             WorkStartTimeMinutes = result.Attendance?.WorkStartTimeMinutes,
                             BreakTimeHour = result.Attendance?.BreakTimeHour,
                             BreakTimeMinutes = result.Attendance?.BreakTimeMinutes,
                             Workinghours = result.Attendance?.Workinghours,
                             Remarks = result.Attendance?.Remarks,
                         }).ToList();

            //取得したデータのクローンを作成し、更新前情報として保存
            viewModels = result.Select(n => (AttendanceViewModel)n.Clone()).ToList();

            //管理者権限がある場合はデータグリッドビューを編集可能に設定
            if (_permissionId == 1)
            {
                attendanceDataGridView.ReadOnly = false;
            }
            //管理者権限がない場合はデータグリッドビューを読み取り専用に設定
            else
            {
                attendanceDataGridView.ReadOnly = true;

                //更新ボタンの非表示
                btnUpdate.Visible = false;
            }

            //マッピングされた勤怠データリストを返す
            return result;
        }

        /// <summary>
        /// 選択された月の勤怠データを表示するメソッド
        /// </summary>
        private void LoadMonthlyAttendanceData()
        {
            //dateTimePicker1から選択された年と月の勤怠データを取得
            var result = LoadAttendanceData(SearchDate.Value.Year, SearchDate.Value.Month);

            //取得した勤怠データをデータグリッドビューに反映
            attendanceDataGridView.DataSource = result;

            //現在の年月と選択された年月が異なる場合、データグリッドビューを読み取り専用に設定
            if (DateTime.Now.Year != SearchDate.Value.Year ||
               DateTime.Now.Month != SearchDate.Value.Month)
            {
                attendanceDataGridView.ReadOnly = true;
            }
            //現在の年月と選択された年月が同じ場合、編集可能に設定
            else
            {
                attendanceDataGridView.ReadOnly = false;
            }
        }

        //DateTimePickerのDropDownイベントで月選択モードに切り替え
        private void SearchDate_DropDown(object sender, EventArgs e)
        {
            //月選択モードにするためにCtrl + ↑キーを送信
            SendKeys.Send("^{UP}");

            //月が選択される前にフラグをリセット
            isMonthSelected = false;
        }

        /// <summary>
        /// 勤怠テーブルの処理メソッド
        /// </summary>
        private bool ProcessAttendanceData()
        {
            //勤怠データ用のViewModelインスタンスを作成
            AttendanceViewModel view = new AttendanceViewModel();

            //管理者権限があり、選択された年月が現在の年月と一致する場合の処理
            if (_permissionId == 1 && DateTime.Now.Year == SearchDate.Value.Year &&
               DateTime.Now.Month == SearchDate.Value.Month)
            {
                //DataGridViewの各行をループして処理を行う
                foreach (DataGridViewRow row in attendanceDataGridView.Rows)
                {

                    //データグリッドビューから現在の行の勤怠データを取得
                    view = ViewDataAcquisition(row);

                    //データグリッドビューの入力値からマッチするレコードを取得
                    //AttendanceViewModel updatamatchedrecord = ViewDataSearch(view);

                    //更新前のデータと取得したデータを比較
                    var originalRecord = viewModels.SingleOrDefault(n => n.AttendanceId == view.AttendanceId &&
                                                                         n.Date == view.Date);


                    //勤怠データの入力チェック
                    if (IsAttendanceDataValid(view))
                    {
                        //更新前のレコードが存在しない場合は、新規登録処理を実行
                        if (originalRecord!.AttendanceId == null)
                        {
                            var q = InsertAttendance(view);

                            if (q)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        }

                    }

                    //更新前後のレコードを比較して変更があれば、更新処理を実行
                    if (IsModified(originalRecord!, view))
                    {

                        //データベースから更新対象のレコードを取得
                        var searchtable = _context.Attendances.SingleOrDefault(n => n.EmployeeId == view.AttendanceId &&
                                                                                    n.Year == DateTime.Now.Year &&
                                                                                    n.Month == DateTime.Now.Month &&
                                                                                    n.Day == view.Date);

                        //勤怠データの入力値がすべてnullの場合は削除処理を実行
                        if (DataNullSearch(view))
                        {
                            _context.Attendances.Remove(searchtable!);
                            return true;
                        }
                        //更新対象のレコードが存在し、入力値の変更があれば更新処理を実行
                        else if (searchtable != null)
                        {
                            bool result = UpdateAttendance(searchtable, view);
                            return result;
                           
                        }
                        //出勤中の入力値があれば更新処理を実行
                        else if (searchtable != null && IsWorkStartTimeValid(view))
                        {
                            bool result = UpdateAttendance(searchtable, view);
                            return result;
                        }

                    }

                }
            }

            return false;

        }
        


        /// <summary>
        /// データグリッドビューの行データを取得し、AttendanceViewModel にマッピングするメソッド
        /// </summary>
        /// <param name="row">データグリッドビューの行データ</param>
        /// <returns>取得したデータをマッピングした AttendanceViewModel view</returns>
        private AttendanceViewModel ViewDataAcquisition(DataGridViewRow row)
        {
            AttendanceViewModel view = new AttendanceViewModel();

            //データベース登録情報アリ
            if (row.Cells[0].Value != null && int.Parse(row.Cells[0].Value.ToString()!) > 0)
            {
                view.AttendanceId = int.Parse(row.Cells[0].Value.ToString()!);
                view.Date = int.Parse(row.Cells[1].Value.ToString()!);
                view.DayOfWeek = row.Cells[2].Value?.ToString();
                view.WorkStartTimeHour = row.Cells[3].Value?.ToString();
                view.WorkStartTimeMinutes = row.Cells[4].Value?.ToString();
                view.WorkEndTimeHour = row.Cells[5].Value?.ToString();
                view.WorkEndTimeMinutes = row.Cells[6].Value?.ToString();
                view.BreakTimeHour = row.Cells[7].Value?.ToString();
                view.BreakTimeMinutes = row.Cells[8].Value?.ToString();
                view.Remarks = row.Cells[10].Value?.ToString();
            }
            //データベース登録情報なし
            else
            {
                view.AttendanceId = null;
                view.Date = int.Parse(row.Cells[1].Value.ToString()!);
                view.DayOfWeek = row.Cells[2].Value?.ToString();
                view.WorkStartTimeHour = row.Cells[3].Value?.ToString();
                view.WorkStartTimeMinutes = row.Cells[4].Value?.ToString();
                view.WorkEndTimeHour = row.Cells[5].Value?.ToString();
                view.WorkEndTimeMinutes = row.Cells[6].Value?.ToString();
                view.BreakTimeHour = row.Cells[7].Value?.ToString();
                view.BreakTimeMinutes = row.Cells[8].Value?.ToString();
                view.Remarks = row.Cells[10].Value?.ToString();
            }
            return view;

        }

        /// <summary>
        /// データグリッドビューの入力レコードを取得
        /// </summary>
        /// <param name="view">入力された勤怠データ</param>
        /// <returns>取得した AttendanceViewModel viewdatasearch</returns>
        private AttendanceViewModel ViewDataSearch(AttendanceViewModel view)
        {
            //初期化された AttendanceViewModel インスタンスを作成
            AttendanceViewModel viewdatasearch = new AttendanceViewModel();

            //AttendanceId が存在する場合、入力されたViewModelをそのまま返す
            if (view.AttendanceId != null)
            {
                viewdatasearch = view;
            }
            //AttendanceIdが存在しない場合は、日付情報のみを設定
            else
            {
                viewdatasearch.Date = view.Date;
            }
            return viewdatasearch;
        }

        /// <summary>
        /// 勤怠データの変更があるかどうかをチェックするメソッド
        /// </summary>
        /// <param name="original">変更前の勤怠データ</param>
        /// <param name="updated">変更後の勤怠データ</param>
        /// <returns></returns>
        private bool IsModified(AttendanceViewModel original, AttendanceViewModel updated)
        {

            
            //else if (a)
            //{

            //}

            // 変更があるかセル情報を比較 変更あり=true 変更なし=false
            return original.WorkStartTimeHour != updated.WorkStartTimeHour ||
               original.WorkStartTimeMinutes != updated.WorkStartTimeMinutes ||
               original.WorkEndTimeHour != updated.WorkEndTimeHour ||
               original.WorkEndTimeMinutes != updated.WorkEndTimeMinutes ||
               original.BreakTimeHour != updated.BreakTimeHour ||
               original.BreakTimeMinutes != updated.BreakTimeMinutes ||
               original.Remarks != updated.Remarks;
        }

        /// <summary>
        /// データグリッドビューの値があるかどうかをチェックするメソッド
        /// </summary>
        /// <param name="updated">チェック対象の勤怠データ</param>
        /// <returns>すべての値がnullの場合はtrue、そうでない場合はfalse</returns>
        private bool DataNullSearch(AttendanceViewModel updated)
        {

            if (updated.WorkStartTimeHour == null &&
                updated.WorkStartTimeMinutes == null &&
                updated.WorkEndTimeHour == null &&
                updated.WorkEndTimeMinutes == null &&
                updated.BreakTimeHour == null &&
                updated.BreakTimeMinutes == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 勤怠情報の入力データが有効かどうかを確認するメソッド
        /// </summary>
        /// <param name="updated">確認対象の勤怠情報</param>
        /// <returns>すべての時間情報が入力されていればtrue、そうでなければfalse</returns>
        private bool IsAttendanceDataValid(AttendanceViewModel updated)
        {
            ////入力チェック
            //bool d = false;

            //既存レコード or 新規登録
            if (updated.WorkStartTimeHour != null &&
               updated.WorkStartTimeMinutes != null)
            {
                return true;
            }
            //未登録情報
            else if (updated.WorkEndTimeHour == null &&
                     updated.WorkEndTimeMinutes == null)
            {
                return false;
            }
            //入力ミス
            else
            {


                //d = true;
                return true;
            }



            //return updated.WorkStartTimeHour != null &&
            //       updated.WorkStartTimeMinutes != null &&
            //       updated.WorkEndTimeHour != null &&
            //       updated.WorkEndTimeMinutes != null &&
            //       updated.BreakTimeHour != null &&
            //       updated.BreakTimeMinutes != null;
        }



        /// <summary>
        /// 出勤中の勤怠情報の入力データが有効かどうかを確認するメソッド
        /// </summary>
        /// <param name="updated">確認対象の勤怠情報</param>
        /// <returns>すべての時間情報が入力されていればtrue、そうでなければfalse</returns>
        private bool IsWorkStartTimeValid(AttendanceViewModel updated)
        {
            return updated.WorkStartTimeHour != null &&
                  updated.WorkStartTimeMinutes != null;
        }
        /// <summary>
        /// 勤怠情報の更新処理
        /// </summary>
        /// <param name="searchtable">更新対象の勤怠情報</param>
        /// <param name="updatedRecord">更新内容を持つ勤怠データ</param>
        private bool UpdateAttendance(AttendanceModel searchtable, AttendanceViewModel updatedRecord)
        {



            //出社時間が入力されていて、退社時間が未入力の場合
            if (updatedRecord.WorkStartTimeHour != null &&
                        updatedRecord.WorkStartTimeMinutes != null &&
                        updatedRecord.WorkEndTimeHour == null &&
                        updatedRecord.WorkEndTimeMinutes == null)
            {
                //出社時間のみ更新
                searchtable.WorkStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, updatedRecord.Date,
                                            int.Parse(updatedRecord.WorkStartTimeHour!), int.Parse(updatedRecord.WorkStartTimeMinutes!), 0);
                return true;
            }

            //出社+退社
            else if (updatedRecord.WorkStartTimeHour != null &&
                    updatedRecord.WorkStartTimeMinutes != null &&
                    updatedRecord.WorkEndTimeHour != null &&
                    updatedRecord.WorkEndTimeMinutes != null &&
                    updatedRecord.BreakTimeHour == null &&
                    updatedRecord.BreakTimeMinutes == null)
            {
                //勤怠データを更新
                searchtable.WorkStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, updatedRecord.Date,
                                                         int.Parse(updatedRecord.WorkStartTimeHour!), int.Parse(updatedRecord.WorkStartTimeMinutes!), 0);
                searchtable.WorkEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, updatedRecord.Date,
                                                       int.Parse(updatedRecord.WorkEndTimeHour!), int.Parse(updatedRecord.WorkEndTimeMinutes!), 0);
                return true;
            }
            //出社+休憩
            else if (updatedRecord.WorkStartTimeHour != null &&
                    updatedRecord.WorkStartTimeMinutes != null &&
                    updatedRecord.WorkEndTimeHour == null &&
                    updatedRecord.WorkEndTimeMinutes == null &&
                    updatedRecord.BreakTimeHour != null &&
                    updatedRecord.BreakTimeMinutes != null)
            {
                //勤怠データを更新
                searchtable.WorkStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, updatedRecord.Date,
                                                         int.Parse(updatedRecord.WorkStartTimeHour!), int.Parse(updatedRecord.WorkStartTimeMinutes!), 0);
                searchtable.BreakTime = new TimeSpan(int.Parse(updatedRecord.BreakTimeHour!), int.Parse(updatedRecord.BreakTimeMinutes!), 0);
                return true;
            }
            
            else
            {
                //勤怠データを更新
                searchtable.WorkStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, updatedRecord.Date,
                                                         int.Parse(updatedRecord.WorkStartTimeHour!), int.Parse(updatedRecord.WorkStartTimeMinutes!), 0);
                searchtable.WorkEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, updatedRecord.Date,
                                                       int.Parse(updatedRecord.WorkEndTimeHour!), int.Parse(updatedRecord.WorkEndTimeMinutes!), 0);
                searchtable.BreakTime = new TimeSpan(int.Parse(updatedRecord.BreakTimeHour!), int.Parse(updatedRecord.BreakTimeMinutes!), 0);
                searchtable.Remarks = updatedRecord.Remarks;

                
            }


            //出社時間と退社時間の時刻逆転チェック
            if (int.Parse(updatedRecord.WorkStartTimeHour!) > int.Parse(updatedRecord.WorkEndTimeHour!) ||
                int.Parse(updatedRecord.WorkStartTimeHour!) == int.Parse(updatedRecord.WorkEndTimeHour!) &&
                int.Parse(updatedRecord.WorkStartTimeMinutes!) > int.Parse(updatedRecord.WorkEndTimeMinutes!))
            {
                MessageBox.Show("出社時間の入力をやり直してください");
                return false;
            }


            return true;
        }


        /// <summary>
        /// 勤怠情報の登録処理
        /// </summary>
        /// <param name="updatamatchedrecord">登録内容を持つ勤怠データ</param>
        private bool InsertAttendance(AttendanceViewModel updatamatchedrecord)
        {

            //出社のみ登録
            if (updatamatchedrecord.WorkStartTimeHour != null &&
                updatamatchedrecord.WorkStartTimeMinutes != null &&
                updatamatchedrecord.WorkEndTimeHour == null &&
                updatamatchedrecord.WorkEndTimeMinutes == null &&
                updatamatchedrecord.BreakTimeHour == null &&
                updatamatchedrecord.BreakTimeMinutes == null)
            {
                var newAttendance = new AttendanceModel
                {
                    EmployeeId = _id,
                    Year = DateTime.Now.Year,
                    Month = DateTime.Now.Month,
                    Day = updatamatchedrecord.Date,
                    WorkStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, updatamatchedrecord.Date,
                                             int.Parse(updatamatchedrecord.WorkStartTimeHour!),
                                             int.Parse(updatamatchedrecord.WorkStartTimeMinutes!), 0, 0),
                    Remarks = updatamatchedrecord.Remarks,

                    BreakTime = TimeSpan.Zero,

                    CreatedAt = DateTime.Now,

                    UpdatedAt = DateTime.Now

                    

                };

                // 新しい従業員データを追加
                _context.Attendances.Add(newAttendance);

                //isProcessingCompleted = true;

            }
            //出社+退社+休憩登録
            else if (updatamatchedrecord.WorkStartTimeHour != null &&
                     updatamatchedrecord.WorkStartTimeMinutes != null &&
                     updatamatchedrecord.WorkEndTimeHour != null &&
                     updatamatchedrecord.WorkEndTimeMinutes != null &&
                     updatamatchedrecord.BreakTimeHour != null &&
                     updatamatchedrecord.BreakTimeMinutes != null)
            {
                var newAttendance = new AttendanceModel
                {
                    EmployeeId = _id,
                    Year = DateTime.Now.Year,
                    Month = DateTime.Now.Month,
                    Day = updatamatchedrecord.Date,
                    WorkStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, updatamatchedrecord.Date,
                                             int.Parse(updatamatchedrecord.WorkStartTimeHour!),
                                             int.Parse(updatamatchedrecord.WorkStartTimeMinutes!), 0, 0),
                    WorkEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, updatamatchedrecord.Date,
                                           int.Parse(updatamatchedrecord.WorkEndTimeHour!),
                                           int.Parse(updatamatchedrecord.WorkEndTimeMinutes!), 0, 0),
                    BreakTime = new TimeSpan(int.Parse(updatamatchedrecord.BreakTimeHour!),
                                         int.Parse(updatamatchedrecord.BreakTimeMinutes!), 0),
                };

                if (int.Parse(updatamatchedrecord.WorkStartTimeHour!) < int.Parse(updatamatchedrecord.WorkEndTimeHour!))
                {
                    // 勤務時間算出
                    var a = newAttendance.WorkEndTime - newAttendance.WorkStartTime - newAttendance.BreakTime;

                    //勤務時間の判定
                    if (a.Value.TotalMinutes > 0)
                    {
                        //新しい従業員データを追加
                        _context.Attendances.Add(newAttendance);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            //出社+休憩
            else if (updatamatchedrecord.WorkStartTimeHour != null &&
                    updatamatchedrecord.WorkStartTimeMinutes != null &&
                    updatamatchedrecord.WorkEndTimeHour == null &&
                    updatamatchedrecord.WorkEndTimeMinutes == null &&
                    updatamatchedrecord.BreakTimeHour != null &&
                    updatamatchedrecord.BreakTimeMinutes != null)
            {
                var newAttendance = new AttendanceModel
                {
                    EmployeeId = _id,
                    Year = DateTime.Now.Year,
                    Month = DateTime.Now.Month,
                    Day = updatamatchedrecord.Date,
                    WorkStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, updatamatchedrecord.Date,
                                             int.Parse(updatamatchedrecord.WorkStartTimeHour!),
                                             int.Parse(updatamatchedrecord.WorkStartTimeMinutes!), 0, 0),
                    BreakTime = new TimeSpan(int.Parse(updatamatchedrecord.BreakTimeHour!),
                                         int.Parse(updatamatchedrecord.BreakTimeMinutes!), 0),

                    Remarks = updatamatchedrecord.Remarks,

                    CreatedAt = DateTime.Now,

                    UpdatedAt = DateTime.Now

                };




                //新しい従業員データを追加
                _context.Attendances.Add(newAttendance);
            }

            //出社+退社
            else if (updatamatchedrecord.WorkStartTimeHour != null &&
                    updatamatchedrecord.WorkStartTimeMinutes != null &&
                    updatamatchedrecord.WorkEndTimeHour != null &&
                    updatamatchedrecord.WorkEndTimeMinutes != null &&
                    updatamatchedrecord.BreakTimeHour == null &&
                    updatamatchedrecord.BreakTimeMinutes == null)
            {
                var newAttendance = new AttendanceModel
                {
                    EmployeeId = _id,
                    Year = DateTime.Now.Year,
                    Month = DateTime.Now.Month,
                    Day = updatamatchedrecord.Date,
                    WorkStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, updatamatchedrecord.Date,
                                             int.Parse(updatamatchedrecord.WorkStartTimeHour!),
                                             int.Parse(updatamatchedrecord.WorkStartTimeMinutes!), 0, 0),
                    WorkEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, updatamatchedrecord.Date,
                                           int.Parse(updatamatchedrecord.WorkEndTimeHour!),
                                           int.Parse(updatamatchedrecord.WorkEndTimeMinutes!), 0, 0),

                    BreakTime = TimeSpan.Zero,
                };

                if (int.Parse(updatamatchedrecord.WorkStartTimeHour!) < int.Parse(updatamatchedrecord.WorkEndTimeHour!))
                {
                    // 勤務時間算出
                    var a = newAttendance.WorkEndTime - newAttendance.WorkStartTime - newAttendance.BreakTime;

                    //勤務時間の判定
                    if (a.Value.TotalMinutes > 0)
                    {
                        //新しい従業員データを追加
                        _context.Attendances.Add(newAttendance);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                ////新しい従業員データを追加
                //_context.Attendances.Add(newAttendance);

            }
            else
            {
                return false;
            }

            return false;


        }
        /// <summary>
        /// カレンダーフォーマット設定
        /// </summary>
        /// <param name="sender">オブジェクト情報</param>
        /// <param name="e">イベント情報</param>
        private void SearchDate_ValueChanged(object sender, EventArgs e)
        {

            if (SearchDate.Focused && !isMonthSelected)
            {
                //月が選択されたことをマーク
                isMonthSelected = true;

                // Enterキーを送信してドロップダウンを閉じる
                SendKeys.Send("{ENTER}");
            }
        }

        /// <summary>
        /// 土曜日と日曜日の色付け 　
        /// </summary>
        /// <param name="sender">オブジェクト情報</param>
        /// <param name="e">イベント情報</param>
        private void attendanceDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //曜日の列をターゲットにする
            if (attendanceDataGridView.Columns[e.ColumnIndex].DataPropertyName == "DayOfWeek")
            {
                //曜日の値を取得
                string? dayOfWeek = e.Value?.ToString();

                //土日の場合に背景色を変更
                if (dayOfWeek == "土")
                {
                    //土曜日のカラー
                    e.CellStyle!.BackColor = Color.LightBlue;
                }
                else if (dayOfWeek == "日")
                {
                    //日曜日のカラー
                    e.CellStyle!.BackColor = Color.LightCoral;
                }
            }
        }

        /// <summary>
        /// ヘッダーの分割
        /// </summary>
        /// <param name="sender">オブジェクト情報</param>
        /// <param name="e">イベント情報</param>
        private void attendanceDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //編集箇所選択
            if (e.RowIndex == -1 && (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 ||
                e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8))
            {
                //自前で描画したいので、既存の描画は無効化する
                e.Paint(e.CellBounds, DataGridViewPaintParts.None);
                e.Handled = true;

                //描画すべき領域の取得
                var rect = attendanceDataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                rect.Width -= 1;
                rect.Height -= 1;

                //外枠を描画する
                e.Graphics!.DrawRectangle(new Pen(SystemColors.ControlDark), rect);

                //セルを2分割してテキストを描画
                var separatedHeight = rect.Height / 2;  // 上下2分割の高さを計算

                if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
                {
                    //上部に「出社」を表示
                    var topRect = new Rectangle(rect.X, rect.Y, rect.Width, separatedHeight);

                    TextRenderer.DrawText(e.Graphics, "出社",
                        new Font(attendanceDataGridView.ColumnHeadersDefaultCellStyle.Font.FontFamily, 14, FontStyle.Bold),
                        topRect,
                        SystemColors.ControlText,
                        TextFormatFlags.VerticalCenter |
                        TextFormatFlags.HorizontalCenter |
                        TextFormatFlags.EndEllipsis);

                    //下部に「時間」または「分」を表示
                    var bottomRect = new Rectangle(rect.X, rect.Y + separatedHeight, rect.Width, separatedHeight);

                    string bottomText = e.ColumnIndex == 3 ? "時間" : "分";

                    TextRenderer.DrawText(e.Graphics, bottomText,
                        new Font(attendanceDataGridView.ColumnHeadersDefaultCellStyle.Font.FontFamily, 14, FontStyle.Bold),
                        bottomRect,
                        SystemColors.ControlText,
                        TextFormatFlags.VerticalCenter |
                        TextFormatFlags.HorizontalCenter |
                        TextFormatFlags.EndEllipsis);

                    //下部の仕切り線の描画
                    e.Graphics.DrawLine(new Pen(SystemColors.ControlDark),
                                        rect.Left,
                                        rect.Bottom - separatedHeight,
                                        rect.Right,
                                        rect.Bottom - separatedHeight);
                }
                if (e.ColumnIndex == 5 || e.ColumnIndex == 6)
                {
                    //上部に「退社」を表示
                    var topRect = new Rectangle(rect.X, rect.Y, rect.Width, separatedHeight);

                    TextRenderer.DrawText(e.Graphics, "退社",
                        new Font(attendanceDataGridView.ColumnHeadersDefaultCellStyle.Font.FontFamily, 14, FontStyle.Bold),
                        topRect,
                        SystemColors.ControlText,
                        TextFormatFlags.VerticalCenter |
                        TextFormatFlags.HorizontalCenter |
                        TextFormatFlags.EndEllipsis);

                    //下部に「時間」または「分」を表示
                    var bottomRect = new Rectangle(rect.X, rect.Y + separatedHeight, rect.Width, separatedHeight);

                    string bottomText = e.ColumnIndex == 5 ? "時間" : "分";

                    TextRenderer.DrawText(e.Graphics, bottomText,
                        new Font(attendanceDataGridView.ColumnHeadersDefaultCellStyle.Font.FontFamily, 14, FontStyle.Bold),
                        bottomRect,
                        SystemColors.ControlText,
                        TextFormatFlags.VerticalCenter |
                        TextFormatFlags.HorizontalCenter |
                        TextFormatFlags.EndEllipsis);

                    //下部の仕切り線の描画
                    e.Graphics.DrawLine(new Pen(SystemColors.ControlDark),
                                        rect.Left,
                                        rect.Bottom - separatedHeight,
                                        rect.Right,
                                        rect.Bottom - separatedHeight);
                }
                if (e.ColumnIndex == 7 || e.ColumnIndex == 8)
                {
                    //上部に「休憩」を表示
                    var topRect = new Rectangle(rect.X, rect.Y, rect.Width, separatedHeight);

                    TextRenderer.DrawText(e.Graphics, "休憩",
                        new Font(attendanceDataGridView.ColumnHeadersDefaultCellStyle.Font.FontFamily, 14, FontStyle.Bold),
                        topRect,
                        SystemColors.ControlText,
                        TextFormatFlags.VerticalCenter |
                        TextFormatFlags.HorizontalCenter |
                        TextFormatFlags.EndEllipsis);

                    //下部に「時間」または「分」を表示
                    var bottomRect = new Rectangle(rect.X, rect.Y + separatedHeight, rect.Width, separatedHeight);

                    string bottomText = e.ColumnIndex == 7 ? "時間" : "分";

                    TextRenderer.DrawText(e.Graphics, bottomText,
                        new Font(attendanceDataGridView.ColumnHeadersDefaultCellStyle.Font.FontFamily, 14, FontStyle.Bold),
                        bottomRect,
                        SystemColors.ControlText,
                        TextFormatFlags.VerticalCenter |
                        TextFormatFlags.HorizontalCenter |
                        TextFormatFlags.EndEllipsis);

                    //下部の仕切り線の描画
                    e.Graphics.DrawLine(new Pen(SystemColors.ControlDark),
                                        rect.Left,
                                        rect.Bottom - separatedHeight,
                                        rect.Right,
                                        rect.Bottom - separatedHeight);
                }

            }
        }

        /// <summary>
        /// データグリッドビュー表示設定
        /// </summary>
        private void ConfigureDataGridView()
        {
            //行の自動追加をオフ
            attendanceDataGridView.AllowUserToAddRows = false;

            //タイムピッカー表示設定
            SearchDate.Format = DateTimePickerFormat.Custom;

            //フォーマット設定
            SearchDate.CustomFormat = "yyyy年MM月";

            //セルの高さを自動調整
            attendanceDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //ヘッダーの高さを固定にしてリサイズを禁止
            attendanceDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            //ヘッダーの高さを設定
            attendanceDataGridView.ColumnHeadersHeight = 60;

            //DataGridView2の列の幅をユーザーが変更できないようにする
            attendanceDataGridView.AllowUserToResizeColumns = false;
        }

        private void attendanceDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        /// <summary>
        /// コンボボックス変更前値格納
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void attendanceDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //セルの編集が始まる前に、元の値を保持する
            var originalValue = attendanceDataGridView[e.ColumnIndex, e.RowIndex].Value;
        }

        private void Dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (attendanceDataGridView[e.ColumnIndex, e.RowIndex].GetType().Equals(typeof(DataGridViewComboBoxCell)))
            {
                attendanceDataGridView.BeginEdit(false);
                ((DataGridViewComboBoxEditingControl)attendanceDataGridView.EditingControl).DroppedDown = true;
            }

        }
    }
}



    


        
    

