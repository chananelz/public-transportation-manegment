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
        Bus RequestBus(long id);
        void UpdateBus(long licenseNumber, DateTime dateTime, float kM, float Fuel, int statusInput);
        void DeleteBus(long licenseNumber, DateTime dateTime, float kM, float Fuel, int statusInput);
        IEnumerable<Bus> GetAllBusses(Predicate<Bus> pr = null);




        void CreateBusTravel(long licenseNumber, DateTime formalDepartureTime, DateTime realDepartureTime, int lastPassedStop, DateTime lastPassedStopTime, DateTime nextStopTime);
        BusTravel RequestBusTravel(long id);
        void UpdateBusTravel(long licenseNumber, DateTime formalDepartureTime, DateTime realDepartureTime, int lastPassedStop, DateTime lastPassedStopTime, DateTime nextStopTime);
        void DeleteBusTravel(long licenseNumber, DateTime formalDepartureTime, DateTime realDepartureTime, int lastPassedStop, DateTime lastPassedStopTime, DateTime nextStopTime);
        //IEnumerable<BusTravel> GetAllBusTravels(Predicate<BusTravel> pr = null);




       



        void CreateLineDeparture(DateTime time_Start, DateTime timeEnd, int frequency);
        LineDeparture RequestLineDeparture(long id);
        void UpdateLineDeparture(DateTime time_Start, DateTime timeEnd, int frequency);
        void DeleteLineDeparture(DateTime time_Start, DateTime timeEnd, int frequency);
        //IEnumerable<LineDeparture> GetAllLineDepartures(Predicate<LineDeparture> pr = null);

        void CreateLine(long number, string area, int firstStop, int lastStop);
        Line RequestLine(long id);
        void UpdateLine(long number, string area, int firstStop, int lastStop);
        void DeleteLine(long number, string area, int firstStop, int lastStop);
        IEnumerable<Line> GetAllLines(Predicate<Line> pr = null);




        void CreateLineStation(long code, long number);
        LineStation RequestLineStation(long id);
        void UpdateLineStation(long code, long number);
        void DeleteLineStation(long code, long number);
        //IEnumerable<LineStation> GetAllLineStations(Predicate<LineStation> pr = null);


        void CreateSequentialStopInfo(int stationCodeF, int stationCodeS, float distance, TimeSpan averageTime, TimeSpan travelTime);
        SequentialStopInfo RequestSequentialStopInfo(long fid, long sid);
        void UpdateSequentialStopInfo(int stationCodeF, int stationCodeS, float distance, TimeSpan averageTime, TimeSpan travelTime);
        void DeleteSequentialStopInfo(int stationCodeF, int stationCodeS, float distance, TimeSpan averageTime, TimeSpan travelTime);
        //IEnumerable<SequentialStopInfo> GetAll_StopsInfo(Predicate<SequentialStopInfo> pr = null);




        void CreateStop(double latitude, double longitude, string stopName);
        Stop RequestStop(long id);
        void UpdateStop(double latitude, double longitude, string stopName);
        void DeleteStop(double latitude, double longitude, string stopName);
        IEnumerable<Stop> GetAllStops(Predicate<Stop> pr = null);


        void CreateUser(string userName, string password, int permission);
        User RequestUser(string id);
        void UpdateUser(string userName, string password, int permission);
        void DeleteUser(string userName, string password, int permission);
        IEnumerable<User> GetAllUsers(Predicate<User> pr = null);
        User Authinticate(string username, string password);



        void CreateUserTravel(string userName, int lineNumber, DateTime onStopTime, DateTime offStopTime);
        UserTravel RequestUserTravel(long id);
        void UpdateUserTravel(string userName, int lineNumber, DateTime onStopTime, DateTime offStopTime);
        void DeleteUserTravel(string userName, int lineNumber, DateTime onStopTime, DateTime offStopTime);
        //IEnumerable<UserTravel> GetAllUserTravels(Predicate<UserTravel> pr = null);

    }
}