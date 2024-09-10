using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceManagementSystem.Models
{
    /// <summary>
    /// シフト管理テーブル
    /// </summary>
    [Table("shift_management")]
    public class ShiftManagementModel
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
