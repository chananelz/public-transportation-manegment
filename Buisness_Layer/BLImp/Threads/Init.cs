using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using BO;

namespace BLImp
{
    public partial class BL : IBL
    {
        public void Initialize(TimeSpan time)
        {
            foreach (BusTravel busTravel in GetAllBusTravels())
            {
                DeleteBusTravel(busTravel.Id);
            }
            foreach (UserTravel userTravel in GetAllDriverTravel())
            {
                DeleteUserTravel(userTravel.ID);
            }
            var a = GetAllLineDeparture();
            foreach (LineDeparture lineDeparture in a)
            {
                var line = GetLine(lineDeparture.Id);
                var timeLine = TravelTimeCalculate(line.Number, line.FirstStop, line.LastStop);
                var timeStart = lineDeparture.Time_Start;
                DateTime dateTime = new DateTime();
                dateTime.AddYears(DateTime.Now.Year);
                dateTime.AddMonths(DateTime.Now.Month);
                dateTime.AddDays(DateTime.Now.Day);
                var timeSpanTimeStart = new TimeSpan(timeStart.Hour, timeStart.Minute, timeStart.Second);
                while (timeStart < lineDeparture.TimeEnd)
                {
                    if (timeSpanTimeStart + timeLine > time && timeSpanTimeStart < time)
                    {
                        Bus bus = GetAllBussesReadyForDrive().First();
                        User user = GetAllDrivers().First();
                        UpdateBusStatus(0, bus.LicenseNumber);
                        CreateBusTravel(bus.LicenseNumber, lineDeparture.Id, timeStart, dateTime + timeSpanTimeStart, GetStationByTime(timeSpanTimeStart, bus.LicenseNumber).Code, dateTime + GetPassedStopTime(time, bus.LicenseNumber), dateTime + GetNextStopTime(time, bus.LicenseNumber), user.UserName);
                    }
                    timeStart += new TimeSpan((lineDeparture.TimeEnd - lineDeparture.Time_Start).Ticks / lineDeparture.Frequency);
                }

            }
        }
    }
}

