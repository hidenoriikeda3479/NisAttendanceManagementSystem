using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.Models
{
    public class AttendanceViewModel : ICloneable
    {
        /// <summary>
        /// ID
        /// </summary>
        public int? AttendanceId { get; set; }

        /// <summary>
        /// 日付
        /// </summary>
        public int Date { get; set; }

        /// <summary>
        /// 曜日
        /// </summary>
        public string? DayOfWeek { get; set; }

        /// <summary>
        /// 出社時
        /// </summary>
        public string? WorkStartTimeHour { get; set; }

        /// <summary>
        /// 出社分
        /// </summary>
        public string? WorkStartTimeMinutes { get; set; }

        /// <summary>
        /// 退社時
        /// </summary>
        public string? WorkEndTimeHour { get; set; }

        /// <summary>
        /// 退社分
        /// </summary>
        public string? WorkEndTimeMinutes { get; set; }

        /// <summary>
        /// 休憩時
        /// </summary>
        public string? BreakTimeHour { get; set; }

        /// <summary>
        /// 休憩分
        /// </summary>
        public string? BreakTimeMinutes { get; set; }

        /// <summary>
        /// 勤務時間
        /// </summary>
        public TimeSpan? Workinghours { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// クローン
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
