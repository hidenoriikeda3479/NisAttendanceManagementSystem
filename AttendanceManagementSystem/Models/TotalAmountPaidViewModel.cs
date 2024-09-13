using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceManagementSystem.Models
{
    internal class TotalAmountPaidViewModel
    {
        /// <summary>
        /// 従業員名
        /// </summary>
        public string EmployeeName { get; set; } = default!;

        /// <summary>
        /// 1月
        /// </summary>
        public decimal January { get; set; }

        /// <summary>
        /// 2月
        /// </summary>
        public decimal February { get; set; }

        /// <summary>
        /// 3月
        /// </summary>
        public decimal March { get; set; }

        /// <summary>
        /// 4月
        /// </summary>
        public decimal April { get; set; }

        /// <summary>
        /// 5月
        /// </summary>
        public decimal May { get; set; }

        /// <summary>
        /// 6月
        /// </summary>
        public decimal June { get; set; }

        /// <summary>
        /// 7月
        /// </summary>
        public decimal July { get; set; }

        /// <summary>
        /// 8月
        /// </summary>
        public decimal August { get; set; }

        /// <summary>
        /// 9月
        /// </summary>
        public decimal September { get; set; }

        /// <summary>
        /// 10月
        /// </summary>
        public decimal October { get; set; }

        /// <summary>
        /// 11月
        /// </summary>
        public decimal November { get; set; }

        /// <summary>
        /// 12月
        /// </summary>
        public decimal December { get; set; }

        public decimal Totalsalary
        {
            get
            {
                return January + February + March + April + May + June + July + August + September + October + November + December;  
            }
        }
    }
}
