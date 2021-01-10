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

        string busesPath = @"BusesXml.xml"; //XMLSerializer
        string busTravelsPath = @"BusTravelXml.xml"; //XMLSerializer
        string lineDeparturesPath = @"LineDepartureXml.xml"; //XMLSerializer
        string lineStationsPath = @"LineStationXml.xml"; //XMLSerializer
        string linesPath = @"LineXml.xml"; //XMLSerializer
        string sequentialStopInfoPath = @"SequentialStopInfoXml.xml"; //XMLSerializer
        string stopsPath = @"StopXml.xml"; //XMLSerializer
        string usersPath = @"UserXml.xml"; //XElement
        string userTravelPath = @"UserTravelXml.xml"; //XMLSerializer





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

        #region BusTravel
        public void CreateBusTravel(BusTravel busTravel)
        {
            List<BusTravel> BusTravelList = XMLTools.LoadListFromXMLSerializer<BusTravel>(busTravelsPath);

            busTravel.Valid = true;
            busTravel.Id = Configuration.Bus_TravelCounter + 20; //בקובץ אקסממל יש כבר 20 "אוטובוסים בנסיעה
            try
            {
                GetBusTravel(busTravel.Id);
            }
            catch (Exception ex)
            {
                if (ex.Message == "no busTravel with such Id!!")
                {
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

        public void UpdateLastPassedStop(int lastPassedStop, long id)
        {
            List<BusTravel> BusTravelList = XMLTools.LoadListFromXMLSerializer<BusTravel>(busTravelsPath);

            GetBusTravel(id); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות

            BusTravelList.Find(p => p.Id == id).LastPassedStop = lastPassedStop;
            XMLTools.SaveListToXMLSerializer(BusTravelList, busTravelsPath);
        }

        #endregion

        #region Line

        /// <summary>
        ///add new line to database
        /// </summary>
        /// <param name="line"></param>
        public void CreateLine(Line line)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            line.Id = Configuration.LineCounter + 10;//בקובץ אקסממל יש כבר 
            try
            {
                GetLineByNumber(line.Number);
            }
            catch (DOBadLineIdException ex)
            {
                if (ex.Message == "line doesn't  exist!!")
                {
                    LineList.Add(line);
                }

                else if (ex.Message == "line is not valid!!")
                {
                    LineList.Find(line1 => line1.Number == line.Number).Valid = true;
                }
                XMLTools.SaveListToXMLSerializer(LineList, linesPath);
                return;
            }
            throw new DOBadLineIdException(line.Id, "line already exists!!!");
        }

        public Line GetLineByNumber(long number)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);

            var t = from line in LineList
                    where (line.Number == number)
                    select line;
            if (t.ToList().Count == 0)
                throw new DOBadLineIdException(number, "line doesn't  exist!!");
            if (!t.First().Valid)
                throw new DOBadLineIdException(number, "line is not valid!!");
            return t.ToList().First();
        }

        public void CreateOppositeDirectionLine(Line line)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            line.Valid = true;
            line.Id = Configuration.LineCounter + 10;
            LineList.Add(line);
            XMLTools.SaveListToXMLSerializer(LineList, linesPath);
        }

        /// <summary>
        /// request a Line according to a predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public Line RequestLine(Predicate<Line> pr = null)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            Line ret = LineList.Find(line => pr(line));
            if (ret == null)
                throw new DOLineException("no line that meets these conditions!");
            if (ret.Valid == false)
                throw new DOLineException("line that meets these conditions is not valid");
            return ret;
        }

        /// <summary>
        /// update in database
        /// </summary>
        /// <param name="number"></param>
        /// <param name="id"></param>
        public void UpdateLineNumber(long number, long id)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            GetLine(id);
            LineList.Find(p => p.Id == id).Number = number;

            XMLTools.SaveListToXMLSerializer(LineList, linesPath);
        }

        public void UpdateLineArea(string area, long id)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            GetLine(id);
            LineList.Find(p => p.Id == id).Area = area;

            XMLTools.SaveListToXMLSerializer(LineList, linesPath);
        }

        /// <summary>
        /// update firstStop in database
        /// </summary>
        /// <param name="firstStop"></param>
        /// <param name="id"></param>
        public void UpdateLineFirstStop(long firstStop, long id)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            GetLine(id);
            LineList.Find(p => p.Id == id).FirstStop = firstStop;

            XMLTools.SaveListToXMLSerializer(LineList, linesPath);
        }

        /// <summary>
        /// update lastStop in database
        /// </summary>
        /// <param name="lastStop"></param>
        /// <param name="id"></param>
        public void UpdateLineLastStop(long lastStop, long id)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            GetLine(id);
            LineList.Find(p => p.Id == id).LastStop = lastStop;

            XMLTools.SaveListToXMLSerializer(LineList, linesPath);
        }

        /// <summary>
        /// request a Line according to id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Line GetLine(long id)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            var t = (from line in LineList
                     where (line.Id == id)
                     select line).ToList();
            if (t.ToList().Count == 0)
                throw new DOBadLineIdException(id, "line doesn't  exist!!");
            if (!t.First().Valid)
                throw new DOBadLineIdException(id, "line is not valid!!");
            return t.ToList().First();
        }

        /// <summary>
        /// deletes a line
        /// </summary>
        /// <param name="id"></param>
        public void DeleteLine(long id)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            GetLine(id);
            LineList.Find(p => p.Id == id).Valid = false;

            XMLTools.SaveListToXMLSerializer(LineList, linesPath);
        }

        /// <summary>
        /// gets all lines
        /// </summary>
        /// <returns></returns>

        public IEnumerable<Line> GetAllLines()
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);

            var temList = new List<Line>();

            foreach (Line line in LineList)
            {
                if (line.Valid == true)
                    temList.Add(line);
            }
            return temList;

        }
        #endregion

        #region LineStation
        /// <summary>
        /// add new lineStation to database
        /// </summary>
        /// <param name="lineStation"></param>
        public void CreateLineStation(LineStation lineStation)
        {
            List<LineStation> LineStationList = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);
            LineStationList.Add(lineStation);
            XMLTools.SaveListToXMLSerializer(LineStationList, lineStationsPath);

        }

        /// <summary>
        /// request a LineStation according to a predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public LineStation RequestLineStation(Predicate<LineStation> pr = null)
        {
            List<LineStation> LineStationList = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);

            LineStation ret = LineStationList.Find(line => pr(line));
            if (ret == null)
                throw new Exception("no line that meets these conditions!");
            if (ret == null)
                throw new Exception("line that meets these conditions is not valid");
            return ret;
        }

        /// <summary>
        /// update numberInLine in database
        /// </summary>
        /// <param name="numberInLine"></param>
        /// <param name="code"></param>
        /// <param name="lineId"></param>
        public void UpdateLineStationNumberInLine(long numberInLine, long code, long lineId) //?
        {
            List<LineStation> LineStationList = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);
            GetLineStation(lineId, code, numberInLine);
            LineStationList.Find(p => (p.Code == code) && (p.LineId == lineId)).NumberInLine = numberInLine;
            XMLTools.SaveListToXMLSerializer(LineStationList, lineStationsPath);

        }

        /// <summary>
        /// sets line station valid to false
        /// </summary>
        /// <param name="lineId"></param>
        /// <param name="code"></param>
        /// <param name="numberInLine"></param>
        public void DeleteLineStation(long code, long lineId, long numberInLine) //?
        {
            List<LineStation> LineStationList = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);
            GetLineStation(lineId, code, numberInLine);
            LineStationList.Find(p => (p.Code == code) && (p.LineId == lineId)).Valid = false;
            XMLTools.SaveListToXMLSerializer(LineStationList, lineStationsPath);
        }

        /// <summary>
        /// helper function to get a linestation
        /// </summary>
        /// <param name="lineId"></param>
        /// <param name="code"></param>
        /// <param name="numberInLine"></param>
        /// <returns></returns>
        public LineStation GetLineStation(long code, long lineId, long numberInLine)
        {
            List<LineStation> LineStationList = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);
            GetLineStation(lineId, code, numberInLine);
            LineStation t = LineStationList.Find(p => (p.Code == code) && (p.LineId == lineId));
            if (t == null)
                throw new Exception("no such line!!");
            if (!t.Valid)
                throw new Exception("line is not valid!!");
            return t;
        }

        /// <summary>
        /// gets all line stations
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public IEnumerable<LineStation> GetAllLineStations(Predicate<LineStation> pr = null)
        {
            List<LineStation> LineStationList = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);
            var temList = new List<LineStation>();

            foreach (LineStation lineStation in LineStationList)
            {
                if (lineStation.Valid == true)
                    temList.Add(lineStation);
            }
            return temList;

        }

        #endregion


        #region LineDeparture

        /// <summary>
        /// add new line departure to database
        /// </summary>
        /// <param name="lineDeparture"></param>
        public void CreateLineDeparture(LineDeparture lineDeparture)
        {


            List<LineDeparture> LineDepartureList = XMLTools.LoadListFromXMLSerializer<LineDeparture>(lineDeparturesPath);
            LineDepartureList.Add(lineDeparture);
            XMLTools.SaveListToXMLSerializer(LineDepartureList, lineDeparturesPath);

        }

        /// <summary>
        /// request a LineDeparture according to a predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public LineDeparture RequestLineDeparture(Predicate<LineDeparture> pr = null)
        {
            List<LineDeparture> LineDepartureList = XMLTools.LoadListFromXMLSerializer<LineDeparture>(lineDeparturesPath);
            LineDeparture ret = LineDepartureList.Find(lineDeparture => pr(lineDeparture));


            if (ret == null)
                throw new Exception("no lineDeparture that meets these conditions!");
            if (ret.Valid == false)
                throw new Exception("lineDeparture that meets these conditions is not valid");
            return ret;
        }

        /// <summary>
        /// request a LineDeparture according to a predicate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="time_Start"></param>
        /// <returns></returns>
        public LineDeparture GetLineDeparture(long id, DateTime time_Start)
        {
            List<LineDeparture> LineDepartureList = XMLTools.LoadListFromXMLSerializer<LineDeparture>(lineDeparturesPath);

            var t = from lineDeparture in LineDepartureList
                    where (lineDeparture.Id == id)
                    select lineDeparture;
            if (t.ToList().Count == 0)
                throw new Exception("no bus with such license number!!");
            if (!t.First().Valid)
                throw new Exception("bus is not valid!!");

            return t.ToList().First();
        }

        /// <summary>
        /// update linedepartuer frquency in database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="time_Start"></param>
        /// <param name="frequency"></param>
        public void UpdateLineDepartureFrequency(long id, DateTime time_Start, int frequency)
        {
            List<LineDeparture> LineDepartureList = XMLTools.LoadListFromXMLSerializer<LineDeparture>(lineDeparturesPath);

            GetLineDeparture(id, time_Start); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות
            LineDepartureList.Find(p => (p.Id == id) && (p.Time_Start == time_Start)).Frequency = frequency;
            XMLTools.SaveListToXMLSerializer(LineDepartureList, lineDeparturesPath);
        }
        /// <summary>
        /// update time_End in database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="time_Start"></param>
        /// <param name="time_End"></param>
        public void UpdateLineDepartureTime_End(long id, DateTime time_Start, DateTime time_End)
        {
            List<LineDeparture> LineDepartureList = XMLTools.LoadListFromXMLSerializer<LineDeparture>(lineDeparturesPath);

            GetLineDeparture(id, time_Start); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות
            LineDepartureList.Find(p => (p.Id == id) && (p.Time_Start == time_Start)).Time_End = time_End;
            XMLTools.SaveListToXMLSerializer(LineDepartureList, lineDeparturesPath);
        }
        /// <summary>
        /// delete line departure in database acording to id and timestart
        /// </summary>
        /// <param name="id">id of lineDeparture</param>
        /// <param name="time_Start"></param>
        public void DeleteLineDeparture(long id, DateTime time_Start)
        {
            List<LineDeparture> LineDepartureList = XMLTools.LoadListFromXMLSerializer<LineDeparture>(lineDeparturesPath);

            GetLineDeparture(id, time_Start); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות
            LineDepartureList.Find(p => (p.Id == id) && (p.Time_Start == time_Start)).Valid = false;
            XMLTools.SaveListToXMLSerializer(LineDepartureList, lineDeparturesPath);
        }

        /// <summary>
        /// get all line departures tha responde to this predicate
        /// </summary>
        /// <param name="pr">predicate</param>
        /// <returns>Ienumarble of line departures that responde to the predicate</returns>
        public IEnumerable<LineDeparture> GetAllLineDepartures(Predicate<LineDeparture> pr = null)
        {
            List<LineDeparture> LineDepartureList = XMLTools.LoadListFromXMLSerializer<LineDeparture>(lineDeparturesPath);

            if (pr == null)
                return LineDepartureList;
            else
                return from ld in LineDepartureList
                       where (pr(ld))
                       select ld;
        }
        #endregion


        #region SequentialStopInfo

        /// <summary>
        /// add new sequentialStopInfo to database
        /// </summary>
        /// <param name="sequentialStopInfo"></param>
        public void CreateSequentialStopInfo(SequentialStopInfo sequentialStopInfo)
        {

            List<SequentialStopInfo> SequentialStopInfoList = XMLTools.LoadListFromXMLSerializer<SequentialStopInfo>(sequentialStopInfoPath);
            sequentialStopInfo.Valid = true;
            try
            {
                GetSequentialStopInfo(sequentialStopInfo.StationCodeF, sequentialStopInfo.StationCodeS);
            }
            catch (Exception ex)
            {
                if (ex.Message == "no SequentialStopInfo with such license number!!")
                    SequentialStopInfoList.Add(sequentialStopInfo);
                else if (ex.Message == "SequentialStopInfoList is not valid!!")
                {
                    SequentialStopInfoList.Find(seqStopInf => seqStopInf.StationCodeF == sequentialStopInfo.StationCodeF && seqStopInf.StationCodeS == sequentialStopInfo.StationCodeS).Valid = true;
                }
                XMLTools.SaveListToXMLSerializer(SequentialStopInfoList, sequentialStopInfoPath);
                return;
            }
            throw new Exception("bus already exists!!!");
        }

        /// <summary>
        /// request a SequentialStopInfo according to a predicate
        /// </summary>
        /// <param name="firstId"></param>
        /// <param name="secondId"></param>
        /// <returns></returns>
        public SequentialStopInfo RequestSequentialStopInfo(Predicate<SequentialStopInfo> pr)
        {
            List<SequentialStopInfo> SequentialStopInfoList = XMLTools.LoadListFromXMLSerializer<SequentialStopInfo>(sequentialStopInfoPath);
            SequentialStopInfo ret = SequentialStopInfoList.Find(seqStop => pr(seqStop));
            if (ret == null)
                throw new Exception("no seqStop that meets these conditions!");
            if (ret.Valid == false)
                throw new Exception("seqStop that meets these conditions is not valid");
            return ret;
        }

        /// <summary>
        /// update sequentialStopInfo in database
        /// </summary>
        /// <param name="sequentialStopInfo"></param>

        public void UpdateSequentialStopInfoDistance(long firstId, long secondId, double distance)
        {
            List<SequentialStopInfo> SequentialStopInfoList = XMLTools.LoadListFromXMLSerializer<SequentialStopInfo>(sequentialStopInfoPath);
            GetSequentialStopInfo(firstId, secondId);
            SequentialStopInfoList.Find(seqStopInf => seqStopInf.StationCodeF == firstId && seqStopInf.StationCodeS == secondId).Distance = distance;
            XMLTools.SaveListToXMLSerializer(SequentialStopInfoList, sequentialStopInfoPath);

        }

        /// <summary>
        /// update sequentialStopInfo in database
        /// </summary>
        /// <param name="sequentialStopInfo"></param>
        public void UpdateSequentialStopInfoTravelTime(long firstId, long secondId, TimeSpan travelTime)
        {
            List<SequentialStopInfo> SequentialStopInfoList = XMLTools.LoadListFromXMLSerializer<SequentialStopInfo>(sequentialStopInfoPath);
            GetSequentialStopInfo(firstId, secondId);
            SequentialStopInfoList.Find(seqStopInf => seqStopInf.StationCodeF == firstId && seqStopInf.StationCodeS == secondId).TravelTime = travelTime;
            XMLTools.SaveListToXMLSerializer(SequentialStopInfoList, sequentialStopInfoPath);
        }


        /// <summary>
        /// sets sequential  stop info valid to false
        /// </summary>
        /// <param name="sequentialStopInfo"></param>
        public void DeleteSequentialStopInfo(long firstId, long secondId)
        {
            List<SequentialStopInfo> SequentialStopInfoList = XMLTools.LoadListFromXMLSerializer<SequentialStopInfo>(sequentialStopInfoPath);
            GetSequentialStopInfo(firstId, secondId);
            SequentialStopInfoList.Find(seqStopInf => seqStopInf.StationCodeF == firstId && seqStopInf.StationCodeS == secondId).Valid = false;
            XMLTools.SaveListToXMLSerializer(SequentialStopInfoList, sequentialStopInfoPath);
        }

        /// <summary>
        /// gets all stops info
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public IEnumerable<SequentialStopInfo> GetAllSequentialStopInfo()
        {
            List<SequentialStopInfo> SequentialStopInfoList = XMLTools.LoadListFromXMLSerializer<SequentialStopInfo>(sequentialStopInfoPath);
            var myList = new List<SequentialStopInfo>();
            foreach (SequentialStopInfo seqStop in SequentialStopInfoList)
            {
                if (seqStop.Valid == true)
                    myList.Add(seqStop);
            }
            return myList;

        }

        public SequentialStopInfo GetSequentialStopInfo(long fCode, long sCode)
        {
            List<SequentialStopInfo> SequentialStopInfoList = XMLTools.LoadListFromXMLSerializer<SequentialStopInfo>(sequentialStopInfoPath);
            var t = from seqStop in SequentialStopInfoList
                    where (seqStop.StationCodeF == fCode && seqStop.StationCodeS == sCode)
                    select seqStop;
            if (t.ToList().Count == 0)
                throw new Exception("no SequentialStopInfo with such license number!!");
            if (!t.First().Valid)
                throw new Exception("SequentialStopInfoList is not valid!!");
            return t.ToList().First();
        }

        #endregion


        #region Stop

        /// <summary>
        /// add new stop to database
        /// </summary>
        /// <param name="stop"></param>
        public void CreateStop(Stop stop)
        {
            List<Stop> StopList = XMLTools.LoadListFromXMLSerializer<Stop>(stopsPath);
            stop.Valid = true;
            try
            {
                GetStop(stop.StopCode);
            }
            catch (DOStopException ex)
            {
                if (ex.Message == "no stop with such license number!!")
                    StopList.Add(stop);
                else if (ex.Message == "stop is not valid!!")
                {
                    StopList.Find(stopInput => stopInput.StopCode == stop.StopCode).Valid = true;
                }
                XMLTools.SaveListToXMLSerializer(StopList, stopsPath);
                return;
            }
            throw new DOBadStopIdException(stop.StopCode, "stop already exists!!!");


        }

        /// <summary>
        /// request a Stop according to a predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public Stop RequestStop(Predicate<Stop> pr = null)
        {
            List<Stop> StopList = XMLTools.LoadListFromXMLSerializer<Stop>(stopsPath);
            Stop ret = StopList.Find(stop => pr(stop));
            if (ret == null)
                throw new DOStopException("no stop that meets these conditions!");
            if (ret.Valid == false)
                throw new DOStopException("stop that meets these conditions is not valid");
            return ret;

        }

        /// <summary>
        /// update name in database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="licenseNumber"></param>
        public void UpdateStopName(string name, long code)
        {
            List<Stop> StopList = XMLTools.LoadListFromXMLSerializer<Stop>(stopsPath);

            try
            {
                Stop temp = RequestStop(myStop => myStop.StopName == name);
            }
            catch (DOStopException exc)
            {
                if (exc.Message == "no stop that meets these conditions!")
                {
                    try
                    {
                        StopList.Find(stopInput => stopInput.StopCode == code).StopName = name;
                        XMLTools.SaveListToXMLSerializer(StopList, stopsPath);
                        return;
                    }
                    catch (DOStopException ex)
                    {
                        throw new DOBadStopIdException(code, ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// update longitude in database
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="licenseNumber"></param>
        public void UpdateStopLongitude(double longitude, long code)
        {
            List<Stop> StopList = XMLTools.LoadListFromXMLSerializer<Stop>(stopsPath);

            try
            {
                GetStop(code);
                StopList.Find(stopInput => stopInput.StopCode == code).Longitude = longitude;
                XMLTools.SaveListToXMLSerializer(StopList, stopsPath);

            }
            catch (DOStopException ex)
            {

                throw new DOBadStopIdException(code, ex.Message);
            }
        }

        /// <summary>
        /// update latitude in database
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="licenseNumber"></param>
        public void UpdateStopLatitude(double latitude, long code)
        {
            List<Stop> StopList = XMLTools.LoadListFromXMLSerializer<Stop>(stopsPath);

            try
            {
                GetStop(code);
                StopList.Find(stopInput => stopInput.StopCode == code).Latitude = latitude;
                XMLTools.SaveListToXMLSerializer(StopList, stopsPath);

            }
            catch (DOStopException ex)
            {

                throw new DOBadStopIdException(code, ex.Message);
            }
        }

        /// <summary>
        /// helper function to get a stop
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Stop GetStop(long code)
        {
            List<Stop> StopList = XMLTools.LoadListFromXMLSerializer<Stop>(stopsPath);

            var t = from stop in StopList
                    where (stop.StopCode == code)
                    select stop;
            if (t.ToList().Count == 0)
                throw new DOStopException("no stop with such license number!!");
            if (!t.First().Valid)
                throw new DOStopException("stop is not valid!!");
            return t.ToList().First();
        }

        /// <summary>
        /// sets a stop valid to false
        /// </summary>
        /// <param name="code"></param>
        public void DeleteStop(long code)
        {
            List<Stop> StopList = XMLTools.LoadListFromXMLSerializer<Stop>(stopsPath);

            try
            {
                GetStop(code);
                StopList.Find(stopInput => stopInput.StopCode == code).Valid = false;
                XMLTools.SaveListToXMLSerializer(StopList, stopsPath);

            }
            catch (DOStopException ex)
            {

                throw new DOBadStopIdException(code, ex.Message);
            }
        }

        /// <summary>
        /// gets all stops
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Stop> GetAllStops()
        {
            List<Stop> StopList = XMLTools.LoadListFromXMLSerializer<Stop>(stopsPath);

            var myList = new List<Stop>();
            foreach (Stop stop in StopList)
            {
                if (stop.Valid == true)
                    myList.Add(stop);
            }
            return myList;
        }





        #endregion



        #region UserTravel

        /// <summary>
        /// add new userTravel to database
        /// </summary>
        /// <param name="userTravel"></param>
        public void CreateUserTravel(UserTravel userTravel)
        {
            List<UserTravel> UserTravelList = XMLTools.LoadListFromXMLSerializer<UserTravel>(userTravelPath);
            UserTravelList.Add(userTravel);
            XMLTools.SaveListToXMLSerializer(UserTravelList, userTravelPath);
        }

        /// <summary>
        /// request a UserTravel according to a predicate
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserTravel RequestUserTravel(long Id)
        {
            List<UserTravel> UserTravelList = XMLTools.LoadListFromXMLSerializer<UserTravel>(userTravelPath);
            return UserTravelList.Find(l => l.LineId == Id);
        }

        /// <summary>
        /// update userTravel in database
        /// </summary>
        /// <param name="userTravel"></param>
        public void UpdateUserTravel(UserTravel userTravel)
        {
            int indLine;
            List<UserTravel> UserTravelList = XMLTools.LoadListFromXMLSerializer<UserTravel>(userTravelPath);

            indLine = UserTravelList.FindIndex(l => l.LineId == userTravel.LineId);
            UserTravelList[indLine] = userTravel;
            XMLTools.SaveListToXMLSerializer(UserTravelList, userTravelPath);

        }

        /// <summary>
        /// sets user travel valid to false
        /// </summary>
        /// <param name="userTravel"></param>
        public void DeleteUserTravel(UserTravel userTravel)
        {
            List<UserTravel> UserTravelList = XMLTools.LoadListFromXMLSerializer<UserTravel>(userTravelPath);
            UserTravelList.Remove(userTravel);
            XMLTools.SaveListToXMLSerializer(UserTravelList, userTravelPath);
        }

        /// <summary>
        /// gets all user travels according to predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public IEnumerable<UserTravel> GetAllUserTravels(Predicate<UserTravel> pr = null)
        {
            List<UserTravel> UserTravelList = XMLTools.LoadListFromXMLSerializer<UserTravel>(userTravelPath);
            if (pr == null)
                return UserTravelList;
            else
                return from b in UserTravelList
                       where (pr(b))
                       select b;
        }


        #endregion



        #region User  // Special initialization with XElement


        public enum authority
        {
            Passenger,
            Driver,
            CEO
        }


        public User GetUser(string nameId)
        {

            XElement userRootElem = XMLTools.LoadListFromXMLElement(usersPath);

            User myUser = (from temUser in userRootElem.Elements()
                           where temUser.Element("UserName").Value == nameId
                           select new User()
                           {
                               Valid = bool.Parse(temUser.Element("Valid").Value),
                               UserName = temUser.Element("UserName").Value,
                               Password = temUser.Element("Password").Value,
                               Permission = (DO.authority)authority.Parse(typeof(authority), temUser.Element("Permission").Value)

                           }
                                  ).FirstOrDefault();
            if (myUser == null)
            {
                throw new DO.DOBadUserIdException("no user with such UserName!!");
            }
            if (!myUser.Valid)
            {
                throw new Exception("user is not valid!!");
            }
            return myUser;

        }


        /// <summary>
        /// add new user to database
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(User user)
        {
            XElement userRootElem = XMLTools.LoadListFromXMLElement(usersPath);
            user.Valid = true;

            try
            {
                // GetUser(user.Password);
                GetUser(user.UserName);
            }
            catch (Exception ex)
            {
                if (ex.Message == "no user with such UserName!!")
                {
                    XElement userElem = new XElement("User",
                                  new XElement("Valid", user.Valid.ToString()),
                                  new XElement("UserName", user.UserName),
                                  new XElement("Password", user.Password),
                                  new XElement("Permission", user.Permission.ToString()));

                    userRootElem.Add(userElem);
                    XMLTools.SaveListToXMLElement(userRootElem, usersPath);



                }

                else if (ex.Message == "user is not valid!!")
                {
                    XElement per = (from temUser in userRootElem.Elements()
                                    where temUser.Element("UserName").Value == user.UserName
                                    select temUser).FirstOrDefault();

                    per.Element("Valid").Value = user.Valid.ToString();


                    XMLTools.SaveListToXMLElement(userRootElem, usersPath);
                }
                return;
            }
            throw new Exception("user already exists!!!");

        }

        /// <summary>
        /// request a User according to a predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public User RequestUser(Predicate<DO.User> pr = null)
        {
            XElement userRootElem = XMLTools.LoadListFromXMLElement(usersPath);
            var tem = from temUser in userRootElem.Elements()
                      let u1 = new User()
                      {
                          Valid = bool.Parse(temUser.Element("Valid").Value),
                          UserName = temUser.Element("UserName").Value,
                          Password = temUser.Element("Password").Value,
                          Permission = (DO.authority)authority.Parse(typeof(authority), temUser.Element("Permission").Value)
                      }
                      where pr(u1)
                      select u1;
            return tem.FirstOrDefault();
        }

        /// <summary>
        /// update name in database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nameId"></param>
        public void UpdateName(string name, string nameId)
        {
            XElement userRootElem = XMLTools.LoadListFromXMLElement(usersPath);

            XElement myUser = (from u in userRootElem.Elements()
                               where u.Element("UserName").Value == nameId
                               select u).FirstOrDefault();
            if (myUser.Element("Valid").Value.ToString() == "false")
            {
                throw new Exception("user is not valid!!");
            }

            if (myUser == null)
            {
                throw new Exception("no user with such UserName!!");
            }

            if (myUser != null)
            {
                myUser.Element("UserName").Value = nameId;
                XMLTools.SaveListToXMLElement(userRootElem, usersPath);
            }

        }

        /// <summary>
        /// sets a user id valid to false
        /// </summary>
        /// <param name="nameId"></param>
        public void DeleteUser(string nameId)
        {
            XElement userRootElem = XMLTools.LoadListFromXMLElement(usersPath);

            XElement myUser = (from u in userRootElem.Elements()
                               where u.Element("UserName").Value == nameId
                               select u).FirstOrDefault();
            if (myUser.Element("Valid").Value == "false")
            {
                throw new Exception("user is not valid!!");
            }

            if (myUser == null)
            {
                throw new Exception("no user with such UserName!!");
            }

            if (myUser != null)
            {
                myUser.Element("Valid").Value = "false";
                XMLTools.SaveListToXMLElement(userRootElem, usersPath);
            }
        }

        /// <summary>
        /// update password in database
        /// </summary>
        /// <param name="password"></param>
        /// <param name="nameId"></param>
        public void UpdatePassword(string password, string nameId)
        {
            XElement userRootElem = XMLTools.LoadListFromXMLElement(usersPath);

            XElement myUser = (from u in userRootElem.Elements()
                               where u.Element("UserName").Value == nameId
                               select u).FirstOrDefault();

            if (myUser.Element("Valid").Value == "false")
            {
                throw new Exception("user is not valid!!");
            }

            if (myUser == null)
            {
                throw new Exception("no user with such UserName!!");
            }

            if (myUser != null)
            {
                myUser.Element("Password").Value = password;
                XMLTools.SaveListToXMLElement(userRootElem, usersPath);
            }
        }

        //// <summary>
        //// returns all users
        //// </summary>
        //// <returns></returns>
        //public IEnumerable<User> GetAllUsers()
        //{
        //    XElement userRootElem = XMLTools.LoadListFromXMLElement(usersPath);
        //    return from temUser in userRootElem.Elements()
        //           let u1 = new User()
        //           {
        //               Valid = bool.Parse(temUser.Element("Valid").Value),
        //               UserName = temUser.Element("UserName").Value,
        //               Password = temUser.Element("Password").Value,
        //               Permission = (DO.authority)authority.Parse(typeof(authority), temUser.Element("Permission").Value)
        //           }
        //           where u1.Valid == true
        //           select u1;
        //}

        public IEnumerable<User> GetAllUsers()
        {
            List<User> BusesList = XMLTools.LoadListFromXMLSerializer<User>(usersPath);
            XMLTools.SaveListToXMLSerializer(BusesList, usersPath);
            var temList = new List<User>();

            foreach (User user in BusesList)
            {
                if (user.Valid == true)
                    temList.Add(user);
            }
            return temList;

        }




        #endregion

        #endregion


    }
}

