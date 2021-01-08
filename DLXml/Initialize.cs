using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DL
{
    public class Initialize
    {
        public Initialize()
        {
            XMLTools.saveListToXML(DS.DataSource.BusesList, "BusesList1"); 
            XMLTools.saveListToXML(DS.DataSource.BusTravelList, "BusTravelList");
            XMLTools.saveListToXML(DS.DataSource.LineDepartureList, "LineDepartureList");
            XMLTools.saveListToXML(DS.DataSource.LineList,  "LineList");
            XMLTools.saveListToXML(DS.DataSource.LineStationList, "LineStationList");
            XMLTools.saveListToXML(DS.DataSource.SequentialStopInfoList, "SequentialStopInfoList");
            XMLTools.saveListToXML(DS.DataSource.StopList,  "StopList");
            XMLTools.saveListToXML(DS.DataSource.UserList, "UserList");
            XMLTools.saveListToXML(DS.DataSource.UserTravelList, "UserTravelList");
        }
    }
}
