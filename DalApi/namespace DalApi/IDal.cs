using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DalApi
{
    public interface IDal
    {


        void CreateBus(Bus bus);
        Bus RequestBus(Predicate<Bus> pr = null);
        void UpdateBusKM(float kM, long licenseNumber);

        void UpdateBusFuel(float fuel, long licenseNumber);
        void UpdateBusStatus(int status, long licenseNumber);
        Bus GetBus(long licenseNumber);
        void DeleteBus(long licenseNumber);
        IEnumerable<Bus> GetAllBusses();



        void CreateBusTravel(BusTravel busTravel);
        BusTravel GetBusTravel(long id);
        BusTravel RequestBusTravel(Predicate<BusTravel> pr = null);
        void UpdateFormalDepartureTime(DateTime formalDepartureTime, long id);
        void UpdateRealDepartureTime(DateTime realDepartureTime, long id);
        void UpdateLastPassedStop(int lastPassedStop, long id);
        void UpdateLastPassedStopTime(DateTime lastPassedStopTime, long id);
        void UpdateNextStopTime(DateTime nextStopTime, long id);
        void UpdateDriverId(string driverId, long id);
        void DeleteBusTravel(long id);
        IEnumerable<BusTravel> GetAllBusTravels(Predicate<BusTravel> pr = null);




        void CreateLine(Line line);
        void CreateOppositeDirectionLine(Line line);
        Line RequestLine(Predicate<Line> pr = null);  //check this...
        void UpdateLineNumber(long number, long id);
        void UpdateLineArea(string area, long id);
        void UpdateLineFirstStop(long firstStop, long id);
        void UpdateLineLastStop(long lastStop, long id);
        Line GetLine(long id);
        void DeleteLine(long id);
        IEnumerable<Line> GetAllLines();


        void CreateLineDeparture(LineDeparture lineDeparture);
        LineDeparture RequestLineDeparture(Predicate<LineDeparture> pr = null);  //check this...
        LineDeparture GetLineDeparture(long id, DateTime time_Start);
        void UpdateLineDepartureFrequency(long id, DateTime time_Start, int frequency);
        void UpdateLineDepartureTime_End(long id, DateTime time_Start , DateTime time_End);
        void DeleteLineDeparture(long id, DateTime time_Start);
        IEnumerable<LineDeparture> GetAllLineDepartures(Predicate<LineDeparture> pr = null);



        void CreateLineStation(LineStation lineStation);
        LineStation RequestLineStation(Predicate<LineStation> pr = null);
        void UpdateLineStationNumberInLine(long numberInLine, long code,long lineId);
        void DeleteLineStation(long code, long lineId,long numberInLine);
        LineStation GetLineStation(long code, long lineId,long numberInLine);
        IEnumerable<LineStation> GetAllLineStations(Predicate<LineStation> pr = null);




        void CreateSequentialStopInfo(SequentialStopInfo sequentialStopInfo);
        SequentialStopInfo RequestSequentialStopInfo(Predicate<SequentialStopInfo> pr);
        void UpdateSequentialStopInfoDistance(long firstId, long secondId, double distance);
        void UpdateSequentialStopInfoTravelTime(long firstId, long secondId, TimeSpan travelTime);
        void DeleteSequentialStopInfo(long firstId, long secondId);
        IEnumerable<SequentialStopInfo> GetAllSequentialStopInfo();
        SequentialStopInfo GetSequentialStopInfo(long fCode, long sCode);




        void CreateStop(Stop stop);
        Stop RequestStop(Predicate<Stop> pr = null);
        void UpdateStopName(string name, long licenseNumber);
        void UpdateStopLongitude(double longitude, long licenseNumber);
        void UpdateStopLatitude(double latitude, long licenseNumber);
        Stop GetStop(long code);
        void DeleteStop(long code);
        IEnumerable<Stop> GetAllStops();





        void CreateUser(User user);
        User RequestUser(Predicate<User> pr = null);
        void UpdateName(string name, string nameId);
        void UpdatePassword(string password, string nameId);
        void DeleteUser(string nameId);
        User GetUser(string password);
        IEnumerable<User> GetAllUsers();



        void CreateUserTravel(UserTravel user_Travel);
        UserTravel RequestUserTravel(long Id);  //check this...
        void UpdateUserTravel(UserTravel user_Travel);
        void DeleteUserTravel(UserTravel user_Travel);
        IEnumerable<UserTravel> GetAllUserTravels(Predicate<UserTravel> pr = null);
    }
}
