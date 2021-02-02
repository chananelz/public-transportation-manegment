using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalApi;
using DO;


namespace DL
{
    public partial class DLXML : IDal
    {


        #region BusTravel
        public void CreateBusTravel(BusTravel busTravel)
        {
            List<BusTravel> BusTravelList = XMLTools.LoadListFromXMLSerializer<BusTravel>(busTravelsPath);

            busTravel.Valid = true;
           // busTravel.Id = Configuration.Bus_TravelCounter + 20; //בקובץ אקסממל יש כבר 20 "אוטובוסים בנסיעה
            try
            {
              //  GetBusTravel(busTravel.Id);
              var id = RequestBusTravel(bt => bt.FormalDepartureTime == busTravel.FormalDepartureTime && bt.LineId == busTravel.LineId).Id;
            }
            catch (Exception ex)
            {
                if (ex.Message == "no busTravel with such Id!!")
                {
                    busTravel.Id = Configuration.Bus_TravelCounter;
                    BusTravelList.Add(busTravel);
                }
                else if (ex.Message == "busTravel is not valid!!")
                {
                    BusTravelList.Find(busTravelInput => busTravelInput.Id == busTravel.Id).Valid = true;
                }
                XMLTools.SaveListToXMLSerializer(BusTravelList, busTravelsPath);
                return;
            }
            throw new Exception("busTravel already exists!!!");
        }

        public BusTravel GetBusTravel(long id)
        {
            List<BusTravel> BusTravelList = XMLTools.LoadListFromXMLSerializer<BusTravel>(busTravelsPath);

            var t = from busTravel in BusTravelList
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
            List<BusTravel> BusTravelList = XMLTools.LoadListFromXMLSerializer<BusTravel>(busTravelsPath);

            BusTravel ret = BusTravelList.Find(busTravel => pr(busTravel));
            if (ret == null)
                throw new Exception("no busTravel that meets these conditions!");
            if (ret.Valid == false)
                throw new Exception("busTravel that meets these conditions is not valid");
            return ret;
        }

        public void UpdateDriverId(string driverId, long id)
        {
            List<BusTravel> BusTravelList = XMLTools.LoadListFromXMLSerializer<BusTravel>(busTravelsPath);

            GetBusTravel(id); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות

            BusTravelList.Find(p => p.Id == id).DriverId = driverId;
            XMLTools.SaveListToXMLSerializer(BusTravelList, busTravelsPath);
        }

        public void DeleteBusTravel(long id)
        {
            List<BusTravel> BusTravelList = XMLTools.LoadListFromXMLSerializer<BusTravel>(busTravelsPath);

            GetBusTravel(id); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות

            BusTravelList.Find(p => p.Id == id).Valid = false;
            XMLTools.SaveListToXMLSerializer(BusTravelList, busTravelsPath);
        }

        public IEnumerable<BusTravel> GetAllBusTravels(Predicate<BusTravel> pr = null)
        {
            List<BusTravel> BusTravelList = XMLTools.LoadListFromXMLSerializer<BusTravel>(busTravelsPath);
            var temList = new List<BusTravel>();

            foreach (BusTravel busTravel in BusTravelList)
            {
                if (busTravel.Valid == true)
                    temList.Add(busTravel);
            }
            return temList;

        }

        public void UpdateNextStopTime(DateTime nextStopTime, long id)
        {
            List<BusTravel> BusTravelList = XMLTools.LoadListFromXMLSerializer<BusTravel>(busTravelsPath);

            GetBusTravel(id); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות

            BusTravelList.Find(p => p.Id == id).NextStopTime = nextStopTime;
            XMLTools.SaveListToXMLSerializer(BusTravelList, busTravelsPath);

        }

        public void UpdateFormalDepartureTime(DateTime formalDepartureTime, long id)
        {
            List<BusTravel> BusTravelList = XMLTools.LoadListFromXMLSerializer<BusTravel>(busTravelsPath);

            GetBusTravel(id); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות

            BusTravelList.Find(p => p.Id == id).RealDepartureTime = formalDepartureTime;
            XMLTools.SaveListToXMLSerializer(BusTravelList, busTravelsPath);
        }



        public void UpdateRealDepartureTime(DateTime realDepartureTime, long id)
        {
            List<BusTravel> BusTravelList = XMLTools.LoadListFromXMLSerializer<BusTravel>(busTravelsPath);

            GetBusTravel(id); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות

            BusTravelList.Find(p => p.Id == id).RealDepartureTime = realDepartureTime;
            XMLTools.SaveListToXMLSerializer(BusTravelList, busTravelsPath);
        }

        public void UpdateLastPassedStopTime(DateTime lastPassedStopTime, long id)
        {
            List<BusTravel> BusTravelList = XMLTools.LoadListFromXMLSerializer<BusTravel>(busTravelsPath);

            GetBusTravel(id); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות

            BusTravelList.Find(p => p.Id == id).LastPassedStopTime = lastPassedStopTime;
            XMLTools.SaveListToXMLSerializer(BusTravelList, busTravelsPath);
        }

        public void UpdateLastPassedStop(long lastPassedStop, long id)
        {
            List<BusTravel> BusTravelList = XMLTools.LoadListFromXMLSerializer<BusTravel>(busTravelsPath);

            GetBusTravel(id); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות

            BusTravelList.Find(p => p.Id == id).LastPassedStop = lastPassedStop;
            XMLTools.SaveListToXMLSerializer(BusTravelList, busTravelsPath);
        }

        #endregion


    }
}
