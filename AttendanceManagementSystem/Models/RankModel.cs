using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceManagementSystem.Models
{
    /// <summary>
    /// ランクマスタ
    /// </summary>
    [Table("rank")]
    public class RankModel
    {
        /// <summary>
        /// ランクID
        /// </summary>
        [Key]
        [Column("rank_id")]
        public int RankId { get; set; }

        /// <summary>
        /// 時給
        /// </summary>
        [Required]
        [Column("hourly_pay")]
        public int HourlyPay { get; set; }

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
