using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using BLApi;
using BO;
using BL;
//ne


namespace BLImp
{
    public partial class BL : IBL
    {
        public void CreateBus(long licenseNumber, DateTime dateTime, float kM, float fuel, int statusInput)
        {

            string exception = "";
            bool foundException = false;
            try
            {
                Validator.GoodLicense(licenseNumber, dateTime);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                Validator.ExistLicense(licenseNumber);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                Validator.GoodFuel(fuel);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }

            try
            {
                Validator.GoodStatus(statusInput);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }

            try
            {
                Validator.GoodFloat(kM);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            if (foundException)
                throw new Exception(exception);
            Bus busBO = new Bus(licenseNumber, dateTime, kM, fuel, statusInput);
            DO.Bus busDO = busBO.GetPropertiesFrom<DO.Bus, BO.Bus>();
            dal.CreateBus(busDO);
        }
        public Bus RequestBus(Predicate<Bus> pr)
        {
            if (pr == null)
                throw new Exception("can't request a line with no predicate");
            return dal.RequestBus(bus => pr(bus.GetPropertiesFrom<BO.Bus, DO.Bus>())).GetPropertiesFrom<BO.Bus, DO.Bus>();
        }

        public void UpdateBusKM(float kM, long licenseNumber)
        {
            Validator.GoodFloat(kM);
            dal.UpdateBusKM(kM, licenseNumber);
        }

        public void UpdateBusFuel(float fuel, long licenseNumber)
        {
            Validator.GoodFuel(fuel);
            dal.UpdateBusFuel(fuel, licenseNumber);
        }

        public void UpdateBusStatus(int st, long licenseNumber)
        {
            Validator.GoodStatus(st);
            dal.UpdateBusStatus(st, licenseNumber);
        }


        public void DeleteBus(long licenseNumber)
        {
            dal.DeleteBus(licenseNumber);
        }


        public IEnumerable<Bus> GetAllBusses(Predicate<Bus> pr = null)
        {
            if (pr == null)
            {
                return dal.GetAllBusses().Select(bus => bus.GetPropertiesFrom<BO.Bus, DO.Bus>()).ToList(); ;
            }
            return dal.GetAllBusses().Select(bus => bus.GetPropertiesFrom<BO.Bus, DO.Bus>()).Where(b => pr(b));
        }
    }
}
