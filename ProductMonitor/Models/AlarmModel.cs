using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMonitor.Models
{
    /// <summary>
    /// Alarm數據模型
    /// </summary>
    internal class AlarmModel
    {
        /// <summary>
        /// 編號
        /// </summary>
        public string Num { get; set; }

        /// <summary>
        /// 警報訊息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 警報時間
        /// </summary>

        public string Time { get; set; }


        /// <summary>
        /// 警報時長 單位:秒
        /// </summary>
        public int Duration { get; set; }

    }
}
