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
        public void CreateBus(long licenseNumber, DateTime dateTime, float kM, float Fuel, int statusInput)
        {
            //if (!GoodLicense(licenseNumber, dateTime))
            //    throw new Exception("license number isn't accurate if greater than 2018 - 8 digits else 7 digits!");
            
            //check license number and date

            // check fuel 
            
            //check status

            //check km

            Bus busBO = new Bus(licenseNumber, dateTime, kM, Fuel, statusInput);
            DO.Bus busDO = busBO.GetPropertiesFrom<DO.Bus, BO.Bus>();
            dal.CreateBus(busDO);
        }
        public Bus RequestBus(Predicate<Bus> pr)
        {
            return dal.RequestBus(bus => pr(bus.GetPropertiesFrom<BO.Bus, DO.Bus>())).GetPropertiesFrom<BO.Bus,DO.Bus>();
        }

        public void UpdateBusKM(float kM, long licenseNumber)
        {
            //check km

            dal.UpdateBusKM(kM, licenseNumber);
        }

        public void UpdateBusFuel(float fuel, long licenseNumber)
        {
            // check fuel 

            dal.UpdateBusFuel(fuel, licenseNumber);
        }

        public void UpdateBusStatus(int st, long licenseNumber)
        {
            //check status


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
                var tempList = dal.GetAllBusses();
                var secondTempList = tempList.Select(bus => bus.GetPropertiesFrom<BO.Bus, DO.Bus>()).ToList();
                return secondTempList;
            }
            return dal.GetAllBusses().Select(bus => bus.GetPropertiesFrom<BO.Bus, DO.Bus>()).Where(b => pr(b));
        }
    }
}
