using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using BO;
using System.ComponentModel;
using BLApi;
using System.Diagnostics;
using System.Threading;

namespace BLImp
{

    public partial class BL : IBL
    {
        TimeSpan startTime = new TimeSpan();
        BackgroundWorker bwPl = new BackgroundWorker();
        Stopwatch stopWatch = new Stopwatch();

        public class CustomClass
        {
            public object BW;
            public LineDeparture LD;
            public CustomClass(object bw, LineDeparture lD)
            {
                BW = bw;
                LD = lD;
            }
        }


        public void Initialize(object sender, TimeSpan timeSpan)
        {
            bwPl = sender as BackgroundWorker;
            startTime = timeSpan;

            stopWatch.Start();
            BackgroundWorker bw = new BackgroundWorker();

            var allBusTravels = GetAllBusTravels();
            var allBusses = GetAllBusses();
            var allDriverTravels = GetAllDriverTravel();
            var allLineDepartures = GetAllLineDeparture();


            foreach (BusTravel busTravel in allBusTravels)
            {
                DeleteBusTravel(busTravel.Id);
            }
            foreach (Bus bus in allBusses)
            {
                UpdateBusStatus(1, bus.LicenseNumber);
            }

            foreach (UserTravel userTravel in allDriverTravels)
            {
                DeleteUserTravel(userTravel.ID);
            }
            foreach (LineDeparture lineDeparture in allLineDepartures)
            {
                bw.DoWork += DoWorkLine;
                var custumClass = new CustomClass(bw, lineDeparture);
                bw.RunWorkerAsync(custumClass);
            }
        }


        private TimeSpan GetCurrentTime()
        {
            TimeSpan realTime = new TimeSpan(stopWatch.ElapsedTicks);
            realTime += startTime;
            while (realTime.Hours >= 24)
                realTime.Add(new TimeSpan(-24, 0, 0));
            return realTime;
        }







        private void DoWorkLine(object sender, DoWorkEventArgs e)
        {
            var custom = sender as CustomClass;

            var line = GetLine(custom.LD.Id);
            var timeLine = TravelTimeCalculate(line.Number, line.FirstStop, line.LastStop);

            BackgroundWorker bwDigital = custom.BW as BackgroundWorker;

            var timeStart = custom.LD.Time_Start;
            var timeSpanTimeStart = new TimeSpan(timeStart.Hour, timeStart.Minute, timeStart.Second);

            var timeEnd = custom.LD.TimeEnd;
            var timeSpanTimeEnd = new TimeSpan(timeEnd.Hour, timeEnd.Minute, timeEnd.Second);

            var dateTime = new DateTime(timeStart.Year, timeStart.Month, timeStart.Day);


            int counterProgress = 0;
            int lowerBound = 0;

            TimeSpan timeFrequency = new TimeSpan((custom.LD.TimeEnd - custom.LD.Time_Start).Ticks / custom.LD.Frequency);

            while (GetCurrentTime() < timeSpanTimeEnd)
            {
                for (; counterProgress < custom.LD.Frequency; counterProgress++)
                {
                    if (timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress) + timeLine > GetCurrentTime() && timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress) < GetCurrentTime())
                    {
                        Bus bus = GetAllBussesReadyForDrive().First();
                        User user = GetAllDrivers().First();
                        UpdateBusStatus(0, bus.LicenseNumber);
                        CreateBusTravel(bus.LicenseNumber, custom.LD.Id, dateTime + timeSpanTimeStart+ TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress), dateTime + timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress), GetStationByTime(timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress),GetCurrentTime(), bus.LicenseNumber).Code, dateTime + GetPassedStopTime(timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress),GetCurrentTime(), bus.LicenseNumber), dateTime + GetNextStopTime(timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress),GetCurrentTime(), bus.LicenseNumber), user.UserName);
                        CreateUserTravel(user.UserName, line.Number, dateTime + timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress), dateTime + timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress) + timeLine);
                    }
                    else
                        break;
                }
                for (; lowerBound < counterProgress; lowerBound++)
                {
                    if (timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress) + timeLine < GetCurrentTime())
                    {
                        BusTravel bt = FindBusTravelWithLineNumberAndDepartureTime(line.Id, timeStart + TimeSpan.FromTicks(timeFrequency.Ticks * lowerBound));
                        UserTravel ut = GetDriverTravel(line.Number, timeStart + TimeSpan.FromTicks(timeFrequency.Ticks * lowerBound));
                        DeleteBusTravel(bt.Id);
                        UpdateBusStatus(1, bt.LicenseNumber);
                        DeleteUserTravel(ut.ID);
                    }
                    else
                        break;
                }
                
                System.Threading.Thread.Sleep(1000);
                for (int i = lowerBound; i < counterProgress; i++)
                {
                    BusTravel bt = FindBusTravelWithLineNumberAndDepartureTime(line.Id, timeStart + TimeSpan.FromTicks(timeFrequency.Ticks * i));
                    //bwDigital.ReportProgress(lowerBound, new DigitalScreen());
                }
            }
        }


        /// <summary>
        /// This function is responsible for the changes derived from the control progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //bwPl.ReportProgress(,)
        }


        ///<summary>
        /// This function is responsible for the activities that are activated at the end of the process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}