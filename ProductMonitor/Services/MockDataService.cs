using ProductMonitor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMonitor.Services
{
    public class MockDataService : IDataService
    {
        public List<EnviromentModel> GetEnvironmentData()
        {
            return new List<EnviromentModel>
            {
                new EnviromentModel() { EnItemName = "光線", EnItemValue = 123 },
                new EnviromentModel() { EnItemName = "噪音", EnItemValue = 55 },
                new EnviromentModel() { EnItemName = "溫度", EnItemValue = 80 },
                new EnviromentModel() { EnItemName = "濕度", EnItemValue = 43 },
                new EnviromentModel() { EnItemName = "PM2.5", EnItemValue = 20 },
                new EnviromentModel() { EnItemName = "硫化氫", EnItemValue = 15 },
                new EnviromentModel() { EnItemName = "氮氣", EnItemValue = 18 }
            };
        }

        public List<AlarmModel> GetAlarmData()
        {
            return new List<AlarmModel>
            {
                new AlarmModel() { Num = "01", Msg = "設備溫度過高", Time = "2024-11-23 18:34:56", Duration = 7 },
                new AlarmModel() { Num = "02", Msg = "設備溫度過高", Time = "2024-12-23 15:34:56", Duration = 10 },
                new AlarmModel() { Num = "03", Msg = "設備轉速過快", Time = "2024-10-23 08:34:56", Duration = 12 },
                new AlarmModel() { Num = "04", Msg = "設備氣壓偏低", Time = "2024-09-23 20:34:56", Duration = 90 }
            };
        }

        public List<DeviceModel> GetDeviceData()
        {
            return new List<DeviceModel>
            {
                new DeviceModel() { Value = "60.8", DeviceItem = "電力" },
                new DeviceModel() { Value = "390", DeviceItem = "電壓" },
                new DeviceModel() { Value = "5", DeviceItem = "電流" },
                new DeviceModel() { Value = "13", DeviceItem = "壓差" },
                new DeviceModel() { Value = "36", DeviceItem = "溫度" },
                new DeviceModel() { Value = "4.1", DeviceItem = "震動" },
                new DeviceModel() { Value = "2600", DeviceItem = "轉速" },
                new DeviceModel() { Value = "0.5", DeviceItem = "氣壓" }
            };
        }

        public List<MachineModel> GetMachineData()
        {
            var list = new List<MachineModel>();
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                int plan = random.Next(100, 1000);
                int finished = random.Next(0, plan);
                list.Add(new MachineModel
                {
                    MachineName = "焊接機-" + (i + 1),
                    FinishedCount = finished,
                    PlanCount = plan,
                    Status = "作業中",
                    OrderNo = "SO202400"
                });
            }
            return list;
        }

        public List<RaderModel> GetRaderData()
        {
            return new List<RaderModel>
            {
                new RaderModel() { ItemName = "抽煙機", Value = 90 },
                new RaderModel() { ItemName = "電梯", Value = 30.00 },
                new RaderModel() { ItemName = "供水器", Value = 34.89 },
                new RaderModel() { ItemName = "泵", Value = 69.59 },
                new RaderModel() { ItemName = "穩壓設備", Value = 20 }
            };
        }

        public List<StaffOutWorkModel> GetStaffOutWorkData()
        {
            return new List<StaffOutWorkModel>
            {
                new StaffOutWorkModel { StaffName = "張三", Position = "技術員", OutWorkCount = 123 },
                new StaffOutWorkModel { StaffName = "李四", Position = "技術員", OutWorkCount = 50 },
                new StaffOutWorkModel { StaffName = "王五", Position = "技術員", OutWorkCount = 15 },
                new StaffOutWorkModel { StaffName = "楊六", Position = "技術員", OutWorkCount = 20 },
                new StaffOutWorkModel { StaffName = "吳七", Position = "工程師", OutWorkCount = 0 }
            };
        }

        public List<WorkShopModel> GetWorkShopData()
        {
            return new List<WorkShopModel>
            {
                new WorkShopModel() { WorkShopName = "貼片部", WorkingCount = 120, WaitCount = 20, WrongCount = 5, StopCount = 10 },
                new WorkShopModel() { WorkShopName = "封裝部", WorkingCount = 120, WaitCount = 20, WrongCount = 5, StopCount = 10 },
                new WorkShopModel() { WorkShopName = "焊接部", WorkingCount = 120, WaitCount = 20, WrongCount = 5, StopCount = 10 },
                new WorkShopModel() { WorkShopName = "貼片部", WorkingCount = 120, WaitCount = 20, WrongCount = 5, StopCount = 10 }
            };
        }



    }
}
