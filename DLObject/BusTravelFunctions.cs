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
        public void CreateBusTravel(BusTravel busTravel)
        {


            busTravel.Valid = true;
            try
            {
                GetBusTravel(busTravel.Id);
            }
            catch (Exception ex)
            {
                if (ex.Message == "no busTravel with such Id!!")
                    DataSource.BusTravelList.Add(busTravel);
                else if (ex.Message == "busTravel is not valid!!")
                {
                    var t = from busTravelInput in DataSource.BusTravelList
                            where (busTravelInput.Id == busTravel.Id)
                            select busTravel;
                    t.ToList().First().Valid = true;
                }
                return;
            }
            throw new Exception("busTravel already exists!!!");
        }

        public BusTravel GetBusTravel(long id)
        {
            var t = from busTravel in DataSource.BusTravelList
                    where (busTravel.Id == id)
                    select busTravel;
            if (t.ToList().Count == 0)
                throw new Exception("no busTravel with such Id!!");
            if (!t.First().Valid)
                throw new Exception("busTravel is not valid!!");
            return t.ToList().First();
        }

        public BusTravel RequestBusTravel(Predicate<BusTravel> pr = null)
        {
            BusTravel ret = DataSource.BusTravelList.Find(busTravel => pr(busTravel));
            if (ret == null)
                throw new Exception("no busTravel that meets these conditions!");
            if (ret.Valid == false)
                throw new Exception("busTravel that meets these conditions is not valid");
            return ret.GetPropertiesFrom<BusTravel, BusTravel>();
        }


        public void UpdateFormalDepartureTime(DateTime formalDepartureTime, long id)
        {
            GetBusTravel(id).RealDepartureTime = formalDepartureTime;
        }

        public void UpdateRealDepartureTime(DateTime realDepartureTime, long id)
        {
            GetBusTravel(id).RealDepartureTime = realDepartureTime;
        }
        public void UpdateLastPassedStop(int lastPassedStop, long id)
        {
            GetBusTravel(id).LastPassedStop = lastPassedStop;
        }
        public void UpdateLastPassedStopTime(DateTime lastPassedStopTime, long id)
        {
            GetBusTravel(id).LastPassedStopTime = lastPassedStopTime;
        }
        public void UpdateNextStopTime(DateTime nextStopTime, long id)
        {
            GetBusTravel(id).NextStopTime = nextStopTime;
        }
        public void UpdateDriverId(long driverId, long id)
        {
            GetBusTravel(id).DriverId = driverId;
        }
        public void DeleteBusTravel(long id)
        {
            GetBusTravel(id).Valid = false;
        }
        public IEnumerable<BusTravel> GetAllBusTravels(Predicate<BusTravel> pr = null)
        {
            var cloneList = new List<BusTravel>();
            foreach (BusTravel busTravel in DataSource.BusTravelList)
            {
                if (busTravel.Valid == true)
                    cloneList.Add(busTravel.GetPropertiesFrom<BusTravel, BusTravel>());
            }
            return cloneList;
        }
    }
}
