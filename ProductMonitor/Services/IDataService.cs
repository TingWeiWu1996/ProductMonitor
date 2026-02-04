using ProductMonitor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMonitor.Services
{
    public interface IDataService
    {
        List<EnviromentModel> GetEnvironmentData();
        List<AlarmModel> GetAlarmData();
        List<DeviceModel> GetDeviceData();
        List<RaderModel> GetRaderData();
        List<StaffOutWorkModel> GetStaffOutWorkData();
        List<WorkShopModel> GetWorkShopData();
        List<MachineModel> GetMachineData();



    }


}

