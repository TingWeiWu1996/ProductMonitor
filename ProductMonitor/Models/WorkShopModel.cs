using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ProductMonitor.Models
{
    /// <summary>
    /// 底部數據模型
    /// </summary>

    internal class WorkShopModel
    {
        public string WorkShopName { get; set; }

        public int WorkingCount { get; set; }

        public int WaitCount { get; set; }

        public int WrongCount { get; set; }

        public int StopCount { get; set; }

        public int TotalCount
        {
            get
            {
                return WorkingCount + WaitCount + WrongCount + StopCount;
            }
        }



    }
}
