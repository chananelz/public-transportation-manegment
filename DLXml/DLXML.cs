using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalApi;
using DO;




namespace DL
{
    sealed partial class DLXML : IDal    //internal
    {
        #region singelton
        static readonly DLXML instance = new DLXML();
        static DLXML() { }// static ctor to ensure instance init is done just before first usage
        DLXML() { } // default => private
        public static DLXML Instance { get => instance; }// The public Instance property to use
        #endregion

        #region DS XML Files

        string busesPath = @"BusesXml.xml"; //XMLSerializer
        string busTravelsPath = @"BusTravelXml.xml"; //XMLSerializer
        string lineDeparturesPath = @"LineDepartureXml.xml"; //XMLSerializer
        string lineStationsPath = @"LineStationXml.xml"; //XMLSerializer
        string linesPath = @"LineXml.xml"; //XMLSerializer
        string sequentialStopInfoPath = @"SequentialStopInfoXml.xml"; //XMLSerializer
        string stopsPath = @"StopXml.xml"; //XMLSerializer
        string usersPath = @"UserXml.xml"; //XElement
        string userTravelPath = @"UserTravelXml.xml"; //XMLSerializer


        #endregion


    }
}

