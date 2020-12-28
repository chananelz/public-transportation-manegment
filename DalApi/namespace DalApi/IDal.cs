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



        void CreateBusTravel(BusTravel bus_Travel);
        BusTravel RequestBusTravel(long Id);  //check this...
        void UpdateBusTravel(BusTravel bus_Travel);
        void DeleteBusTravel(BusTravel bus_Travel);
        IEnumerable<BusTravel> GetAllBusTravels(Predicate<BusTravel> pr = null);



        void CreateLine(Line line);
        Line RequestLine(Predicate<Line> pr = null);  //check this...
        void UpdateLineNumber(long number, long id);
        void UpdateLineArea(string area, long id);
        void UpdateLineFirstStop(int firstStop, long id);
        void UpdateLineLastStop(int lastStop, long id);
        Line GetLine(long id);
        void DeleteLine(long id);
        IEnumerable<Line> GetAllLines();


        void CreateLineDeparture(LineDeparture line_Departure);
        LineDeparture RequestLineDeparture(long Id);  //check this...
        void UpdateLineDeparture(LineDeparture line_Departure);
        void DeleteLineDeparture(LineDeparture line_Departure);
        IEnumerable<LineDeparture> GetAllLineDepartures(Predicate<LineDeparture> pr = null);



        void CreateLineStation(LineStation lineStation);
        LineStation RequestLineStation(Predicate<LineStation> pr = null);
        void UpdateLineStationNumberInLine(long numberInLine, long code,long lineId);
        void DeleteLineStation(long code, long lineId);
        LineStation GetLineStation(long code, long lineId);
        IEnumerable<LineStation> GetAllLineStations(Predicate<LineStation> pr = null);




        void CreateSequentialStopInfo(SequentialStopInfo sequential_Stop_Info);
        SequentialStopInfo RequestSequentialStopInfo(long firstId, long secondId);  //check this...
        void UpdateSequentialStopInfo(SequentialStopInfo sequential_Stop_Info);
        void DeleteSequentialStopInfo(SequentialStopInfo sequential_Stop_Info);
        IEnumerable<SequentialStopInfo> GetAllStopsInfo(Predicate<SequentialStopInfo> pr = null);



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
