using BO;
using System;
using System.Collections.Generic;




namespace BLApi
{
    public interface IBL
    {
        #region Bus
        /// <summary>
        /// create new bus
        /// </summary>
        /// <param name="licenseNumber"></param>
        /// <param name="dateTime"></param>
        /// <param name="kM"></param>
        /// <param name="Fuel"></param>
        /// <param name="statusInput"></param>
        /// 
        void CreateBus(long licenseNumber, DateTime dateTime, float kM, float Fuel, int statusInput);

        /// <summary>
        /// request specific bus
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        ///
        Bus RequestBus(Predicate<Bus> pr);

        /// <summary>
        /// update bus km
        /// </summary>
        /// <param name="kM"></param>
        /// <param name="licenseNumber"></param>
        void UpdateBusKM(float kM, long licenseNumber);

        /// <summary>
        /// update bus fuel
        /// </summary>
        /// <param name="fuel"></param>
        /// <param name="licenseNumber"></param>
        void UpdateBusFuel(float fuel, long licenseNumber);

        /// <summary>
        /// update bus status
        /// </summary>
        /// <param name="status"></param>
        /// <param name="licenseNumber"></param>
        void UpdateBusStatus(int status, long licenseNumber);

        /// <summary>
        /// delete bus
        /// </summary>
        /// <param name="licenseNumber"></param>
        void DeleteBus(long licenseNumber);

        /// <summary>
        /// get all busses
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        IEnumerable<Bus> GetAllBusses(Predicate<Bus> pr = null);

        /// <summary>
        /// get all busses that ready for drive
        /// </summary>
        /// <returns></returns>
        IEnumerable<Bus> GetAllBussesReadyForDrive();

        /// <summary>
        /// Get All Busses that are now in traveling
        /// </summary>
        /// <returns></returns>
        IEnumerable<Bus> GetAllBussesTraveling();

        /// <summary>
        /// get all busses that now in fueling
        /// </summary>
        /// <returns></returns>
        IEnumerable<Bus> GetAllBussesFueling();

        /// <summary>
        /// get all busses treating
        /// </summary>
        /// <returns></returns>
        IEnumerable<Bus> GetAllBussesTreating();

        /// <summary>
        /// find specific line by  license number
        /// </summary>
        /// <param name="licenseNumber"></param>
        /// <returns></returns>
        Line GetLineByLicenseNumber(long licenseNumber);

        /// <summary>
        /// find specific bus
        /// </summary>
        /// <param name="licenseNumber"></param>
        /// <returns></returns>
        Bus GetBus(long licenseNumber);

        #endregion


        //IEnumerable<Bus> GetAllValidBuses();
        //IEnumerable<Bus> GetAllUnValidBuses();
        //IEnumerable<Bus> GetAllTravelingBuses();
        //IEnumerable<Bus> GetAllReadyForDriveBuses();
        //IEnumerable<Bus> GetAllTreatingBuses();
        //IEnumerable<Bus> GetAllRefulingBuses();
        //int GetTotalTravel();




        #region BusTravel
        /// <summary>
        /// create new bus travel
        /// </summary>
        /// <param name="licenseNumber"></param>
        /// <param name="lineId"></param>
        /// <param name="formalDepartureTime"></param>
        /// <param name="realDepartureTime"></param>
        /// <param name="lastPassedStop"></param>
        /// <param name="lastPassedStopTime"></param>
        /// <param name="nextStopTime"></param>
        /// <param name="driverId"></param>
        void CreateBusTravel(long licenseNumber, long lineId, DateTime formalDepartureTime, DateTime realDepartureTime, long lastPassedStop, DateTime lastPassedStopTime, DateTime nextStopTime, string driverId);

        /// <summary>
        /// find specific BusTravel 
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        BusTravel RequestBusTravel(Predicate<BusTravel> pr = null);

        /// <summary>
        /// update the formal departure time
        /// </summary>
        /// <param name="formalDepartureTime"></param>
        /// <param name="id"></param>
        void UpdateFormalDepartureTime(DateTime formalDepartureTime, long id);

        /// <summary>
        /// update real departure time
        /// </summary>
        /// <param name="realDepartureTime"></param>
        /// <param name="id"></param>
        void UpdateRealDepartureTime(DateTime realDepartureTime, long id);

