using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    class LimitedBus
    {
        string name;
        int? number;
        long? code;
        public LimitedBus()
        {

        }
        public LimitedBus(string name, int number, long code)
        {
            this.name = name;
            this.number = number;
            this.code = code;
        }
        public override string ToString()
        {
            return "name: " + name + "number: " + number + "code: " + code;
        }
        public static string ConvertToString(bool[,] matrix) { return ""; }// not implemented
        public static bool[,] ConvertFromSring(string matrix) { return new bool[1, 1]; }//not implemented

    }
}
