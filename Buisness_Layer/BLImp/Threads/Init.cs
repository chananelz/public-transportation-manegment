using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using BO;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
//

namespace BLImp
{

    public partial class BL : IBL
    {
        TimeSpan startTime = new TimeSpan();
        BackgroundWorker bwPl = new BackgroundWorker();
        Stopwatch stopWatch = new Stopwatch();
        int speed;

        /// <summary>
        /// this class need because of the threding
        /// </summary>
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


        public void Initialize(object sender, TimeSpan timeSpan, int speedInput)
        {
            bwPl = sender as BackgroundWorker;
            startTime = timeSpan;
            stopWatch.Restart();
            // stopWatch.Start();


            speed = speedInput;


            BackgroundWorker update = new BackgroundWorker();
            update.DoWork += DoWorkLineUpdate;
            update.ProgressChanged += Worker_ProgressChangedUpdate;
            update.RunWorkerCompleted += Worker_RunWorkerCompletedUpdate;
            update.WorkerReportsProgress = true;
            update.WorkerSupportsCancellation = true;
            update.RunWorkerAsync();









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
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += DoWorkLine;
                bw.ProgressChanged += Worker_ProgressChanged;
                bw.RunWorkerCompleted += Worker_RunWorkerCompleted;
                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;
                var custumClass = new CustomClass(bw, lineDeparture);
                bw.RunWorkerAsync(custumClass);
            }
        }


        private TimeSpan GetCurrentTime()
        {
            TimeSpan realTime = new TimeSpan(stopWatch.ElapsedTicks * speed);
            realTime += startTime;
            while (realTime.Hours >= 24)
                realTime.Add(new TimeSpan(-24, 0, 0));
            return realTime;
        }







        private void DoWorkLine(object sender, DoWorkEventArgs e)
        {
            var custom = e.Argument as CustomClass;


            var line = GetLine(custom.LD.Id);
            var timeLine = TravelTimeCalculate(line.Number, line.FirstStop, line.LastStop);

            BackgroundWorker bwDigital = custom.BW as BackgroundWorker;

            var timeStart = custom.LD.TimeStart;
            var timeSpanTimeStart = new TimeSpan(timeStart.Hour, timeStart.Minute, timeStart.Second);

            var timeEnd = custom.LD.TimeEnd;
            var timeSpanTimeEnd = new TimeSpan(timeEnd.TimeOfDay.Hours, timeEnd.TimeOfDay.Minutes, timeEnd.TimeOfDay.Seconds);

            DateTime dateTime;

            DateTime.TryParse(timeStart.Year + "/" + timeStart.Month + "/" + timeStart.Day + " " + 0 + ":" + 0 + ":" + 0, out dateTime);


            int counterProgress = 0;
            int lowerBound = 0;

            TimeSpan timeFrequency = new TimeSpan((custom.LD.TimeEnd - custom.LD.TimeStart).Ticks / custom.LD.Frequency);

            while (GetCurrentTime() < timeSpanTimeEnd)
            {
                for (; counterProgress < custom.LD.Frequency; counterProgress++)
                {

                    if (GetCurrentTime() > timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress) &&
                        GetCurrentTime() < timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress) + timeLine)
                    {
                        var allBusTravels = GetAllBusTravels();
                        if (allBusTravels.Count() == 0 || GetAllBusTravels().ToList().
                            Find(bt => bt.FormalDepartureTime == (dateTime + timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress)))!=null)
                            {
                            Bus bus = GetAllBussesReadyForDrive().First();
                            User user = GetAllDrivers().First();
                            UpdateBusStatus(0, bus.LicenseNumber);
                            CreateBusTravel(bus.LicenseNumber, custom.LD.Id, dateTime + timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress),
                                dateTime + timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress),
                                GetStationByTime(timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress), GetCurrentTime(), line.Id).Code,
                                dateTime + GetPassedStopTime(timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress), GetCurrentTime(), line.Id),
                                dateTime + GetNextStopTime(timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress), GetCurrentTime(), line.Id), user.UserName);
                            CreateUserTravel(user.UserName, line.Number, dateTime + timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress), dateTime + timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress) + timeLine);
                        }
                    }
                    else if (GetCurrentTime() < timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * counterProgress))
                        break;
                }
                for (; lowerBound < counterProgress; lowerBound++)
                {
                    if (timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * lowerBound) + timeLine < GetCurrentTime())
                    {
                        BusTravel bt;
                        try
                        {
                            bt = FindBusTravelWithLineNumberAndDepartureTime(line.Id, timeStart + TimeSpan.FromTicks(timeFrequency.Ticks * lowerBound));
                        }
                        catch { continue; }
                        UserTravel ut = GetDriverTravel(line.Number, timeStart + TimeSpan.FromTicks(timeFrequency.Ticks * lowerBound));
                        DeleteBusTravel(bt.Id);
                        UpdateBusStatus(1, bt.LicenseNumber);
                        DeleteUserTravel(ut.ID);
                    }
                    else
                        break;
                }
                var aaaa = GetAllBusTravels();

                for (int i = lowerBound; i < counterProgress; i++)
                {
                    BusTravel bt = new BusTravel();
                    bt = FindBusTravelWithLineNumberAndDepartureTime(line.Id, timeStart + TimeSpan.FromTicks(timeFrequency.Ticks * i));
                    UpdateLastPassedStop((GetStationByTime(timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * i), GetCurrentTime(), line.Id).Code), bt.Id);
                    UpdateNextStopTime(dateTime + GetNextStopTime(timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * i), GetCurrentTime(), line.Id), bt.Id);
                    UpdateLastPassedStopTime(dateTime + GetPassedStopTime(timeSpanTimeStart + TimeSpan.FromTicks(timeFrequency.Ticks * i), GetCurrentTime(), line.Id), bt.Id);

                }
                Thread.Sleep(500);
            }
        }


        /// <summary>
        /// This function is responsible for the changes derived from the control progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //bwPl.ReportProgress(e.ProgressPercentage,e.UserState);
        }


        ///<summary>
        /// This function is responsible for the activities that are activated at the end of the process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

























        private void DoWorkLineUpdate(object sender, DoWorkEventArgs e)
        {
            while (bwPl.IsBusy)
            {
                bwPl.ReportProgress(1, new DigitalScreen(null, null, GetCurrentTime()));
                Thread.Sleep(1000);
            }
        }


        /// <summary>
        /// This function is responsible for the changes derived from the control progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_ProgressChangedUpdate(object sender, ProgressChangedEventArgs e)
        {
        }


        ///<summary>
        /// This function is responsible for the activities that are activated at the end of the process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompletedUpdate(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}