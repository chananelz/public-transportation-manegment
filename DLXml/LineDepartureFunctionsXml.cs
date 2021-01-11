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
    public partial class DLXML : IDal
    {
        #region LineDeparture

        /// <summary>
        /// add new line departure to database
        /// </summary>
        /// <param name="lineDeparture"></param>
        public void CreateLineDeparture(LineDeparture lineDeparture)
        {


            List<LineDeparture> LineDepartureList = XMLTools.LoadListFromXMLSerializer<LineDeparture>(lineDeparturesPath);
            LineDepartureList.Add(lineDeparture);
            XMLTools.SaveListToXMLSerializer(LineDepartureList, lineDeparturesPath);

        }

        /// <summary>
        /// request a LineDeparture according to a predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public LineDeparture RequestLineDeparture(Predicate<LineDeparture> pr = null)
        {
            List<LineDeparture> LineDepartureList = XMLTools.LoadListFromXMLSerializer<LineDeparture>(lineDeparturesPath);
            LineDeparture ret = LineDepartureList.Find(lineDeparture => pr(lineDeparture));


            if (ret == null)
                throw new Exception("no lineDeparture that meets these conditions!");
            if (ret.Valid == false)
                throw new Exception("lineDeparture that meets these conditions is not valid");
            return ret;
        }

        /// <summary>
        /// request a LineDeparture according to a predicate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="time_Start"></param>
        /// <returns></returns>
        public LineDeparture GetLineDeparture(long id, DateTime time_Start)
        {
            List<LineDeparture> LineDepartureList = XMLTools.LoadListFromXMLSerializer<LineDeparture>(lineDeparturesPath);

            var t = from lineDeparture in LineDepartureList
                    where (lineDeparture.Id == id)
                    select lineDeparture;
            if (t.ToList().Count == 0)
                throw new Exception("no bus with such license number!!");
            if (!t.First().Valid)
                throw new Exception("bus is not valid!!");

            return t.ToList().First();
        }

        /// <summary>
        /// update linedepartuer frquency in database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="time_Start"></param>
        /// <param name="frequency"></param>
        public void UpdateLineDepartureFrequency(long id, DateTime time_Start, int frequency)
        {
            List<LineDeparture> LineDepartureList = XMLTools.LoadListFromXMLSerializer<LineDeparture>(lineDeparturesPath);

            GetLineDeparture(id, time_Start); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות
            LineDepartureList.Find(p => (p.Id == id) && (p.Time_Start == time_Start)).Frequency = frequency;
            XMLTools.SaveListToXMLSerializer(LineDepartureList, lineDeparturesPath);
        }
        /// <summary>
        /// update time_End in database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="time_Start"></param>
        /// <param name="time_End"></param>
        public void UpdateLineDepartureTime_End(long id, DateTime time_Start, DateTime time_End)
        {
            List<LineDeparture> LineDepartureList = XMLTools.LoadListFromXMLSerializer<LineDeparture>(lineDeparturesPath);

            GetLineDeparture(id, time_Start); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות
            LineDepartureList.Find(p => (p.Id == id) && (p.Time_Start == time_Start)).Time_End = time_End;
            XMLTools.SaveListToXMLSerializer(LineDepartureList, lineDeparturesPath);
        }
        /// <summary>
        /// delete line departure in database acording to id and timestart
        /// </summary>
        /// <param name="id">id of lineDeparture</param>
        /// <param name="time_Start"></param>
        public void DeleteLineDeparture(long id, DateTime time_Start)
        {
            List<LineDeparture> LineDepartureList = XMLTools.LoadListFromXMLSerializer<LineDeparture>(lineDeparturesPath);

            GetLineDeparture(id, time_Start); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות
            LineDepartureList.Find(p => (p.Id == id) && (p.Time_Start == time_Start)).Valid = false;
            XMLTools.SaveListToXMLSerializer(LineDepartureList, lineDeparturesPath);
        }

        /// <summary>
        /// get all line departures tha responde to this predicate
        /// </summary>
        /// <param name="pr">predicate</param>
        /// <returns>Ienumarble of line departures that responde to the predicate</returns>
        public IEnumerable<LineDeparture> GetAllLineDepartures(Predicate<LineDeparture> pr = null)
        {
            List<LineDeparture> LineDepartureList = XMLTools.LoadListFromXMLSerializer<LineDeparture>(lineDeparturesPath);

            if (pr == null)
                return LineDepartureList;
            else
                return from ld in LineDepartureList
                       where (pr(ld))
                       select ld;
        }
        #endregion
    }
}
