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
        /// <summary>
        /// a function that adds a new bus to the database
        /// </summary>
        /// <param name="bus">the bus you want to add</param>
        public void CreateBus(Bus bus)
        {
            bus.Valid = true;
            try
            {
                GetBus(bus.LicenseNumber);
            }
            catch(Exception ex)                                             //try "BusException" and check if it work.
            {
                if (ex.Message == "no bus with such license number!!")
                    DataSource.BusesList.Add(bus);
                else if (ex.Message == "bus is not valid!!")
                {
                    var t = from busInput in DataSource.BusesList
                            where (busInput.LicenseNumber == bus.LicenseNumber)
                            select bus;
                    t.ToList().First().Valid = true;
                }
                return;
            }
            throw new DOBadBusIdException(bus.LicenseNumber, "bus already exists!!!");
        }

        /// <summary>
        /// request a bus according to a predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns>the wanted bus</returns>
        public Bus RequestBus(Predicate<Bus> pr = null)
        {
            Bus ret = DataSource.BusesList.Find(bus => pr(bus));
            if (ret == null)
                throw new DOBusException("no bus that meets these conditions!");
            if (ret.Valid == false)
                throw new DOBusException("bus that meets these conditions is not valid");
            return ret.GetPropertiesFrom<Bus,Bus>();
        }


        #region update functions
        /// <summary>
        /// update the amount of km the bus has drived 
        /// </summary>
        /// <param name="kM">input km you want to change</param>
        /// <param name="licenseNumber">license number for id</param>
        public void UpdateBusKM(float kM, long licenseNumber)
        {
            GetBus(licenseNumber).KM = kM;
        }
        /// <summary>
        /// a funciton to update the amount of fuel the bus has
        /// </summary>
        /// <param name="fuel">amount of fuel you want to update</param>
        /// <param name="licenseNumber">license number for id</param>

        public void UpdateBusFuel(float fuel, long licenseNumber)
        {
            GetBus(licenseNumber).Fuel = fuel;
        }
        /// <summary>
        /// updates the status you give in a number and according to that number between 0 - 3
        /// </summary>
        /// <param name="status">new status to update</param>
        /// <param name="licenseNumber">license number for id</param>

        public void UpdateBusStatus(int status, long licenseNumber)
        {
            //***************************CONVERT INT TO STATUS!!!!!!!!!!!!!************
            GetBus(licenseNumber).Status = 0;
        }
        #endregion
        /// <summary>
        /// a helper function that gets the bus you want
        /// </summary>
        /// <param name="licenseNumber">license number for id</param>
        /// <returns>wanted bus</returns>
        public Bus GetBus(long licenseNumber)
        {
            var t = from bus in DataSource.BusesList
                    where (bus.LicenseNumber == licenseNumber)
                    select bus;
            if (t.ToList().Count == 0)
                throw new DOBadBusIdException(licenseNumber,"no bus with such license number!!");
            if (!t.First().Valid)
                throw new DOBadBusIdException(licenseNumber,"bus is not valid!!");
            return t.ToList().First();
        }
        /// <summary>
        /// a function that sets bus valid to false
        /// </summary>
        /// <param name="licenseNumber">license number for id</param>

        public void DeleteBus(long licenseNumber)
        {
            GetBus(licenseNumber).Valid = false;
        }
        /// <summary>
        /// a function that gets all buses from database
        /// </summary>
        /// <returns>all the busses saved in the data base</returns>

        public IEnumerable<Bus> GetAllBusses()
        {
            var cloneList = new List<Bus>();
            foreach (Bus bus in DataSource.BusesList)
            {
                if (bus.Valid == true)
                    cloneList.Add(bus.GetPropertiesFrom<Bus, Bus>());
            }
            return cloneList;
        }
    }
}

