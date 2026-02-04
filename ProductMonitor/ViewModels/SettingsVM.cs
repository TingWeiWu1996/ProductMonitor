using ProductMonitor.Models;
using ProductMonitor.OpCommand;
using ProductMonitor.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Intrinsics.Arm;
using System.Windows;
using System.Windows.Input;

namespace ProductMonitor.ViewModels
{
    public class SettingsVM :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // --- 1. 系統設定屬性 ---
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public bool IsSimulation { get; set; }

        // --- 2. 原本頁面需要的資料 (設備清單) ---
        public List<DeviceModel> DeviceList { get; set; }

        // --- 3. 命令 ---
        public ICommand SaveCommand { get; set; }

        public SettingsVM()
        {
            // 初始化設定值 (讀取全域設定)
            IpAddress = DeviceConfig.IpAddress;
            Port = DeviceConfig.Port;
            IsSimulation = DeviceConfig.IsSimulationMode;

            // 初始化設備清單 (為了讓頁面上方不留白)
            // 這裡簡單直接 new 一個 Service 來抓，實際專案可用注入
            IDataService service = new ModbusDataService();
            // 如果是在模擬模式，這行可能會報錯或是空的，建議用 MockDataService 抓清單比較穩
            if (IsSimulation) service = new MockDataService();

            DeviceList = service.GetDeviceData();

            // 綁定儲存按鈕
            SaveCommand = new RelayCommand(Save);
        }
        private void Save(object obj)
        {
            // 1. 寫入全域設定
            DeviceConfig.IpAddress = IpAddress;
            DeviceConfig.Port = Port;
            DeviceConfig.IsSimulationMode = IsSimulation;

            // 2. 通知主視窗重啟服務
            if (Application.Current.MainWindow is MainWindow mainWin)
            {
                mainWin.ReloadService();
            }

            // 3. 關閉設定視窗
            // obj 是從 CommandParameter 傳進來的 Window
            if (obj is Window win)
            {
                win.Close();
            }
        }
    }
}
