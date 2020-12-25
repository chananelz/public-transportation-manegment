using System;
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
            Bus ret = DataSource.BusesList.Find(pr);
            if (ret != null)
                return ret.GetPropertiesFrom<Bus,Bus>();
            else
                throw new DO.Exceptions.DOBadBusIdException(0);
        }

        public void UpdateBusLicenseDate(DateTime licenseDate,Bus busInput)
        {
            var t = from bus in DataSource.BusesList
                    where (bus.LicenseNumber == busInput.LicenseNumber && bus.Valid == true)
                    select bus;
            t.ToList().First().LicenseDate = licenseDate;
        }
        public void UpdateBusKM(float kM, Bus busInput)
        {
            var t = from bus in DataSource.BusesList
                    where (bus.LicenseNumber == busInput.LicenseNumber && bus.Valid == true)
                    select bus;
            t.ToList().First().KM = kM ;
        }
        public void UpdateBusFuel(float fuel, Bus busInput)
        {
            var t = from bus in DataSource.BusesList
                    where (bus.LicenseNumber == busInput.LicenseNumber && bus.Valid == true)
                    select bus;
            t.ToList().First().Fuel = fuel;
        }
        public void UpdateBusStatus(status status, Bus busInput)
        {
            var t = from bus in DataSource.BusesList
                    where (bus.LicenseNumber == busInput.LicenseNumber && bus.Valid == true)
                    select bus;
            t.ToList().First().Status = status;
        }

        public void DeleteBus(Bus busInput)
        {
            var t = from bus in DataSource.BusesList
                    where (bus == busInput && bus.Valid == true)
                    select bus;
            t.ToList().First().Valid = false;
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

