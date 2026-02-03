using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMonitor.Models
{
    internal class MachineModel
    {
        /// <summary>
        /// 機台名稱
        /// </summary>

        public string MachineName { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 計畫任務數量
        /// </summary>
        public int PlanCount { get; set; }
        /// <summary>
        /// 已完成任務數量
        /// </summary>
        public int FinishedCount { get; set; }
        /// <summary>
        /// 工單編號
        /// </summary>
        public string OrderNo { get; set; }

        public double Percent
        {
            get
            {
                return FinishedCount * 100.0 / PlanCount;
            }
        }
    }
}
