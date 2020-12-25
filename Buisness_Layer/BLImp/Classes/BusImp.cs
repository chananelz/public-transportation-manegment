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
            Bus busBO = new Bus(licenseNumber, dateTime, kM, Fuel, statusInput);
            DO.Bus busDO = busBO.GetPropertiesFrom<DO.Bus, BO.Bus>();
            dal.CreateBus(busDO);
        }
        public Bus RequestBus(long id)
        {
            DO.Bus busDO = new DO.Bus();
            busDO = dal.RequestBus(id);
            BO.Bus busBO = busDO.GetPropertiesFrom<BO.Bus, DO.Bus>();
            return busBO;
        }
        public void UpdateBus(long licenseNumber, DateTime dateTime, float kM, float Fuel, int statusInput)
        {
            Bus busBO = new Bus(licenseNumber, dateTime, kM, Fuel, statusInput);
            DO.Bus busDO = busBO.GetPropertiesFrom<DO.Bus, BO.Bus>();
            dal.UpdateBus(busDO);
        }
        public void DeleteBus(long licenseNumber, DateTime dateTime, float kM, float Fuel, int statusInput)
        {
            Bus busBO = new Bus(licenseNumber, dateTime, kM, Fuel, statusInput);
            DO.Bus busDO = busBO.GetPropertiesFrom<DO.Bus, BO.Bus>();
            dal.DeleteBus(busDO);
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