        /// <summary>
        /// update last passed stop
        /// </summary>
        /// <param name="lastPassedStop"></param>
        /// <param name="id"></param>
        void UpdateLastPassedStop(long lastPassedStop, long id);

        /// <summary>
        /// update next stop time
        /// </summary>
        /// <param name="lastPassedStopTime"></param>
        /// <param name="id"></param>
        /// 
        void UpdateNextStopTime(DateTime lastPassedStopTime, long id);

        /// <summary>
        /// update last passed stop time
        /// </summary>
        /// <param name="nextStopTime"></param>
        /// <param name="id"></param>
        void UpdateLastPassedStopTime(DateTime nextStopTime, long id);

        /// <summary>
        /// update driver id
        /// </summary>
        /// <param name="driverId"></param>
        /// <param name="id"></param>
        void UpdateDriverId(string driverId, long id);

        /// <summary>
        /// Delete specific BusTravel
        /// </summary>
        /// <param name="id"></param>
        void DeleteBusTravel(long id);

        /// <summary>
        /// get all bus travels
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        IEnumerable<BusTravel> GetAllBusTravels(Predicate<BusTravel> pr = null);

        /// <summary>
        /// get all lines by license number
        /// </summary>
        /// <param name="licenseNumber"></param>
        /// <returns></returns>
        IEnumerable<Line> GetAllLinesByLicenseNumber(long licenseNumber);
        IEnumerable<LineStation> GetAllLineStationsByLicenseNumber(long licenseNumber);

        BusTravel GetBusTravel(long licenseNumber);
        BusTravel FindBusTravelWithLineNumberAndDepartureTime(long lineId,DateTime formalDepartureTime);
        #endregion
        

        //IEnumerable<BusTravel> GetAllBusTravels(Predicate<BusTravel> pr = null);
        //IEnumerable<BusTravel> GetAllValidBusTravels();
        //IEnumerable<BusTravel> GetAllUnValidBusTravels();
        //long GetAvregeLate();
        //long GetTimeUntilEnd(int id);
        //long GetTimeUntilNextStop(int id);
        //long GetTimeUntilSpecificStop(int id);


        #region LineDeparture
        /// <summary>
        /// create new line departure
        /// </summary>
        /// <param name="id"></param>
        /// <param name="timeStart"></param>
        /// <param name="frequency"></param>
        /// <param name="timeEnd"></param>
        void CreateLineDeparture(long id, DateTime timeStart, int frequency, DateTime timeEnd);

        /// <summary>
        /// request specific line departure
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        LineDeparture RequestLineDeparture(Predicate<LineDeparture> pr);

        /// <summary>
        /// update specific line departure frequency
        /// </summary>
        /// <param name="id"></param>
        /// <param name="timeStart"></param>
        /// <param name="frequency"></param>
        void UpdateLineDepartureFrequency(long id, DateTime timeStart, int frequency);

        /// <summary>
        /// update specific line departure time end
        /// </summary>
        /// <param name="id"></param>
        /// <param name="timeStart"></param>
        /// <param name="timeEnd"></param>
        void UpdateLineDepartureTime_End(long id, DateTime timeStart, DateTime timeEnd);

        /// <summary>
        /// delete specific line departure
        /// </summary>
        /// <param name="timeStart"></param>
        /// <param name="timeEnd"></param>
        /// <param name="frequency"></param>
        /// <param name="id"></param>
        void DeleteLineDeparture(DateTime timeStart, DateTime timeEnd, int frequency, long id);
        /// <summary>
        /// get all line departures
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<LineDeparture> GetAllLineDeparture(Predicate<LineDeparture> pr);

        #endregion


        //void UpdateLineDepartureFrequency(long id, DateTime timeStart);
        //void UpdateLineDepartureTime_End(DateTime timeStart, DateTime timeEnd, int frequency);

        //IEnumerable<LineDeparture> GetAllLineDeparture(Predicate<LineDeparture> pr = null);
        //IEnumerable<LineDeparture> GetAllLineDepartures(Predicate<LineDeparture> pr = null);
        //IEnumerable<LineDeparture> GetAllValidLineDeparture();
        //IEnumerable<LineDeparture> GetAllUnValidLineDeparture();


