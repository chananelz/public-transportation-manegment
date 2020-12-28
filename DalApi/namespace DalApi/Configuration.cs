using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//netanel 2

namespace DalApi
{
    public static class Configuration
    {

        static int busCounter = 1000000;
        public static int BusCounter => ++busCounter;



        static int bus_TravelCounter = 0;
        public static int Bus_TravelCounter => ++bus_TravelCounter;



        static int lineCounter = 9;
        public static int LineCounter => ++lineCounter;



        static int line_DepartureCounter = 0;
        public static int Line_DepartureCounter => ++line_DepartureCounter;



        static int line_StationCounter = 0;
        public static int Line_StationCounter => ++line_StationCounter;


        static int sequential_Stop_InfoCounter = 0;
        public static int Sequential_Stop_InfoCounter => ++sequential_Stop_InfoCounter;



        static int stopCounter = 554;
        public static int StopCounter => ++stopCounter;



        static int userCounter = 0;
        public static int UserCounter => ++userCounter;



        static int user_TravelCounter = 0;
        public static int User_TravelCounter => ++user_TravelCounter;


    }
}
