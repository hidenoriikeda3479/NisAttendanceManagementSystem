using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.Common.CustomControls
{
    /// <summary>
    /// 年月選択用のカスタム DateTimePicker コントロール
    /// </summary>
    public class YearMonthPicker : DateTimePicker
    {
        /// <summary>
        /// 月が選択されたかどうかを判定するためのフラグ
        /// </summary>
        private bool isMonthSelected;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public YearMonthPicker()
        {
            // カレンダー表示で年月のみを選択可能に設定
            this.Format = DateTimePickerFormat.Custom;

            // 年月のみ表示
            this.CustomFormat = "yyyy年MM月";

            // カレンダー表示を許可
            this.ShowUpDown = false;

            // 初期値として現在の年月を設定
            this.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            // 選択可能な最大日付を現在に設定
            this.MaxDate = DateTime.Now;

            // カレンダーが閉じられたときに日付を1日にリセット
            this.CloseUp += new EventHandler(OnCloseUp);

            // DropDownイベントを登録
            this.DropDown += YearMonthPicker_DropDown;
        }

        /// <summary>
        /// カレンダーが閉じられた際に日を1日にリセット
        /// </summary>
        /// <param name="sender">イベントを発生させたオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void OnCloseUp(object sender, EventArgs e)
        {
            // 日付を常にその月の1日に固定
            this.Value = new DateTime(this.Value.Year, this.Value.Month, 1);
        }

        /// <summary>
        /// 選択された年月を DateTime 型で取得
        /// </summary>
        /// <returns>選択された年月（常にその月の1日）</returns>
        public DateTime GetSelectedYearMonth()
        {
            return new DateTime(this.Value.Year, this.Value.Month, 1);
        }

        /// <summary>
        /// DropDownイベント発生時に月選択モードに切り替える
        /// </summary>
        /// <param name="sender">イベント発生元のオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void YearMonthPicker_DropDown(object sender, EventArgs e)
        {
            // 月選択モードにするためにCtrl + ↑キーを送信
            SendKeys.Send("^{UP}");

            // 月が選択される前にフラグをリセット
            isMonthSelected = false;
        }
    }
}
