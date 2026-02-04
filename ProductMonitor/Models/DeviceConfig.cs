using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMonitor.Models
{
    public static class DeviceConfig
    {
        // 預設值
        public static string IpAddress { get; set; } = "127.0.0.1";
        public static int Port { get; set; } = 502;

        // true = 使用 MockDataService (假資料)
        // false = 使用 ModbusDataService (真 通訊)
        public static bool IsSimulationMode { get; set; } = false;
    }
}
