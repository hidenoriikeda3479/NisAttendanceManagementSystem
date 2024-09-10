using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceManagementSystem.Models
{
    /// <summary>
    /// 従業員テーブル
    /// </summary>
    [Table("employees")]
    public class EmployeeModel
    {
        /// <summary>
        /// 従業員ID
        /// </summary>
        [Key]
        [Column("employee_id")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// 従業員名
        /// </summary>
        [Required]
        [Column("employee_name")]
        [MaxLength(255)]
        public string EmployeeName { get; set; } = default!;

        /// <summary>
        /// 性別
        /// </summary>
        [Required]
        [Column("gender")]
        public int Gender { get; set; }

        /// <summary>
        /// パスワード
        /// </summary>
        [Required]
        [Column("password")]
        public string Password { get; set; } = default!;

        /// <summary>
        /// 電話番号
        /// </summary>
        [Required]
        [Column("phone_number")]
        [MaxLength(11)]
        public string PhoneNumber { get; set; } = default!;

        /// <summary>
        /// 郵便番号
        /// </summary>
        [Required]
        [Column("post_code")]
        [MaxLength(7)]
        public string PostCode { get; set; } = default!;

        /// <summary>
        /// 住所
        /// </summary>
        [Required]
        [Column("address")]
        [MaxLength(255)]
        public string Address { get; set; } = default!;

        /// <summary>
        /// 建物名
        /// </summary>
        [Column("building_name")]
        [MaxLength(255)]
        public string? BuildingName { get; set; }

        /// <summary>
        /// 生年月日
        /// </summary>
        [Required]
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// ランクID
        /// </summary>
        [Required]
        [Column("rank_id")]
        public int RankId { get; set; }

        /// <summary>
        /// シフトID
        /// </summary>
        [Required]
        [Column("shift_id")]
        public int ShiftId { get; set; }

        /// <summary>
        /// 入社日
        /// </summary>
        [Required]
        [Column("hire_date")]
        public DateTime HireDate { get; set; }

        /// <summary>
        /// 退社日
        /// </summary>
        [Column("resign_date")]
        public DateTime? ResignDate { get; set; }

        /// <summary>
        /// 権限ID
        /// </summary>
        [Required]
        [Column("permission_id")]
        public int PermissionId { get; set; }

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
