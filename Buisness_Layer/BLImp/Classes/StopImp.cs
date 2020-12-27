using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using BO;
using BL;




namespace BLImp
{
    public partial class BL : IBL
    {
        public void CreateStop(double latitude, double longitude, string stopName)
        {
            Stop stopBO = new Stop(latitude, longitude,stopName);
            DO.Stop stopDO = stopBO.GetPropertiesFrom<DO.Stop, BO.Stop>();
            dal.CreateStop(stopDO);
        }
        public Stop RequestStop(long id)
        {
            DO.Stop stopDO = new DO.Stop();
            stopDO = dal.RequestStop(id);
            BO.Stop stopBO = stopDO.GetPropertiesFrom<BO.Stop, DO.Stop>();
            return stopBO;
        }
        public  void UpdateStop(double latitude, double longitude, string stopName)
        {
            Stop stopBO = new Stop(latitude, longitude, stopName);
            DO.Stop stopDO = stopBO.GetPropertiesFrom<DO.Stop, BO.Stop>();
            dal.UpdateStop(stopDO);
        }
        public  void DeleteStop(double latitude, double longitude, string stopName)
        {
            Stop stopBO = new Stop(latitude, longitude, stopName);
            DO.Stop stopDO = stopBO.GetPropertiesFrom<DO.Stop, BO.Stop>();
            dal.DeleteStop(stopDO);
        }

        public IEnumerable<Stop> GetAllStops(Predicate<Stop> pr = null)
        {
            if (pr == null)
            {
                var tempList = dal.GetAllStops();
                var secondTempList = tempList.Select(stop => stop.GetPropertiesFrom<BO.Stop, DO.Stop>()).ToList();
                return secondTempList;
            }
            return dal.GetAllStops().Select(stop => stop.GetPropertiesFrom<BO.Stop, DO.Stop>()).Where(b => pr(b));
        }

        
    }
}
