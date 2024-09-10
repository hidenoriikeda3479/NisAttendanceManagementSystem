using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceManagementSystem.Models
{
    /// <summary>
    /// 勤怠テーブル
    /// </summary>
    [Table("attendance")]
    public class AttendanceModel
    {
        /// <summary>
        /// 従業員ID
        /// </summary>
        [Required]
        [Column("employee_id")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        [Required]
        [Column("year")]
        public int Year { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        [Required]
        [Column("month")]
        public int Month { get; set; }

        /// <summary>
        /// 日
        /// </summary>
        [Required]
        [Column("day")]
        public int Day { get; set; }

        /// <summary>
        /// 出社時間
        /// </summary>
        [Column("work_start_time")]
        public DateTime? WorkStartTime { get; set; }

        /// <summary>
        /// 退社時間
        /// </summary>
        [Column("work_end_time")]
        public DateTime? WorkEndTime { get; set; }

        /// <summary>
        /// 休憩時間
        /// </summary>
        [Column("break_time")]
        public TimeSpan? BreakTime { get; set; }

        /// <summary>
        /// 備考
        /// </summary>
        [Column("remarks")]
        public string? Remarks { get; set; }

        /// <summary>
        /// 作成日時
        /// </summary>
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        [Column("update_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
