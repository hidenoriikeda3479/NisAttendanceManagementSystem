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
        public int January { get; set; }

        /// <summary>
        /// 2月
        /// </summary>
        public int February { get; set; }

        /// <summary>
        /// 3月
        /// </summary>
        public int March { get; set; }

        /// <summary>
        /// 4月
        /// </summary>
        public int April { get; set; }

        /// <summary>
        /// 5月
        /// </summary>
        public int May { get; set; }

        /// <summary>
        /// 6月
        /// </summary>
        public int June { get; set; }

        /// <summary>
        /// 7月
        /// </summary>
        public int July { get; set; }

        /// <summary>
        /// 8月
        /// </summary>
        public int August { get; set; }

        /// <summary>
        /// 9月
        /// </summary>
        public int September { get; set; }

        /// <summary>
        /// 10月
        /// </summary>
        public int October { get; set; }

        /// <summary>
        /// 11月
        /// </summary>
        public int November { get; set; }

        /// <summary>
        /// 12月
        /// </summary>
        public int December { get; set; }

        public int Totalsalary
        {
            get
            {
                return January + February + March + April + May + June + July + August + September + October + November + December;  
            }
        }
    }
}
