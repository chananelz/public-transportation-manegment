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


        #region Bus
        public void CreateBus(Bus bus)
        {
            List<Bus> BusesList = XMLTools.LoadListFromXMLSerializer<Bus>(busesPath);
            bus.Valid = true;
            Bus a = new Bus();
            try
            {
                a = GetBus(bus.LicenseNumber);
            }
            catch (DOBadBusIdException ex)                                             //try "BusException" and check if it work.
            {
                if (ex.Message == "no bus with such license number!!")
                {
                    BusesList.Add(bus);
                }
                else if (ex.Message == "bus is not valid!!")
                {
                    BusesList.Find(bus1 => bus1.LicenseNumber == bus.LicenseNumber).Valid = true;
                }
                XMLTools.SaveListToXMLSerializer(BusesList, busesPath);
                return;
            }
            throw new DOBadBusIdException(bus.LicenseNumber, "bus already exists!!!");

        }

        public Bus RequestBus(Predicate<Bus> pr = null)
        {
            List<Bus> BusesList = XMLTools.LoadListFromXMLSerializer<Bus>(busesPath);

            Bus ret = BusesList.Find(bus => pr(bus));
            if (ret == null)
                throw new DOBusException("no bus that meets these conditions!");
            if (ret.Valid == false)
                throw new DOBusException("bus that meets these conditions is not valid");
            return ret;
        }

        public void UpdateBusKM(float kM, long licenseNumber)
        {
            List<Bus> BusesList = XMLTools.LoadListFromXMLSerializer<Bus>(busesPath);

            GetBus(licenseNumber); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות

            BusesList.Find(p => p.LicenseNumber == licenseNumber).KM = kM;
            XMLTools.SaveListToXMLSerializer(BusesList, busesPath);
        }

        public void UpdateBusFuel(float fuel, long licenseNumber)
        {
            List<Bus> BusesList = XMLTools.LoadListFromXMLSerializer<Bus>(busesPath);

            GetBus(licenseNumber); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות

            BusesList.Find(p => p.LicenseNumber == licenseNumber).Fuel = fuel;
            XMLTools.SaveListToXMLSerializer(BusesList, busesPath);
        }

        public void UpdateBusStatus(int status, long licenseNumber)
        {
            //***************************CONVERT INT TO STATUS!!!!!!!!!!!!!************
            status update;
            switch (status)
            {
                case 0:
                    update = DO.status.TRAVELING;
                    break;
                case 1:
                    update = DO.status.READY_FOR_DRIVE;
                    break;
                case 2:
                    update = DO.status.TREATING;
                    break;
                case 3:
                    update = DO.status.REFULING;
                    break;
                default:
                    throw new Exception("wrong status!!");
            }

            List<Bus> BusesList = XMLTools.LoadListFromXMLSerializer<Bus>(busesPath);

            GetBus(licenseNumber); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות

            BusesList.Find(p => p.LicenseNumber == licenseNumber).Status = update;
            XMLTools.SaveListToXMLSerializer(BusesList, busesPath);
        }

        public Bus GetBus(long licenseNumber)
        {
            List<Bus> BusesList = XMLTools.LoadListFromXMLSerializer<Bus>(busesPath);
            var t = from bus in BusesList
                    where (bus.LicenseNumber == licenseNumber)
                    select bus;
            if (t.ToList().Count == 0)
                throw new DOBadBusIdException(licenseNumber, "no bus with such license number!!");
            if (!t.First().Valid)
                throw new DOBadBusIdException(licenseNumber, "bus is not valid!!");
            return t.ToList().First();
        }

        public void DeleteBus(long licenseNumber)
        {
            List<Bus> BusesList = XMLTools.LoadListFromXMLSerializer<Bus>(busesPath);

            GetBus(licenseNumber); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות

            BusesList.Find(p => p.LicenseNumber == licenseNumber).Valid = false;
            XMLTools.SaveListToXMLSerializer(BusesList, busesPath);

        }

        public IEnumerable<Bus> GetAllBusses()
        {
            List<Bus> BusesList = XMLTools.LoadListFromXMLSerializer<Bus>(busesPath);
            var temList = new List<Bus>();

            foreach (Bus bus in BusesList)
            {
                if (bus.Valid == true)
                    temList.Add(bus);
            }
            return temList;

        }
        #endregion
    }
}
