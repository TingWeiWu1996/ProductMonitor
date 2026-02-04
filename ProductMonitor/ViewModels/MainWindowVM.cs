using ProductMonitor.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;
using ProductMonitor.Models;
using ProductMonitor.Services;
using System.Threading.Tasks;
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Wpf;


namespace ProductMonitor.ViewModels
{
    internal class MainWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly IDataService _dataService;
        private System.Timers.Timer _timer;

        public ChartValues<double> TempValues { get; set; }

        public MainWindowVM(IDataService dataService)
        {
            _dataService = dataService;
            TempValues = new ChartValues<double>();

            // 1. 先載入一次完整數據，建立 List 結構
            LoadData();

            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // 從 Modbus 讀取最新數據 (這是一份全新的 List)
            var newEnvData = _dataService.GetEnvironmentData();

            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                if (newEnvData != null && newEnvData.Count > 0)
                {
                    // 【關鍵修正】不要直接 EnviromentList = newEnvData;
                    // 而是去更新現有 List 裡的數值，這樣 UI 才不會閃爍或重置
                    if (EnviromentList != null && EnviromentList.Count == newEnvData.Count)
                    {
                        for (int i = 0; i < EnviromentList.Count; i++)
                        {
                            // 更新數值 (因為 Model 有寫 INotifyPropertyChanged，UI 會自動變)
                            EnviromentList[i].EnItemValue = newEnvData[i].EnItemValue;
                            // 更新名稱 (以防變成"斷線"狀態)
                            EnviromentList[i].EnItemName = newEnvData[i].EnItemName;
                        }
                    }
                    else
                    {
                        // 只有第一次或數量不對時，才暴力重置
                        EnviromentList = newEnvData;
                    }

                    // --- 圖表更新邏輯 ---
                    // 找出目前的 "溫度" 項目
                    var tempItem = EnviromentList.FirstOrDefault(x => x.EnItemName.Contains("溫度"));

                    if (tempItem != null)
                    {
                        TempValues.Add(Convert.ToDouble(tempItem.EnItemValue));
                        if (TempValues.Count > 20) TempValues.RemoveAt(0);
                    }
                }

                // 更新時間
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HourTime"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DataTime"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WeekDay"));
            });
        }

        private void LoadData()
        {
            EnviromentList = _dataService.GetEnvironmentData();
            AlarmList = _dataService.GetAlarmData();
            DeviceList = _dataService.GetDeviceData();
            RaderList = _dataService.GetRaderData();
            StaffOutWorkList = _dataService.GetStaffOutWorkData();
            WorkShopList = _dataService.GetWorkShopData();
            MachineList = _dataService.GetMachineData();
        }
        /// <summary>
        ///  監控用戶控件
        /// </summary>
        private UserControl _MonitorUC;


        /// <summary>
        ///  監控用戶控件
        /// </summary>
        public UserControl MonitorUC
        {
            get
            {
                if (_MonitorUC == null)
                {
                    _MonitorUC = new MonitorUC();
                }

                return _MonitorUC;
            }
            set
            {
                _MonitorUC = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MonitorUC"));
                }
            }
        }

        public string HourTime
        {
            get
            {
                return DateTime.Now.ToString("HH:mm");
            }
        }

        public string DataTime
        {
            get
            {
                return DateTime.Now.ToString("yyyy/MM/dd");
            }

        }

        public string WeekDay
        {
            get
            {
                return DateTime.Now.ToString("dddd");
            }
        }
        /// <summary>
        /// 機台總數
        /// </summary>
        private string _MachineCount = "250";

        public string MachineCount
        {
            get
            {
                return _MachineCount;
            }
            set
            {
                _MachineCount = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MachineCount"));
                }
            }
        }
        /// <summary>
        /// 生產數量
        /// </summary>
        private string _ProductCount = "1996";

        public string ProductCount
        {
            get
            {
                return _ProductCount;
            }
            set
            {
                _ProductCount = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductCount"));
                }
            }
        }
        /// <summary>
        /// NG數量
        /// </summary>
        private string _AlarmCount = "5";

        public string AlarmCount
        {
            get
            {
                return _AlarmCount;
            }
            set
            {
                _AlarmCount = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AlarmCount"));
                }
            }
        }

        private List<EnviromentModel> _EnviromentList;

        public List<EnviromentModel> EnviromentList
        {
            get { return _EnviromentList; }
            set
            {
                _EnviromentList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("EnviromentList"));
                }
            }
        }

        private List<AlarmModel> _AlarmList;

        public List<AlarmModel> AlarmList
        {
            get { return _AlarmList; }
            set
            {
                _AlarmList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AlarmList"));
                }

            }
        }

        /// <summary>
        /// 設備集合
        /// </summary>

        private List<DeviceModel> _DeviceList;

        public List<DeviceModel> DeviceList
        {
            get { return _DeviceList; }
            set
            {
                _DeviceList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DeviceList"));
                }
            }
        }

        #region 雷達數據屬性

        private List<RaderModel> _RaderList;

        public List<RaderModel> RaderList
        {
            get { return _RaderList; }
            set
            {
                _RaderList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("RaderList"));
                }
            }
        }
        #endregion

        #region 缺崗人員數據屬性

        private List<StaffOutWorkModel> _StaffOutWorkList;

        public List<StaffOutWorkModel> StaffOutWorkList
        {
            get { return _StaffOutWorkList; }
            set
            {
                _StaffOutWorkList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("StaffOutWorkList"));
                }
            }
        }
        #endregion

        #region 底部數據屬性

        private List<WorkShopModel> _WorkShopList;

        public List<WorkShopModel> WorkShopList
        {
            get { return _WorkShopList; }
            set
            {
                _WorkShopList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("WorkShopList"));
                }
            }
        }
        #endregion

        #region

        private List<MachineModel> _machineList;

        public List<MachineModel> MachineList
        {
            get { return _machineList; }
            set
            {
                _machineList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MachineModelList"));
                }
            }
        }

        #endregion



    }
}
