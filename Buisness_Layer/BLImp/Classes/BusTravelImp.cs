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

        public void CreateBusTravel(long licenseNumber, long lineId, DateTime formalDepartureTime, DateTime realDepartureTime, int lastPassedStop, DateTime lastPassedStopTime, DateTime nextStopTime, string driverId)
        {
            string exception = "";
            bool foundException = false;
            try
            {
                valid.ExistLicense(licenseNumber);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                valid.TimeAfter(formalDepartureTime, realDepartureTime, "formalDepartureTime", "realDepartureTime");
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                valid.TimeAfter(lastPassedStopTime, nextStopTime, "formalDepartureTime", "realDepartureTime");
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                valid.GoodInt(lastPassedStop);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            //try
            //{
            //    valid.UserNameExist(lastPassedStop);
            //}
            //catch (Exception ex)
            //{
            //    exception += ex.Message;
            //    foundException = true;
            //}
            try
            {
                valid.LineIdExist(lineId);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            //if (foundException)
            //    throw new Exception(exception);
            BusTravel busTravelBO = new BusTravel(licenseNumber, lineId, formalDepartureTime, realDepartureTime, lastPassedStop, lastPassedStopTime, nextStopTime, driverId);
            DO.BusTravel busTravelDO = busTravelBO.GetPropertiesFrom<DO.BusTravel, BO.BusTravel>();
            dal.CreateBusTravel(busTravelDO);
        }
        public BusTravel RequestBusTravel(Predicate<BusTravel> pr = null)
        {
            if (pr == null)
                throw new Exception("can't request a busTravel with no predicate");
            return dal.RequestBusTravel(busTravel => pr(busTravel.GetPropertiesFrom<BO.BusTravel, DO.BusTravel>())).GetPropertiesFrom<BO.BusTravel, DO.BusTravel>();
        }

        public void UpdateFormalDepartureTime(DateTime formalDepartureTime, long id)
        {
            valid.TimeAfter(formalDepartureTime, dal.GetBusTravel(id).RealDepartureTime, "formalDepartureTime", "RealDepartureTime");
            dal.UpdateFormalDepartureTime(formalDepartureTime, id);
        }
        public void UpdateRealDepartureTime(DateTime realDepartureTime, long id)
        {
            valid.TimeAfter(dal.GetBusTravel(id).FormalDepartureTime, realDepartureTime, "formalDepartureTime", "RealDepartureTime");
            dal.UpdateRealDepartureTime(realDepartureTime, id);
        }
        public void UpdateLastPassedStop(int lastPassedStop, long id)
        {
            valid.GoodInt(lastPassedStop);
            dal.UpdateLastPassedStop(lastPassedStop, id);
        }
        public void UpdateLastPassedStopTime(DateTime lastPassesStopTime, long id)
        {
            valid.TimeAfter(lastPassesStopTime, dal.GetBusTravel(id).NextStopTime, "lastPassesStopTime", "nextStopTime");
            dal.UpdateLastPassedStopTime(lastPassesStopTime, id);
        }
        public void UpdateNextStopTime(DateTime nextStopTime, long id)
        {
            valid.TimeAfter(dal.GetBusTravel(id).LastPassedStopTime, nextStopTime, "lastPassedStop", "nextStopTime");
            dal.UpdateNextStopTime(nextStopTime, id);
        }
        public void UpdateDriverId(string driverId, long id)
        {
            //validate driver id
            dal.UpdateDriverId(driverId, id);
        }

        public void DeleteBusTravel(long id)
        {
            dal.DeleteBusTravel(id);
        }
        public IEnumerable<BusTravel> GetAllBusTravels(Predicate<BusTravel> pr = null)
        {
            if (pr == null)
            {
                return dal.GetAllBusTravels().Select(busTravel => busTravel.GetPropertiesFrom<BO.BusTravel, DO.BusTravel>()).ToList(); ;
            }
            return dal.GetAllBusTravels().Select(busTravel => busTravel.GetPropertiesFrom<BO.BusTravel, DO.BusTravel>()).Where(b => pr(b));
        }

        public IEnumerable<Line> GetAllLinesByLicenseNumber(long licenseNumber)
        {
            var tempList = GetAllBusTravels(busTravel => busTravel.LicenseNumber == licenseNumber && busTravel.Valid).ToList();
            List<Line> retList = new List<Line>();
            foreach (BusTravel busTravel in tempList)
            {
                retList.Add(RequestLineById(busTravel.LineId));
            }
            return retList;
        }
        public Line GetLineByLicenseNumber(long licenseNumber)
        {
            return (from busTravel in GetAllBusTravels()
                     where busTravel.LicenseNumber == licenseNumber
                     select GetLine(busTravel.LineId)).First();
        }

    }
}
