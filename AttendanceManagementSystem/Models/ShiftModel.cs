using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceManagementSystem.Models
{
    /// <summary>
    /// シフトマスタ
    /// </summary>
    [Table("shift")]
    public class ShiftModel
    {
        /// <summary>
        /// シフトID
        /// </summary>
        [Key]
        [Column("shift_id")]
        public int ShiftId { get; set; }

        /// <summary>
        /// シフト種別
        /// </summary>
        [Required]
        [Column("shift_type_name")]
        [MaxLength(255)]
        public string ShiftTypeName { get; set; } = default!;

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
