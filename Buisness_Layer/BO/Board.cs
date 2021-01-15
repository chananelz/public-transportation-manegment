using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;

namespace BO
{
    public class Board
    {
        private long number;
        public long Number { get; }


        private string lastStop;
        public string LastStop 
        {
            get
            {
                var bl = Factory.GetBL("1");
                lastStop  =  bl.GetStop(bl.GetLine(bl.GetIdByNumber(number)).LastStop).Address;
                return lastStop;
            }
        }


        private TimeSpan arrival;
        public TimeSpan Arrival
        {
            get
            {

                var bl = Factory.GetBL("1");
                arrival =  bl.GetArrivalTime(StopCode, bl.GetIdByNumber(Number));
                return arrival;
            }
        }



        public long StopCode { get; set; }



        public Board(long number, long stopCode)
        {
            StopCode = stopCode;
            Number = number;
            arrival = Arrival;
            lastStop = LastStop;
        }
    }
}