        #region Line
        /// <summary>
        /// create new line
        /// </summary>
        /// <param name="number"></param>
        /// <param name="area"></param>
        /// <param name="stopList"></param>
        void CreateLine(long number, string area, List<Stop> stopList);

        /// <summary>
        /// create opposite direction line
        /// </summary>
        /// <param name="number"></param>
        /// <param name="area"></param>
        /// <param name="stopList"></param>
        void CreateOppositeDirectionLine(long number, string area, List<Stop> stopList);

        /// <summary>
        /// request specific line
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        Line RequestLine(Predicate<Line> pr = null);

        /// <summary>
        /// update line - number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="id"></param>
        void UpdateLineNumber(long number, long id);

        /// <summary>
        /// update line - area
        /// </summary>
        /// <param name="area"></param>
        /// <param name="id"></param>
        void UpdateLineArea(string area, long id);

        /// <summary>
        /// update line - first stop
        /// </summary>
        /// <param name="firstStop"></param>
        /// <param name="id"></param>
        void UpdateLineFirstStop(long firstStop, long id);

        /// <summary>
        /// update line - lasts stop
        /// </summary>
        /// <param name="lastStop"></param>
        /// <param name="id"></param>
        void UpdateLineLastStop(long lastStop, long id);

        /// <summary>
        /// delete specific line
        /// </summary>
        /// <param name="id"></param>
        void DeleteLine(long id);

        /// <summary>
        /// get all lines
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        IEnumerable<Line> GetAllLines(Predicate<Line> pr = null);

        /// <summary>
        /// request specific line by id
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        Line RequestLineById(long lineId);

        /// <summary>
        ///  get id by specific number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        long GetIdByNumber(long number);

        /// <summary>
        /// get all bussese by specific line number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        IEnumerable<BusTravel> GetAllBusseseByLineNumber(long number);

        /// <summary>
        /// get specific line
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Line GetLine(long id);

        /// <summary>
        /// get all line group by area
        /// </summary>
        /// <returns></returns>
        IEnumerable<IEnumerable<Line>> GetAllLineGroupByArea();

        /// <summary>
        /// get all lines that are not in driving
        /// </summary>
        /// <returns></returns>
        IEnumerable<Line> GetAllLinesDriving();

        /// <summary>
        /// get all lines that are not in driving
        /// </summary>
        /// <returns></returns>
        IEnumerable<Line> GetAllLinesNotDriving();

        /// <summary>
        /// get all areas
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetAllAreas();
        #endregion





        //IEnumerable<Line> GetAllValidLines();
        //IEnumerable<Line> GetAllUnValidLines();
        //IEnumerable<stop> GetAllStopInSpecificLine();
        //IEnumerable<stop> GetAllLineThatEndInSpecificStop();
        //IEnumerable<stop> GetAllLineThatBeginInSpecificStop();
        //IEnumerable<Line> GetAlLineSortByStope();
        //IEnumerable<Line> GetAlLineSortByDistance();



        #region LineStation
        /// <summary>
        /// create new line station
        /// </summary>
        /// <param name="lineId"></param>
        /// <param name="numberInLine"></param>
        /// <param name="code"></param>
        void CreateLineStation(long lineId, long numberInLine, long code);

        /// <summary>
        /// request specific line station
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        LineStation RequestLineStation(Predicate<LineStation> pr = null);

        /// <summary>
        /// update line station - number in line
        /// </summary>
        /// <param name="numberInLine"></param>
        /// <param name="code"></param>
        /// <param name="lineId"></param>
        void UpdateLineStationNumberInLine(long numberInLine, long code, long lineId);

        /// <summary>
        /// delete specific line station
        /// </summary>
        /// <param name="code"></param>
        /// <param name="lineId"></param>
        /// <param name="numberInLine"></param>
        void DeleteLineStation(long code, long lineId, long numberInLine);

        /// <summary>
        ///  get all stops by specific line number
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Stop> GetAllStopsByLineNumber(long id);

        /// <summary>
        /// get all line stations
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        IEnumerable<LineStation> GetAllLineStations(Predicate<LineStation> pr = null);

