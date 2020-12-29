using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using BO;

namespace BLApi
{
    public interface IBL
    {
        void CreateBus(long licenseNumber, DateTime dateTime, float kM, float Fuel, int statusInput);
        Bus RequestBus(Predicate<Bus> pr);
        void UpdateBusKM(float kM, long licenseNumber);
        void UpdateBusFuel(float fuel, long licenseNumber);
        void UpdateBusStatus(int status, long licenseNumber); 
        void DeleteBus(long licenseNumber);
        IEnumerable<Bus> GetAllBusses(Predicate<Bus> pr = null);
        //IEnumerable<Bus> GetAllValidBuses();
        //IEnumerable<Bus> GetAllUnValidBuses();
        //IEnumerable<Bus> GetAllTravelingBuses();
        //IEnumerable<Bus> GetAllReadyForDriveBuses();
        //IEnumerable<Bus> GetAllTreatingBuses();
        //IEnumerable<Bus> GetAllRefulingBuses();
        //int GetTotalTravel();






        void CreateBusTravel(long licenseNumber,long lineId, DateTime formalDepartureTime, DateTime realDepartureTime, int lastPassedStop, DateTime lastPassedStopTime, DateTime nextStopTime,long driverId);
        BusTravel RequestBusTravel(Predicate<BusTravel> pr = null);
        void UpdateFormalDepartureTime(DateTime formalDepartureTime, long id);
        void UpdateRealDepartureTime(DateTime realDepartureTime, long id);
        void UpdateLastPassedStop(int lastPassedStop, long id);
        void UpdateNextStopTime(DateTime lastPassedStopTime, long id);
        void UpdateLastPassedStopTime(DateTime nextStopTime, long id);
        void UpdateDriverId(long driverId, long id);
        void DeleteBusTravel(long id);
        IEnumerable<BusTravel> GetAllBusTravels(Predicate<BusTravel> pr = null);
        IEnumerable<Line> GetAllLinesByLicenseNumber(long licenseNumber);
        //IEnumerable<BusTravel> GetAllBusTravels(Predicate<BusTravel> pr = null);
        //IEnumerable<BusTravel> GetAllValidBusTravels();
        //IEnumerable<BusTravel> GetAllUnValidBusTravels();
        //TimeSpan GetAvregeLate();
        //TimeSpan GetTimeUntilEnd(int id);
        //TimeSpan GetTimeUntilNextStop(int id);
        //TimeSpan GetTimeUntilSpecificStop(int id);













        void CreateLineDeparture(DateTime time_Start, DateTime timeEnd, int frequency);
        LineDeparture RequestLineDeparture(long id);
        void DeleteLineDeparture(DateTime time_Start, DateTime timeEnd, int frequency);
        //void UpdateLineDepartureFrequency(long id, DateTime Time_Start);
        //void UpdateLineDepartureTime_End(DateTime time_Start, DateTime timeEnd, int frequency);

        //IEnumerable<LineDeparture> GetAllLineDeparture(Predicate<LineDeparture> pr = null);
        //IEnumerable<LineDeparture> GetAllLineDepartures(Predicate<LineDeparture> pr = null);
        //IEnumerable<LineDeparture> GetAllValidLineDeparture();
        //IEnumerable<LineDeparture> GetAllUnValidLineDeparture();




        void CreateLine(long number, string area, int firstStop, int lastStop);
        Line RequestLine(Predicate<Line> pr = null);  //check this...
        void UpdateLineNumber(long number, long id);
        void UpdateLineArea(string area, long id);
        void UpdateLineFirstStop(int firstStop, long id);
        void UpdateLineLastStop(int lastStop, long id); 
        void DeleteLine(long id);
        IEnumerable<Line> GetAllLines(Predicate<Line> pr = null);
        Line RequestLineById(long lineId);
        long GetIdByNumber(long number);
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
        void DeleteLineStation(long code,long lineId);
        IEnumerable<Stop> GetAllStopsByLineNumber(long number);

        IEnumerable<LineStation> GetAllLineStations(Predicate<LineStation> pr = null);
        //IEnumerable<LineStation> GetAllValidLineStations();
        //IEnumerable<LineStation> GetAllUnValidLineStation();
        //int GetAllUnValidLineStation();






        void CreateSequentialStopInfo(int stationCodeF, int stationCodeS, float distance, TimeSpan averageTime, TimeSpan travelTime);
        SequentialStopInfo RequestSequentialStopInfo(long fid, long sid);
        void UpdateSequentialStopInfo(int stationCodeF, int stationCodeS, float distance, TimeSpan averageTime, TimeSpan travelTime);
        void DeleteSequentialStopInfo(int stationCodeF, int stationCodeS, float distance, TimeSpan averageTime, TimeSpan travelTime);
        //IEnumerable<SequentialStopInfo> GetAllStopsInfo(Predicate<SequentialStopInfo> pr = null);
        //IEnumerable<SequentialStopInfo> GetAllValidSequentialStopInfo();
        //IEnumerable<SequentialStopInfo> GetAllUnValidSequentialStopInfo();



        void CreateStop(double latitude, double longitude, string stopName);
        Stop RequestStop(Predicate<Stop> pr = null);
        void UpdateStopName(string name, long code);
        void UpdateStopLongitude(double longitude, long code);
        void UpdateStopLatitude(double latitude, long code);
        void DeleteStop(long code);
        IEnumerable<Stop> GetAllStops(Predicate<Stop> pr = null);
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
        //TimeSpan GeTimeUntilArrival();
    }
}