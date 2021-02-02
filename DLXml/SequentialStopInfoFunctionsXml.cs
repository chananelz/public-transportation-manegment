using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using DalApi;
using DO;


namespace DL
{
    public partial class DLXML : IDal
    {
        public void CreateSequentialStopInfo(SequentialStopInfo sequentialStopInfo)
        {
            XElement userRootElem = XMLTools.LoadListFromXMLElement(sequentialStopInfoPath);
            sequentialStopInfo.Valid = true;

            try
            {
                GetSequentialStopInfo(sequentialStopInfo.StationCodeF, sequentialStopInfo.StationCodeS);
            }

            catch (Exception ex)
            {
                if (ex.Message == "no SequentialStopInfo with such license number!!")
                {
                    XElement sequentialStopInfoElem = new XElement("SequentialStopInfo",
                                 new XElement("Valid", sequentialStopInfo.Valid.ToString()),
                                 new XElement("StationCodeF", sequentialStopInfo.StationCodeF),
                                 new XElement("StationCodeS", sequentialStopInfo.StationCodeS),
                                 new XElement("Distance", sequentialStopInfo.Distance),
                                 new XElement("AverageTime", ""),
                                 new XElement("TravelTime", XmlConvert.ToString(sequentialStopInfo.TravelTime)));

                    userRootElem.Add(sequentialStopInfoElem);
                    XMLTools.SaveListToXMLElement(userRootElem, usersPath);
                }
                else if (ex.Message == "SequentialStopInfoList is not valid!!")
                {
                    XElement per = (from temSeq in userRootElem.Elements()
                                    where temSeq.Element("StationCodeF").Value == sequentialStopInfo.StationCodeF.ToString() && temSeq.Element("StationCodeS").Value == sequentialStopInfo.StationCodeS.ToString()
                                    select temSeq).FirstOrDefault();

                    per.Element("Valid").Value = sequentialStopInfo.Valid.ToString();

                    XMLTools.SaveListToXMLElement(userRootElem, sequentialStopInfoPath);
                }
                return;
            }
            throw new Exception("sequentialStopInfo already exists!!!");
        }

        public SequentialStopInfo RequestSequentialStopInfo(Predicate<SequentialStopInfo> pr)
        {
            XElement userRootElem = XMLTools.LoadListFromXMLElement(sequentialStopInfoPath);
            var tem = from temSeq in userRootElem.Elements()
                      let u1 = new SequentialStopInfo()
                      {
                          Valid = bool.Parse(temSeq.Element("Valid").Value),
                          StationCodeF = long.Parse(temSeq.Element("StationCodeF").Value),
                          StationCodeS = long.Parse(temSeq.Element("StationCodeS").Value),
                          Distance = double.Parse(temSeq.Element("Distance").Value),
                          TravelTime = XmlConvert.ToTimeSpan(temSeq.Element("TravelTime").Value.ToString())
                      }
                      where pr(u1)
                      select u1;
            return tem.FirstOrDefault();
        }

        public void UpdateSequentialStopInfoDistance(long firstId, long secondId, double distance)
        {
            XElement userRootElem = XMLTools.LoadListFromXMLElement(sequentialStopInfoPath);

            GetSequentialStopInfo(firstId, secondId);
            XElement mySeq = (from u in userRootElem.Elements()
                               where u.Element("StationCodeF").Value == firstId.ToString() && u.Element("StationCodeS").Value == secondId.ToString()
                              select u).FirstOrDefault();

            if (mySeq != null)
            {
                mySeq.Element("Distance").Value = distance.ToString();
                XMLTools.SaveListToXMLElement(userRootElem, sequentialStopInfoPath);
            }
        }

        public void UpdateSequentialStopInfoTravelTime(long firstId, long secondId, TimeSpan travelTime)
        {
            XElement userRootElem = XMLTools.LoadListFromXMLElement(sequentialStopInfoPath);

            GetSequentialStopInfo(firstId, secondId);
            XElement mySeq = (from u in userRootElem.Elements()
                              where u.Element("StationCodeF").Value == firstId.ToString() && u.Element("StationCodeS").Value == secondId.ToString()
                              select u).FirstOrDefault();

            if (mySeq != null)
            {
                mySeq.Element("TravelTime").Value = XmlConvert.ToString(travelTime);
                XMLTools.SaveListToXMLElement(userRootElem, sequentialStopInfoPath);
            }
        }

        public void DeleteSequentialStopInfo(long firstId, long secondId)
        {
            XElement userRootElem = XMLTools.LoadListFromXMLElement(sequentialStopInfoPath);

            GetSequentialStopInfo(firstId, secondId);
            XElement mySeq = (from u in userRootElem.Elements()
                              where u.Element("StationCodeF").Value == firstId.ToString() && u.Element("StationCodeS").Value == secondId.ToString()
                              select u).FirstOrDefault();

            if (mySeq != null)
            {
                mySeq.Element("Valid").Value = false.ToString();
                XMLTools.SaveListToXMLElement(userRootElem, sequentialStopInfoPath);
            }
        }

        public IEnumerable<SequentialStopInfo> GetAllSequentialStopInfo()
        {

            XElement userRootElem = XMLTools.LoadListFromXMLElement(sequentialStopInfoPath);

            var temList = new List<User>();

            IEnumerable<SequentialStopInfo> temp = (from temSeq in userRootElem.Elements()
                                                    select new SequentialStopInfo()
                                                    {
                                                        Valid = bool.Parse(temSeq.Element("Valid").Value),
                                                        StationCodeF = long.Parse(temSeq.Element("StationCodeF").Value),
                                                        StationCodeS = long.Parse(temSeq.Element("StationCodeS").Value),
                                                        Distance = double.Parse(temSeq.Element("Distance").Value),
                                                        TravelTime = XmlConvert.ToTimeSpan(temSeq.Element("TravelTime").Value.ToString())
                                                    });
            return temp.Where(s => s.Valid == true);

        }

        public SequentialStopInfo GetSequentialStopInfo(long fCode, long sCode)
        {
            var temList = GetAllSequentialStopInfo();

            var t = from seqStop in temList
                    where (seqStop.StationCodeF == fCode && seqStop.StationCodeS == sCode)
                    select seqStop;
            if (t.ToList().Count == 0)
                throw new Exception("no SequentialStopInfo with such license number!!");
            if (!t.First().Valid)
                throw new Exception("SequentialStopInfoList is not valid!!");
            return t.ToList().First();
        }

    }
}
