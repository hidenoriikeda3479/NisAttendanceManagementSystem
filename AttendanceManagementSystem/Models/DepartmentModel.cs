using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceManagementSystem.Models
{
    /// <summary>
    /// 部署テーブル
    /// </summary>
    [Table("department")]
    public class DepartmentModel
    {
        /// <summary>
        /// 部署ID
        /// </summary>
        [Key]
        [Column("department_id")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// 部署名
        /// </summary>
        [Required]
        [Column("department_name")]
        public string DepartmentName { get; set; } = default!;

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
