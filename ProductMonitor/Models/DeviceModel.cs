using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMonitor.Models
{
    /// <summary>
    /// 設備數據模型
    /// </summary>
    internal class DeviceModel
    {
        /// <summary>
        /// 設備監控項名稱
        /// </summary>
        public string DeviceItem { get; set; }

        /// <summary>
        /// 值
        /// </summary>

        public string Value { get; set; }

    }
}
