﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class LineStation
    {
        public bool Valid { get; set; }
        public long LineId { get; set; }
        public long Code { get; set; }

        public long NumberInLine { get; set; }
        public LineStation()//not implemented
        {

        }
        public LineStation(LineStation line_Station)//not implemented
        {
            Valid = line_Station.Valid;
            LineId = line_Station.LineId;
            Code = line_Station.Code;
            NumberInLine = line_Station.NumberInLine;
        }
        public override string ToString()
        {
            return "Valid:" + Valid + "line id: " + LineId + "code: " + Code + "number in line: " + NumberInLine;
        }
        public static string ConvertToString(bool[,] matrix) { return ""; }// not implemented
        public static bool[,] ConvertFromSring(string matrix) { return new bool[1, 1]; }//not implemented

    }
}
