using ProductMonitor.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;
using ProductMonitor.Models;


namespace ProductMonitor.ViewModels
{
    internal class MainWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowVM()
        {
            #region 初始化環境監控數據
            EnviromentList = new List<EnviromentModel>();

            EnviromentList.Add(new EnviromentModel() { EnItemName = "光線", EnItemValue = 123 });
            EnviromentList.Add(new EnviromentModel() { EnItemName = "噪音", EnItemValue = 55 });
            EnviromentList.Add(new EnviromentModel() { EnItemName = "溫度", EnItemValue = 80 });
            EnviromentList.Add(new EnviromentModel() { EnItemName = "濕度", EnItemValue = 43 });
            EnviromentList.Add(new EnviromentModel() { EnItemName = "PM2.5", EnItemValue = 20 });
            EnviromentList.Add(new EnviromentModel() { EnItemName = "硫化氫", EnItemValue = 15 });
            EnviromentList.Add(new EnviromentModel() { EnItemName = "氮氣", EnItemValue = 18 });
            #endregion

            #region 初始化警報數據
            AlarmList = new List<AlarmModel>();
            AlarmList.Add(new AlarmModel() { Num = "01", Msg = "設備溫度過高", Time = "2026-11-23 18:34:56", Duration = 7 });
            AlarmList.Add(new AlarmModel() { Num = "02", Msg = "設備溫度過高", Time = "2026-12-23 15:34:56", Duration = 10 });
            AlarmList.Add(new AlarmModel() { Num = "03", Msg = "設備轉速過快", Time = "2026-10-23 08:34:56", Duration = 12 });
            AlarmList.Add(new AlarmModel() { Num = "04", Msg = "設備氣壓偏低", Time = "2026-09-23 20:34:56", Duration = 90 });
            #endregion

            #region 初始化設備數據
            DeviceList = new List<DeviceModel>();
            DeviceList.Add(new DeviceModel() { Value = "60.8", DeviceItem = "電力" });
            DeviceList.Add(new DeviceModel() { Value = "390", DeviceItem = "電壓" });
            DeviceList.Add(new DeviceModel() { Value = "5", DeviceItem = "電流" });
            DeviceList.Add(new DeviceModel() { Value = "13", DeviceItem = "壓差" });
            DeviceList.Add(new DeviceModel() { Value = "36", DeviceItem = "溫度" });
            DeviceList.Add(new DeviceModel() { Value = "4.1", DeviceItem = "震動" });
            DeviceList.Add(new DeviceModel() { Value = "2600", DeviceItem = "轉速" });
            DeviceList.Add(new DeviceModel() { Value = "0.5", DeviceItem = "氣壓" });
            #endregion

            #region 初始化雷達數據
            RaderList = new List<RaderModel>();
            RaderList.Add(new RaderModel() { ItemName = "抽煙機", Value = 90 });
            RaderList.Add(new RaderModel() { ItemName = "電梯", Value = 30.00 });
            RaderList.Add(new RaderModel() { ItemName = "供水器", Value = 34.89 });
            RaderList.Add(new RaderModel() { ItemName = "泵", Value = 69.59 });
            RaderList.Add(new RaderModel() { ItemName = "穩壓設備", Value = 20 });

            #endregion

            #region 初始化缺崗人員數據
            StaffOutWorkList = new List<StaffOutWorkModel>();
            StaffOutWorkList.Add(new StaffOutWorkModel { StaffName = "張三", Position = "技術員", OutWorkCount = 123 });
            StaffOutWorkList.Add(new StaffOutWorkModel { StaffName = "李四", Position = "技術員", OutWorkCount = 50 });
            StaffOutWorkList.Add(new StaffOutWorkModel { StaffName = "王五", Position = "技術員", OutWorkCount = 15 });
            StaffOutWorkList.Add(new StaffOutWorkModel { StaffName = "楊六", Position = "技術員", OutWorkCount = 20 });
            StaffOutWorkList.Add(new StaffOutWorkModel { StaffName = "吳七", Position = "工程師", OutWorkCount = 0 });

            #endregion

            #region 底部數據

            WorkShopList = new List<WorkShopModel>();
            WorkShopList.Add(new WorkShopModel() { WorkShopName = "貼片部", WorkingCount = 120, WaitCount = 20, WrongCount = 5, StopCount = 10 });
            WorkShopList.Add(new WorkShopModel() { WorkShopName = "封裝部", WorkingCount = 120, WaitCount = 20, WrongCount = 5, StopCount = 10 });
            WorkShopList.Add(new WorkShopModel() { WorkShopName = "焊接部", WorkingCount = 120, WaitCount = 20, WrongCount = 5, StopCount = 10 });
            WorkShopList.Add(new WorkShopModel() { WorkShopName = "貼片部", WorkingCount = 120, WaitCount = 20, WrongCount = 5, StopCount = 10 });
            #endregion

            #region 初始化機台列表
            MachineList = new List<MachineModel>();

            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                int plan = random.Next(100, 1000);
                int finished = random.Next(0, plan);

                MachineList.Add(new MachineModel
                {
                    MachineName = "焊接機-" + (i + 1),
                    FinishedCount = finished,
                    PlanCount = plan,
                    Status = "作業中",
                    OrderNo = "SO202400"
                });
            }

            #endregion



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
                return DateTime.Now.ToString("HH:MM");
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
