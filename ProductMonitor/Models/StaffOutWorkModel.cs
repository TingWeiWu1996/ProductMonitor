using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMonitor.Models
{

    /// <summary>
    /// 缺崗人員數據模型
    /// </summary>
    public class StaffOutWorkModel
    {
        /// <summary>
        /// 員工姓名
        /// </summary>

        public string StaffName { get; set; }

        /// <summary>
        /// 職位
        /// </summary>

        public string Position { get; set; }

        /// <summary>
        /// 缺崗次數
        /// </summary>

        public int OutWorkCount { get; set; }

        /// <summary>
        /// 介面顯示寬度
        /// </summary>
        public int ShowWidth
        {
            get
            {
                return OutWorkCount * 45 / 100;
            }
        }

    }
}
