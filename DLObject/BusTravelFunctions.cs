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
        /// adds a new bus in travel to database
        /// </summary>
        /// <param name="busTravel">bus travel to be added to the database</param>
        



        ///    לשנות ב               xml!!!!!!!!!!!!!!! //בוצע חננאל 2.2


        public void CreateBusTravel(BusTravel busTravel)
        {

            busTravel.Valid = true;
            //busTravel.Id = Configuration.Bus_TravelCounter;
            try
            {
                //GetBusTravel(busTravel.Id);
                var id = RequestBusTravel(bt => bt.FormalDepartureTime == busTravel.FormalDepartureTime && bt.LineId == busTravel.LineId).Id;
            }
            catch (Exception ex)
            {
                if (ex.Message == "no busTravel that meets these conditions!")
                {
                    busTravel.Id = Configuration.Bus_TravelCounter;
                    DataSource.BusTravelList.Add(busTravel);
                }
                else if (ex.Message == "busTravel that meets these conditions is not valid")
                {
                    var a = DataSource.BusTravelList.Find(bt => bt.FormalDepartureTime == busTravel.FormalDepartureTime && bt.LineId == busTravel.LineId);
                    a.Valid = true;
                }
                return;
            }
            throw new Exception("busTravel already exists!!!");
        }
        /// <summary>
        /// helper function that get requested bus travel
        /// </summary>
        /// <param name="id">id of bus travel</param>
        /// <returns>the wanted bus travel</returns>
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
        /// <summary>
        /// request a bus Travel according to a predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns>the wanted bus travel</returns>
        public BusTravel RequestBusTravel(Predicate<BusTravel> pr = null)
        {
            BusTravel ret = DataSource.BusTravelList.Find(busTravel => pr(busTravel));
            if (ret == null)
                throw new Exception("no busTravel that meets these conditions!");
            if (ret.Valid == false)
                throw new Exception("busTravel that meets these conditions is not valid");
            return ret.GetPropertiesFrom<BusTravel, BusTravel>();
        }

        /// <summary>
        /// update bus travels formal departure time
        /// </summary>
        /// <param name="formalDepartureTime">formal time to be updated</param>
        /// <param name="id">id of bus travel</param>
        public void UpdateFormalDepartureTime(DateTime formalDepartureTime, long id)
        {
            GetBusTravel(id).RealDepartureTime = formalDepartureTime;
        }
        /// <summary>
        /// update bus travels real departures time
        /// </summary>
        /// <param name="realDepartureTime">realDepartureTime to be updated</param>
        /// <param name="id">id of bus travel</param>
        public void UpdateRealDepartureTime(DateTime realDepartureTime, long id)
        {
            GetBusTravel(id).RealDepartureTime = realDepartureTime;
        }
        /// <summary>
        /// update bus travels lasst passed stop
        /// </summary>
        /// <param name="lastPassedStop">lastPassedStop to be updated</param>
        /// <param name="id">id of bus travel</param>
        public void UpdateLastPassedStop(long lastPassedStop, long id)
        {
            GetBusTravel(id).LastPassedStop = lastPassedStop;
        }
        /// <summary>
        /// update bus travels last passed stop time
        /// </summary>
        /// <param name="lastPassedStopTime">lastPassedStopTime to be updated</param>
        /// <param name="id">id of bus travel</param>
        public void UpdateLastPassedStopTime(DateTime lastPassedStopTime, long id)
        {
            GetBusTravel(id).LastPassedStopTime = lastPassedStopTime;
        }

        /// <summary>
        /// update bus travels next stop time
        /// </summary>
        /// <param name="nextStopTime">nextStopTime  to be updated</param>
        /// <param name="id">id of bus travel</param>
        public void UpdateNextStopTime(DateTime nextStopTime, long id)
        {
            GetBusTravel(id).NextStopTime = nextStopTime;
        }
        /// <summary>
        /// update bus travels driver id - the id is the username
        /// </summary>
        /// <param name="driverId"></param>
        /// <param name="id">id of bus travel</param>
        public void UpdateDriverId(string driverId, long id)
        {
            GetBusTravel(id).DriverId = driverId;
        }
        /// <summary>
        /// delete a bus travel according to its id
        /// </summary>
        /// <param name="id">id of bus travel</param>
        public void DeleteBusTravel(long id)
        {
            GetBusTravel(id).Valid = false;
        }
        /// <summary>
        /// get all bus travels according to a predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns>all bus travels the responde to the predicatee</returns>
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
