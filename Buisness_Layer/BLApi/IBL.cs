using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using BO;

//aaaa



namespace BLApi
{
    public interface IBL
    {
        void CreateBus(long licenseNumber, DateTime dateTime, float kM, float Fuel, int statusInput );
        Bus RequestBus(Predicate<Bus> pr);
        void UpdateBusKM(float kM, long licenseNumber);
        void UpdateBusFuel(float fuel, long licenseNumber);
        void UpdateBusStatus(int status, long licenseNumber); 
        void DeleteBus(long licenseNumber);
        IEnumerable<Bus> GetAllBusses(Predicate<Bus> pr = null);
        IEnumerable<Bus> GetAllBussesReadyForDrive();
        Bus GetBus(long licenseNumber);
        //IEnumerable<Bus> GetAllValidBuses();
        //IEnumerable<Bus> GetAllUnValidBuses();
        //IEnumerable<Bus> GetAllTravelingBuses();
        //IEnumerable<Bus> GetAllReadyForDriveBuses();
        //IEnumerable<Bus> GetAllTreatingBuses();
        //IEnumerable<Bus> GetAllRefulingBuses();
        //int GetTotalTravel();






        void CreateBusTravel(long licenseNumber,long lineId, DateTime formalDepartureTime, DateTime realDepartureTime, int lastPassedStop, DateTime lastPassedStopTime, DateTime nextStopTime,string driverId);
        BusTravel RequestBusTravel(Predicate<BusTravel> pr = null);
        void UpdateFormalDepartureTime(DateTime formalDepartureTime, long id);
        void UpdateRealDepartureTime(DateTime realDepartureTime, long id);
        void UpdateLastPassedStop(int lastPassedStop, long id);
        void UpdateNextStopTime(DateTime lastPassedStopTime, long id);
        void UpdateLastPassedStopTime(DateTime nextStopTime, long id);
        void UpdateDriverId(string driverId, long id);
        void DeleteBusTravel(long id);
        IEnumerable<BusTravel> GetAllBusTravels(Predicate<BusTravel> pr = null);
        IEnumerable<Line> GetAllLinesByLicenseNumber(long licenseNumber);
        //IEnumerable<BusTravel> GetAllBusTravels(Predicate<BusTravel> pr = null);
        //IEnumerable<BusTravel> GetAllValidBusTravels();
        //IEnumerable<BusTravel> GetAllUnValidBusTravels();
        //long GetAvregeLate();
        //long GetTimeUntilEnd(int id);
        //long GetTimeUntilNextStop(int id);
        //long GetTimeUntilSpecificStop(int id);













        void CreateLineDeparture(long id, DateTime time_Start, int frequency, DateTime timeEnd);
        LineDeparture RequestLineDeparture(Predicate<LineDeparture> pr);
        void UpdateLineDepartureFrequency(long id, DateTime time_Start, int frequency);
        void UpdateLineDepartureTime_End(long id, DateTime time_Start, DateTime time_End);
        void DeleteLineDeparture(DateTime time_Start, DateTime timeEnd, int frequency, long id);
        //void UpdateLineDepartureFrequency(long id, DateTime Time_Start);
        //void UpdateLineDepartureTime_End(DateTime time_Start, DateTime timeEnd, int frequency);

        //IEnumerable<LineDeparture> GetAllLineDeparture(Predicate<LineDeparture> pr = null);
        //IEnumerable<LineDeparture> GetAllLineDepartures(Predicate<LineDeparture> pr = null);
        //IEnumerable<LineDeparture> GetAllValidLineDeparture();
        //IEnumerable<LineDeparture> GetAllUnValidLineDeparture();




        void CreateLine(long number, string area, List<Stop> stopList);
        Line RequestLine(Predicate<Line> pr = null);  //check this...
        void UpdateLineNumber(long number, long id);
        void UpdateLineArea(string area, long id);
        void UpdateLineFirstStop(long firstStop, long id);
        void UpdateLineLastStop(long lastStop, long id); 
        void DeleteLine(long id);
        IEnumerable<Line> GetAllLines(Predicate<Line> pr = null);
        Line RequestLineById(long lineId);
        long GetIdByNumber(long number);
        IEnumerable<BusTravel> GetAllBusseseByLineNumber(long number);

