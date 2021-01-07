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
    sealed class DLXML : IDal    //internal
    {
        #region singelton
        static readonly DLXML instance = new DLXML();
        static DLXML() { }// static ctor to ensure instance init is done just before first usage
        DLXML() { } // default => private
        public static DLXML Instance { get => instance; }// The public Instance property to use
        #endregion

        #region DS XML Files

        string busesPath = @"BusesXml.xml"; //XElement
        string busTravelsPath = @"BusTravelsXml.xml"; //XMLSerializer
        string linesPath = @"LinesXml.xml"; //XMLSerializer
        string lineDeparturesPath = @"LineDeparturesXml.xml"; //XMLSerializer
        string lineStationsPath = @"LineStationsXml.xml"; //XMLSerializer
        string sequentialStopInfoPath = @"SequentialStopInfoXml.xml"; //XMLSerializer
        string stopsPath = @"StopsXml.xml"; //XMLSerializer
        string usersPath = @"UsersXml.xml"; //XMLSerializer
        string userTravelPath = @"UserTravelXml.xml"; //XMLSerializer



        #endregion

        //#region Person
        //
        //public IEnumerable<DO.Person> GetAllPersons()
        //{
        //    XElement personsRootElem = XMLTools.LoadListFromXMLElement(personsPath);

        //    return (from p in personsRootElem.Elements()
        //            select new Person()
        //            {
        //                ID = Int32.Parse(p.Element("ID").Value),
        //                Name = p.Element("Name").Value,
        //                Street = p.Element("Street").Value,
        //                HouseNumber = Int32.Parse(p.Element("HouseNumber").Value),
        //                City = p.Element("City").Value,
        //                BirthDate = DateTime.Parse(p.Element("BirthDate").Value),
        //                PersonalStatus = (PersonalStatus)Enum.Parse(typeof(PersonalStatus), p.Element("PersonalStatus").Value)
        //            }
        //           );
        //}
        //public IEnumerable<DO.Person> GetAllPersonsBy(Predicate<DO.Person> predicate)
        //{
        //    XElement personsRootElem = XMLTools.LoadListFromXMLElement(personsPath);

        //    return from p in personsRootElem.Elements()
        //           let p1 = new Person()
        //           {
        //               ID = Int32.Parse(p.Element("ID").Value),
        //               Name = p.Element("Name").Value,
        //               Street = p.Element("Street").Value,
        //               HouseNumber = Int32.Parse(p.Element("HouseNumber").Value),
        //               City = p.Element("City").Value,
        //               BirthDate = DateTime.Parse(p.Element("BirthDate").Value),
        //               PersonalStatus = (PersonalStatus)Enum.Parse(typeof(PersonalStatus), p.Element("PersonalStatus").Value)
        //           }
        //           where predicate(p1)
        //           select p1;
        //}
        //public void AddPerson(DO.Person person)
        //{
        //    XElement personsRootElem = XMLTools.LoadListFromXMLElement(personsPath);

        //    XElement per1 = (from p in personsRootElem.Elements()
        //                     where int.Parse(p.Element("ID").Value) == person.ID
        //                     select p).FirstOrDefault();

        //    if (per1 != null)
        //        throw new DO.BadPersonIdException(person.ID, "Duplicate person ID");

        //    XElement personElem = new XElement("Person",
        //                           new XElement("ID", person.ID),
        //                           new XElement("Name", person.Name),
        //                           new XElement("Street", person.Street),
        //                           new XElement("HouseNumber", person.HouseNumber.ToString()),
        //                           new XElement("City", person.City),
        //                           new XElement("BirthDate", person.BirthDate),
        //                           new XElement("PersonalStatus", person.PersonalStatus.ToString()));

        //    personsRootElem.Add(personElem);

        //    XMLTools.SaveListToXMLElement(personsRootElem, personsPath);
        //}

        //public void DeletePerson(int id)
        //{
        //    XElement personsRootElem = XMLTools.LoadListFromXMLElement(personsPath);

        //    XElement per = (from p in personsRootElem.Elements()
        //                    where int.Parse(p.Element("ID").Value) == id
        //                    select p).FirstOrDefault();

        //    if (per != null)
        //    {
        //        per.Remove();
        //        XMLTools.SaveListToXMLElement(personsRootElem, personsPath);
        //    }
        //    else
        //        throw new DO.BadPersonIdException(id, $"bad person id: {id}");
        //}

        //public void UpdatePerson(DO.Person person)
        //{
        //    XElement personsRootElem = XMLTools.LoadListFromXMLElement(personsPath);

        //    XElement per = (from p in personsRootElem.Elements()
        //                    where int.Parse(p.Element("ID").Value) == person.ID
        //                    select p).FirstOrDefault();

        //    if (per != null)
        //    {
        //        per.Element("ID").Value = person.ID.ToString();
        //        per.Element("Name").Value = person.Name;
        //        per.Element("Street").Value = person.Street;
        //        per.Element("HouseNumber").Value = person.HouseNumber.ToString();
        //        per.Element("City").Value = person.City;
        //        per.Element("BirthDate").Value = person.BirthDate.ToString();
        //        per.Element("PersonalStatus").Value = person.PersonalStatus.ToString();

        //        XMLTools.SaveListToXMLElement(personsRootElem, personsPath);
        //    }
        //    else
        //        throw new DO.BadPersonIdException(person.ID, $"bad person id: {person.ID}");
        //}
        //#endregion Person


        #region Bus
        public void CreateBus(Bus bus)
        {
            throw new NotImplementedException();
        }

        public Bus RequestBus(Predicate<Bus> pr = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateBusKM(float kM, long licenseNumber)
        {
            throw new NotImplementedException();
        }

        public void UpdateBusFuel(float fuel, long licenseNumber)
        {
            throw new NotImplementedException();
        }

        public void UpdateBusStatus(int status, long licenseNumber)
        {
            throw new NotImplementedException();
        }

        public Bus GetBus(long licenseNumber)
        {
            throw new NotImplementedException();
        }

        public void DeleteBus(long licenseNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bus> GetAllBusses()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region BusTravel
        public void CreateBusTravel(BusTravel busTravel)
        {
            throw new NotImplementedException();
        }

        public BusTravel GetBusTravel(long id)
        {
            throw new NotImplementedException();
        }

        public BusTravel RequestBusTravel(Predicate<BusTravel> pr = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateDriverId(string driverId, long id)
        {
            throw new NotImplementedException();
        }

        public void DeleteBusTravel(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusTravel> GetAllBusTravels(Predicate<BusTravel> pr = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region LineDeparture
        public void UpdateFormalDepartureTime(DateTime formalDepartureTime, long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRealDepartureTime(DateTime realDepartureTime, long id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Stop
        public void CreateStop(Stop stop)
        {
            throw new NotImplementedException();
        }

        public Stop RequestStop(Predicate<Stop> pr = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateStopName(string name, long licenseNumber)
        {
            throw new NotImplementedException();
        }

        public void UpdateStopLongitude(double longitude, long licenseNumber)
        {
            throw new NotImplementedException();
        }

        public void UpdateStopLatitude(double latitude, long licenseNumber)
        {
            throw new NotImplementedException();
        }

        public Stop GetStop(long code)
        {
            throw new NotImplementedException();
        }

        public void DeleteStop(long code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stop> GetAllStops()
        {
            throw new NotImplementedException();
        }
        public void UpdateLastPassedStop(int lastPassedStop, long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateLastPassedStopTime(DateTime lastPassedStopTime, long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateNextStopTime(DateTime nextStopTime, long id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Line
        public void CreateLine(Line line)
        {
            throw new NotImplementedException();
        }

        public void CreateOppositeDirectionLine(Line line)
        {
            throw new NotImplementedException();
        }

        public Line RequestLine(Predicate<Line> pr = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineNumber(long number, long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineArea(string area, long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineFirstStop(long firstStop, long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineLastStop(long lastStop, long id)
        {
            throw new NotImplementedException();
        }

        public Line GetLine(long id)
        {
            throw new NotImplementedException();
        }

        public void DeleteLine(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Line> GetAllLines()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region LineDeparture
        public void CreateLineDeparture(LineDeparture lineDeparture)
        {
            throw new NotImplementedException();
        }

        public LineDeparture RequestLineDeparture(Predicate<LineDeparture> pr = null)
        {
            throw new NotImplementedException();
        }

        public LineDeparture GetLineDeparture(long id, DateTime time_Start)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineDepartureFrequency(long id, DateTime time_Start, int frequency)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineDepartureTime_End(long id, DateTime time_Start, DateTime time_End)
        {
            throw new NotImplementedException();
        }

        public void DeleteLineDeparture(long id, DateTime time_Start)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineDeparture> GetAllLineDepartures(Predicate<LineDeparture> pr = null)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region LineStation
        public void CreateLineStation(LineStation lineStation)
        {
            throw new NotImplementedException();
        }

        public LineStation RequestLineStation(Predicate<LineStation> pr = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineStationNumberInLine(long numberInLine, long code, long lineId)
        {
            throw new NotImplementedException();
        }

        public void DeleteLineStation(long code, long lineId, long numberInLine)
        {
            throw new NotImplementedException();
        }

        public LineStation GetLineStation(long code, long lineId, long numberInLine)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineStation> GetAllLineStations(Predicate<LineStation> pr = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region SequentialStopInfo
        public void CreateSequentialStopInfo(SequentialStopInfo sequentialStopInfo)
        {
            throw new NotImplementedException();
        }

        public SequentialStopInfo RequestSequentialStopInfo(Predicate<SequentialStopInfo> pr)
        {
            throw new NotImplementedException();
        }

        public void UpdateSequentialStopInfoDistance(long firstId, long secondId, double distance)
        {
            throw new NotImplementedException();
        }

        public void UpdateSequentialStopInfoTravelTime(long firstId, long secondId, TimeSpan travelTime)
        {
            throw new NotImplementedException();
        }

        public void DeleteSequentialStopInfo(long firstId, long secondId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SequentialStopInfo> GetAllSequentialStopInfo()
        {
            throw new NotImplementedException();
        }

        public SequentialStopInfo GetSequentialStopInfo(long fCode, long sCode)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region User

        public User GetUser(string password)
        {
            XElement userRootElem = XMLTools.LoadListFromXMLElement(usersPath);

            User myUser = (from temUser in userRootElem.Elements()
                                  where temUser.Element("Password").Value == password
                                  select new User()
                                  {
                                      Valid = bool.Parse(temUser.Element("Valid").Value),
                                      UserName = temUser.Element("UserName").Value,
                                      Password = temUser.Element("Password").Value
                                      // Permission = 

                                  }
                                  ).FirstOrDefault();
            if (myUser == null)
            {
                throw new DO.DOBadUserIdException(password, $"bad user id: {password}");
            }
            return myUser;

        }


        // public DO.Person GetPerson(int id)
        //{
        //    XElement personsRootElem = XMLTools.LoadListFromXMLElement(personsPath);

        //    Person p = (from per in personsRootElem.Elements()
        //                where int.Parse(per.Element("ID").Value) == id
        //                select new Person()
        //                {
        //                    ID = Int32.Parse(per.Element("ID").Value),
        //                    Name = per.Element("Name").Value,
        //                    Street = per.Element("Street").Value,
        //                    HouseNumber = Int32.Parse(per.Element("HouseNumber").Value),
        //                    City = per.Element("City").Value,
        //                    BirthDate = DateTime.Parse(per.Element("BirthDate").Value),
        //                    PersonalStatus = (PersonalStatus)Enum.Parse(typeof(PersonalStatus), per.Element("PersonalStatus").Value)
        //                }
        //                ).FirstOrDefault();

        //    if (p == null)
        //        throw new DO.BadPersonIdException(id, $"bad person id: {id}");

        //    return p;
        //}
        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User RequestUser(Predicate<User> pr = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateName(string name, string nameId)
        {
            throw new NotImplementedException();
        }

        //public void UpdatePassword(string password, string nameId)
        //{
        //    throw new NotImplementedException();
        //}

        public void DeleteUser(string nameId)
        {
            throw new NotImplementedException();
        }

       
        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region UserTravel
        public void CreateUserTravel(UserTravel user_Travel)
        {
            throw new NotImplementedException();
        }

        public UserTravel RequestUserTravel(long Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserTravel(UserTravel user_Travel)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserTravel(UserTravel user_Travel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTravel> GetAllUserTravels(Predicate<UserTravel> pr = null)
        {
            throw new NotImplementedException();
        }

        public void UpdatePassword(string password, string nameId)
        {
            throw new NotImplementedException();
        }

        #endregion



    }
}