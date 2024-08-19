using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceManagementSystem.Models
{
    /// <summary>
    /// 権限マスタ
    /// </summary>
    [Table("permissions")]
    public class PermissionModel
    {
        /// <summary>
        /// 権限ID
        /// </summary>
        [Key]
        [Column("permission_id")]
        public int PermissionId { get; set; }

        /// <summary>
        /// 権限名
        /// </summary>
        [Required]
        [Column("permission_name")]
        [MaxLength(255)]
        public string PermissionName { get; set; } = default!;

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