        //IEnumerable<Line> GetAllValidLines();
        //IEnumerable<Line> GetAllUnValidLines();
        //IEnumerable<stop> GetAllStopInSpecificLine();
        //IEnumerable<stop> GetAllLineThatEndInSpecificStop();
        //IEnumerable<stop> GetAllLineThatBeginInSpecificStop();
        //IEnumerable<Line> GetAlLineSortByStope();
        //IEnumerable<Line> GetAlLineSortByDistance();



        void CreateLineStation(long lineId, long numberInLine, long code);
        LineStation RequestLineStation(Predicate<LineStation> pr = null);
        void UpdateLineStationNumberInLine(long numberInLine, long code,long lineId);
        void DeleteLineStation(long code,long lineId,long numberInLine);
        IEnumerable<Stop> GetAllStopsByLineNumber(long id);

        IEnumerable<LineStation> GetAllLineStations(Predicate<LineStation> pr = null);
        void UpdateLineStations(List<Stop> stopLines, long id);
        Line GetLine(long id);
        LineStation GetLineStation(long code, long lineId, long numberInLine);
        void AddStopInLine(long lineId, long code, long numberInLine);
        //IEnumerable<LineStation> GetAllValidLineStations();
        //IEnumerable<LineStation> GetAllUnValidLineStation();
        //int GetAllUnValidLineStation();








        void CreateSequentialStopInfo(long stationCodeF, long stationCodeS);
        SequentialStopInfo RequestSequentialStopInfo(Predicate<SequentialStopInfo> pr);
        void UpdateSequentialStopInfoDistance(long firstId, long secondId, double distance);
        void UpdateSequentialStopInfoTravelTime(long firstId, long secondId, TimeSpan travelTime);
        void DeleteSequentialStopInfo(long firstId, long secondId);
        IEnumerable<Line> GetAllLinesByStopCode(long code);
        SequentialStopInfo GetSequentialStopInfo(long fCode, long sCode);
        IEnumerable<SequentialStopInfo> GetAllSequentialStopsInfo(Predicate<SequentialStopInfo> pr = null);
        TimeSpan TravelTimeCalculate(long lineId, long fStop, long sStop);
        double DistanceCalculate(long lineId, long fStop, long lStop);
        //IEnumerable<SequentialStopInfo> GetAllValidSequentialStopInfo();
        //IEnumerable<SequentialStopInfo> GetAllUnValidSequentialStopInfo();







        void CreateStop(double latitude, double longitude, string stopName);
        Stop GetStop(long code);
        Stop RequestStop(Predicate<Stop> pr = null);
        void UpdateStopName(string name, long code);
        void UpdateStopLongitude(double longitude, long code);
        void UpdateStopLatitude(double latitude, long code);
        void DeleteStop(long code);
        IEnumerable<Stop> GetAllStops(Predicate<Stop> pr = null);
        string GetNameByStopCode(long code);
        IEnumerable<LineStation> GetAllLineStationsByLineNumber(long number);
        
        //IEnumerable<Stop> GetAllValidStop();
        //IEnumerable<Stop> GetAllUnValidStop();
        //IEnumerable<Stop> GetAllUnValidStop();
        //IEnumerable<Stop> GetAllStopeInSpecificArea();







        void CreateUser(string userName, string password, int permission);
        User RequestUser(Predicate<User> pr = null);
        void UpdateName(string name, string nameId);
        void UpdatePassword(string password, string nameId);
        void DeleteUser(string nameId);
        IEnumerable<User> GetAllUsers(Predicate<User> pr = null);
        User Authinticate(string username, string password,authority au);
        IEnumerable<User> GetAllDrivers();
        IEnumerable<User> GetAllPassengers();
        //IEnumerable<User> GetAllValidUsers();
        //IEnumerable<User> GetAllUnValidUsers();
        //IEnumerable<User> GetAllUnValidManager();
        //IEnumerable<User> GetAllUnValidUser()






        void CreateUserTravel(string userName, int lineNumber, DateTime onStopTime, DateTime offStopTime);
        UserTravel RequestUserTravel(long id);
        void UpdateUserTravel(string userName, int lineNumber, DateTime onStopTime, DateTime offStopTime);
        void DeleteUserTravel(string userName, int lineNumber, DateTime onStopTime, DateTime offStopTime);

        //IEnumerable<UserTravel> GetAllUserTravels(Predicate<UserTravel> pr = null);
        //IEnumerable<UserTravel> GetAllUnValidUserTravels();
        //IEnumerable<UserTravel> GetAllValidUserTravels();
        //long GeTimeUntilArrival();
    }
}