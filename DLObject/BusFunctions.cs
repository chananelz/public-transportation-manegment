﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DS;
using DO;





namespace DL
{
    public partial class DLObject : IDal
    {
        public void CreateBus(Bus bus)
        {
            bus.Valid = true;
            bus.LicenseNumber = Configuration.BusCounter;
            DataSource.BusesList.Add(bus);
        }

        public Bus RequestBus(Predicate<Bus> pr = null)
        {
            Bus ret = DataSource.BusesList.Find(bus => pr(bus));
            if (ret == null)
                throw new Exception("no bus that meets these conditions!");
            ret = DataSource.BusesList.Find(bus => bus.Valid == true);
            if (ret == null)
                throw new Exception("bus that meets these conditions is not valid");
            return ret.GetPropertiesFrom<Bus,Bus>();
        }

      
        public void UpdateBusKM(float kM, long licenseNumber)
        {
            GetBus(licenseNumber).KM = kM ;
        }

        public void UpdateBusFuel(float fuel, long licenseNumber)
        {
            GetBus(licenseNumber).Fuel = fuel;
        }

        public void UpdateBusStatus(int status, long licenseNumber)
        {
            //***************************CONVERT INT TO STATUS!!!!!!!!!!!!!************
            GetBus(licenseNumber).Status = 0;
        }

        public Bus GetBus(long licenseNumber)
        {
            var t = from bus in DataSource.BusesList
                    where (bus.LicenseNumber == licenseNumber)
                    select bus;
            if (t.ToList().Count == 0)
                throw new Exception("no bus with such license number!!");
            if (!t.First().Valid)
                throw new Exception("bus is not valid!!");
            return t.ToList().First();
        }

        public void DeleteBus(long licenseNumber)
        {
            GetBus(licenseNumber).Valid = false;
        }

        public IEnumerable<Bus> GetAllBusses()
        {
            var cloneList = new List<Bus>();
            foreach (Bus bus in DataSource.BusesList)
                cloneList.Add(bus.GetPropertiesFrom<Bus,Bus>());
            return cloneList;
        }
    }
}

