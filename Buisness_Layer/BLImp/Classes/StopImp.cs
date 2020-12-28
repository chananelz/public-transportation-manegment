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

            string exception = "";
            bool foundException = false;
            try
            {
                Validator.GoodLatitude(latitude);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                Validator.GoodLongitude(longitude);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                Validator.GoodString(stopName);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            if (foundException)
                throw new Exception(exception);
            Stop stopBO = new Stop(latitude, longitude, stopName);
            DO.Stop stopDO = stopBO.GetPropertiesFrom<DO.Stop, BO.Stop>();
            dal.CreateStop(stopDO);
        }
        public Stop RequestStop(Predicate<Stop> pr = null)
        {
            if (pr == null)
                throw new Exception("can't request a line with no predicate");
            return dal.RequestStop(stop => pr(stop.GetPropertiesFrom<BO.Stop, DO.Stop>())).GetPropertiesFrom<BO.Stop, DO.Stop>();
        }
        public void UpdateStopName(string name, long code)
        {

            Validator.GoodString(name);
            dal.UpdateStopName(name, code);
        }
        public void UpdateStopLongitude(double longitude, long code)
        {

            Validator.GoodLongitude(longitude);
            dal.UpdateStopLongitude(longitude, code);
        }
        public void UpdateStopLatitude(double latitude, long code)
        {
            Validator.GoodLatitude(latitude);
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
                return dal.GetAllStops().Select(stop => stop.GetPropertiesFrom<BO.Stop, DO.Stop>()).ToList(); ;
            }
            return dal.GetAllStops().Select(stop => stop.GetPropertiesFrom<BO.Stop, DO.Stop>()).Where(b => pr(b));
        }

    }
}
