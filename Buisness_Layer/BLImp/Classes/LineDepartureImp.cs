using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using BO;
using BL;

namespace BLImp
{
    public partial class BL : IBL
    {
        public void CreateLineDeparture(long id, DateTime timeStart, int frequency, DateTime timeEnd)
        {
            string exception = "";
            bool foundException = false;

            try
            {
                valid.GoodLong(id);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }

            try
            {
                valid.GoodLong(frequency);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }

            try
            {
                valid.GoodDate(timeStart, timeEnd);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }

            if (foundException)
                throw new Exception(exception);

            LineDeparture lineDepartureBO = new LineDeparture(timeStart, timeEnd, frequency, id);
            DO.LineDeparture lineDepartureDO = lineDepartureBO.GetPropertiesFrom<DO.LineDeparture, BO.LineDeparture>();
            dal.CreateLineDeparture(lineDepartureDO);
        }

        public void UpdateLineDepartureFrequency(long id, DateTime timeStart, int frequency)
        {
            valid.GoodPositiveInt(frequency);
            dal.UpdateLineDepartureFrequency(id, timeStart, frequency);
        }

        public void UpdateLineDepartureTime_End(long id, DateTime timeStart, DateTime timeEnd) 
        {
            valid.GoodDate(timeStart, timeEnd);
            dal.UpdateLineDepartureTime_End(id, timeStart, timeEnd);
        }


        public LineDeparture RequestLineDeparture(Predicate<LineDeparture> pr)
        {
            if (pr == null)
                throw new Exception("can't request a line with no predicate");
            return dal.RequestLineDeparture(lineDeparture => pr(lineDeparture.GetPropertiesFrom<BO.LineDeparture, DO.LineDeparture>())).GetPropertiesFrom<BO.LineDeparture, DO.LineDeparture>();
        }

        public void DeleteLineDeparture(DateTime timeStart, DateTime timeEnd, int frequency, long id)
        {
            dal.DeleteLineDeparture(id, timeStart);
        }

        public IEnumerable<Line> GetAllLineById(long id)
        {
            var myList = GetAllLines(lineStation => lineStation.Id == id).ToList();
    
            return myList;
        }

        public IEnumerable<LineDeparture> GetAllLineDeparture(Predicate<LineDeparture> pr = null)
        {
            if (pr == null)
            {
                return dal.GetAllLineDepartures().Select(lineDepartures => lineDepartures.GetPropertiesFrom<BO.LineDeparture, DO.LineDeparture>()).ToList(); ;
            }
            return dal.GetAllLineDepartures().Select(lineDepartures => lineDepartures.GetPropertiesFrom<BO.LineDeparture, DO.LineDeparture>()).Where(b => pr(b));
        }
    }
}
