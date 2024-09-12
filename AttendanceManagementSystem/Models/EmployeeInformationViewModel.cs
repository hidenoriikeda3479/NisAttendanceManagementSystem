using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.Models
{
    public class EmployeeInformationViewModel
    {
        /// <summary>
        /// 従業員ID
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 従業員名
        /// </summary>
        public string EmployeeName { get; set; } = default!;

        /// <summary>
        /// 性別
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 電話番号
        /// </summary>
        public string PhoneNumber { get; set; } = default!;

        /// <summary>
        /// 住所
        /// </summary>
        public string Address { get; set; } = default!;

        /// <summary>
        /// 入社日
        /// </summary>
        public DateTime HireDate { get; set; }

        /// <summary>
        /// 退社日
        /// </summary>
        public DateTime? ResignDate { get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
