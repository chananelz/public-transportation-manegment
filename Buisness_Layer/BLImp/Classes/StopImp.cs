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

            // check latitude 

            //check longitude

            //check stopName

            Stop stopBO = new Stop(latitude, longitude, stopName);
            DO.Stop stopDO = stopBO.GetPropertiesFrom<DO.Stop, BO.Stop>();
            dal.CreateStop(stopDO);
        }
        public Stop RequestStop(Predicate<Stop> pr = null)
        {
            return dal.RequestStop(stop => pr(stop.GetPropertiesFrom<BO.Stop, DO.Stop>())).GetPropertiesFrom<BO.Stop, DO.Stop>();
        }
        public void UpdateStopName(string name, long code)
        {

            //check stopName
            dal.UpdateStopName(name, code);
        }
        public void UpdateStopLongitude(double longitude, long code)
        {

            //check longitude

            dal.UpdateStopLongitude(longitude, code);
        }
        public void UpdateStopLatitude(double latitude, long code)
        {
            // check latitude 

            dal.UpdateStopLatitude(latitude, code);
        }
        public void DeleteStop(long code)
        {
            dal.DeleteStop(code);
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