        /// <summary>
        /// update line stations
        /// </summary>
        /// <param name="stopLines"></param>
        /// <param name="id"></param>
        void UpdateLineStations(List<Stop> stopLines, long id);

        /// <summary>
        /// get specific line station
        /// </summary>
        /// <param name="code"></param>
        /// <param name="lineId"></param>
        /// <param name="numberInLine"></param>
        /// <returns></returns>
        LineStation GetLineStation(long code, long lineId, long numberInLine);//aaa

        LineStation GetStationByTime(TimeSpan check,TimeSpan time, long busTravelId);
        TimeSpan GetPassedStopTime(TimeSpan check,TimeSpan time, long busTravelId);
        TimeSpan GetNextStopTime(TimeSpan check, TimeSpan time, long busTravelId);

        #endregion


        //IEnumerable<LineStation> GetAllValidLineStations();
        //IEnumerable<LineStation> GetAllUnValidLineStation();
        //int GetAllUnValidLineStation();






        #region SequentialStopInfo
        /// <summary>
        /// create sequential stop info
        /// </summary>
        /// <param name="stationCodeF"></param>
        /// <param name="stationCodeS"></param>
        void CreateSequentialStopInfo(long stationCodeF, long stationCodeS);

        /// <summary>
        /// request sequential stop info
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        SequentialStopInfo RequestSequentialStopInfo(Predicate<SequentialStopInfo> pr);

        /// <summary>
        /// update sequential stop info distance
        /// </summary>
        /// <param name="firstId"></param>
        /// <param name="secondId"></param>
        /// <param name="distance"></param>
        void UpdateSequentialStopInfoDistance(long firstId, long secondId, double distance);

        /// <summary>
        /// update sequential stop info travel time
        /// </summary>
        /// <param name="firstId"></param>
        /// <param name="secondId"></param>
        /// <param name="travelTime"></param>
        void UpdateSequentialStopInfoTravelTime(long firstId, long secondId, TimeSpan travelTime);

        /// <summary>
        /// delete sequential stop info
        /// </summary>
        /// <param name="firstId"></param>
        /// <param name="secondId"></param>
        void DeleteSequentialStopInfo(long firstId, long secondId);

        /// <summary>
        /// get all lines by stop code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        IEnumerable<Line> GetAllLinesByStopCode(long code);

        /// <summary>
        /// get sequential stop info
        /// </summary>
        /// <param name="fCode"></param>
        /// <param name="sCode"></param>
        /// <returns></returns>
        SequentialStopInfo GetSequentialStopInfo(long fCode, long sCode);

        /// <summary>
        /// get all sequential stops info
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        IEnumerable<SequentialStopInfo> GetAllSequentialStopsInfo(Predicate<SequentialStopInfo> pr = null);

        /// <summary>
        /// travel time calculate
        /// </summary>
        /// <param name="lineId"></param>
        /// <param name="fStop"></param>
        /// <param name="sStop"></param>
        /// <returns></returns>
        TimeSpan TravelTimeCalculate(long lineId, long fStop, long sStop);

        /// <summary>
        /// distance calculate of two stop
        /// </summary>
        /// <param name="lineId"></param>
        /// <param name="fStop"></param>
        /// <param name="lStop"></param>
        /// <returns></returns>
        double DistanceCalculate(long lineId, long fStop, long lStop);
        #endregion


        //IEnumerable<SequentialStopInfo> GetAllValidSequentialStopInfo();
        //IEnumerable<SequentialStopInfo> GetAllUnValidSequentialStopInfo();



        #region Stop
        /// <summary>
        /// create new stop
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="stopName"></param>
        void CreateStop(double latitude, double longitude, string stopName);

        /// <summary>
        /// get specific stop
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Stop GetStop(long code);

        /// <summary>
        /// request specific stop
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        Stop RequestStop(Predicate<Stop> pr = null);

        /// <summary>
        /// update stop - name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        void UpdateStopName(string name, long code);

        /// <summary>
        /// update stop - longitude
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="code"></param>
        void UpdateStopLongitude(double longitude, long code);

        /// <summary>
        /// update stop - latitude
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="code"></param>
        void UpdateStopLatitude(double latitude, long code);

