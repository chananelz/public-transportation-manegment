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
        public void CreateBusTravel(long licenseNumber, DateTime formalDepartureTime, DateTime realDepartureTime, int lastPassedStop, DateTime lastPassedStopTime, DateTime nextStopTime)
        {
            BusTravel busTravelBO = new BusTravel(licenseNumber, formalDepartureTime, realDepartureTime, lastPassedStop, lastPassedStopTime, nextStopTime);
            DO.BusTravel busTravelDO = busTravelBO.GetPropertiesFrom<DO.BusTravel, BO.BusTravel>();
            dal.CreateBusTravel(busTravelDO);
        }
        public BusTravel RequestBusTravel(long id)
        {
            DO.BusTravel busTravelDO = new DO.BusTravel();
            busTravelDO = dal.RequestBusTravel(id);
            BO.BusTravel busTravelBO = busTravelDO.GetPropertiesFrom<BO.BusTravel, DO.BusTravel>();
            return busTravelBO;
        }
        public void UpdateBusTravel(long licenseNumber, DateTime formalDepartureTime, DateTime realDepartureTime, int lastPassedStop, DateTime lastPassedStopTime, DateTime nextStopTime)
        {
            BusTravel busTravelBO = new BusTravel(licenseNumber, formalDepartureTime, realDepartureTime, lastPassedStop, lastPassedStopTime, nextStopTime);
            DO.BusTravel busTravelDO = busTravelBO.GetPropertiesFrom<DO.BusTravel, BO.BusTravel>();
            dal.UpdateBusTravel(busTravelDO);
        }
        public void DeleteBusTravel(long licenseNumber, DateTime formalDepartureTime, DateTime realDepartureTime, int lastPassedStop, DateTime lastPassedStopTime, DateTime nextStopTime)
        {
            BusTravel busTravelBO = new BusTravel(licenseNumber, formalDepartureTime, realDepartureTime, lastPassedStop, lastPassedStopTime, nextStopTime);
            DO.BusTravel busTravelDO = busTravelBO.GetPropertiesFrom<DO.BusTravel, BO.BusTravel>();
            dal.DeleteBusTravel(busTravelDO);
        }
    }
}
