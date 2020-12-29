using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DS;
using DO;

namespace DL
{
    public partial class DLObject : IDal
    {
        public void CreateLineDeparture(LineDeparture lineDeparture) 
        {
            DataSource.LineDepartureList.Add(lineDeparture);
        }
        public LineDeparture RequestLineDeparture(Predicate<LineDeparture> pr = null) // ++
        {
            LineDeparture ret = DataSource.LineDepartureList.Find(lineDeparture => pr(lineDeparture));
            if (ret == null)
                throw new Exception("no lineDeparture that meets these conditions!");
            if (ret.Valid == false)
                throw new Exception("lineDeparture that meets these conditions is not valid");
            return ret.GetPropertiesFrom<LineDeparture, LineDeparture>();
        }

        public LineDeparture GetLineDeparture(long id, DateTime time_Start) //++
        {
            var t = from lineDeparture in DataSource.LineDepartureList
                    where (lineDeparture.Id == id)
                    select lineDeparture;
            if (t.ToList().Count == 0)
                throw new Exception("no bus with such license number!!");
            if (!t.First().Valid)
                throw new Exception("bus is not valid!!");

            return t.ToList().First();
        }

        public void UpdateLineDepartureFrequency(long id, DateTime time_Start ,int frequency)//++
        {
            GetLineDeparture(id, time_Start).Frequency = frequency;
        }

        public void UpdateLineDepartureTime_End(long id, DateTime time_Start , DateTime time_End)//++
        {
            GetLineDeparture(id, time_Start).Time_End = time_End;
        }
        public void DeleteLineDeparture(long id, DateTime time_Start) //++
        {
            GetLineDeparture(id, time_Start).Valid = false;
        }
        public IEnumerable<LineDeparture> GetAllLineDepartures(Predicate<LineDeparture> pr = null)
        {
            if (pr == null)
                return DataSource.LineDepartureList;
            else
                return from ld in DataSource.LineDepartureList
                   where (pr(ld))
                   select ld;
        }
    }
}