        /// <summary>
        /// delete stop
        /// </summary>
        /// <param name="code"></param>
        void DeleteStop(long code);

        /// <summary>
        ///  get all stops
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        IEnumerable<Stop> GetAllStops(Predicate<Stop> pr = null);

        /// <summary>
        /// get name by stop code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        string GetNameByStopCode(long code);

        /// <summary>
        ///  get all line stations by line number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        IEnumerable<LineStation> GetAllLineStationsByLineNumber(long number);

        /// <summary>
        /// get best route
        /// </summary>
        /// <param name="fid"></param>
        /// <param name="sid"></param>
        /// <returns></returns>
        Line GetBestRoute(long fid, long sid);

        /// <summary>
        /// add stop in line
        /// </summary>
        /// <param name="lineId"></param>
        /// <param name="code"></param>
        /// <param name="numberInLine"></param>
        void AddStopInLine(long lineId, long code, long numberInLine);//can't win!

        #endregion


        //IEnumerable<Stop> GetAllValidStop();
        //IEnumerable<Stop> GetAllUnValidStop();
        //IEnumerable<Stop> GetAllUnValidStop();
        //IEnumerable<Stop> GetAllStopeInSpecificArea();





        #region User
        /// <summary>
        /// create new user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="permission"></param>
        void CreateUser(string userName, string password, int permission);

        /// <summary>
        /// request specific user
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        User RequestUser(Predicate<User> pr = null);

        /// <summary>
        /// update - name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nameId"></param>
        void UpdateName(string name, string nameId);

        /// <summary>
        /// update - password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="nameId"></param>
        void UpdatePassword(string password, string nameId);

        /// <summary>
        /// delete specific user
        /// </summary>
        /// <param name="nameId"></param>
        void DeleteUser(string nameId);

        /// <summary>
        /// get all users
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        IEnumerable<User> GetAllUsers(Predicate<User> pr = null);

        /// <summary>
        /// check the match between username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="au"></param>
        /// <returns></returns>
        User Authinticate(string username, string password, authority au);

        /// <summary>
        /// get all drivers
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAllDrivers();

        /// <summary>
        /// get all passengers
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAllPassengers();
        User GetUser(string nameId);
        #endregion


        //IEnumerable<User> GetAllValidUsers();
        //IEnumerable<User> GetAllUnValidUsers();
        //IEnumerable<User> GetAllUnValidManager();
        //IEnumerable<User> GetAllUnValidUser()




        #region UserTravel
        /// <summary>
        /// create new user travel
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="lineNumber"></param>
        /// <param name="onStopTime"></param>
        /// <param name="offStopTime"></param>
        void CreateUserTravel(string userName, long lineNumber, DateTime onStopTime, DateTime offStopTime);

        /// <summary>
        /// request specific user travel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserTravel RequestUserTravel(Predicate<UserTravel> pr = null);

           /// <summary>
           /// get UserTravel
           /// </summary>
           /// <param name="id"></param>
           /// <returns></returns>
        UserTravel GetUserTravel(long id);


        UserTravel GetDriverTravel(long lineNumber, DateTime formalDepartureTime);


       

        /// <summary>
        /// delete specific user travel
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="lineNumber"></param>
        /// <param name="onStopTime"></param>
        /// <param name="offStopTime"></param>
        void DeleteUserTravel(long id);
        #endregion
        IEnumerable<UserTravel> GetAllUserTravels(Predicate<UserTravel> pr = null);
        IEnumerable<UserTravel> GetAllDriverTravel();
        IEnumerable<UserTravel> GetAllPassengersTravel();






        /// <summary>
        /// Initialize the clock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="timeSpan"></param>
        /// <param name="speedInput"></param>
        void Initialize(object sender,TimeSpan timeSpan, int speedInput);

        /// <summary>
        /// get the cournt time
        /// </summary>
        /// <param name="stopCode"></param>
        /// <param name="lineId"></param>
        /// <returns></returns>
        TimeSpan GetArrivalTime(long stopCode, long lineId);



        //IEnumerable<UserTravel> GetAllUnValidUserTravels();
        //IEnumerable<UserTravel> GetAllValidUserTravels();
        //long GeTimeUntilArrival();
    }
}