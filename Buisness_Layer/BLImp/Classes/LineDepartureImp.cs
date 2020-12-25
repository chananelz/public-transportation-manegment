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
        public void CreateLineDeparture(DateTime time_Start, DateTime timeEnd, int frequency)
        {
            LineDeparture lineDepartureBO = new LineDeparture(time_Start, timeEnd, frequency);
            DO.LineDeparture lineDepartureDO = lineDepartureBO.GetPropertiesFrom<DO.LineDeparture, BO.LineDeparture>();
            dal.CreateLineDeparture(lineDepartureDO);
        }



        public LineDeparture RequestLineDeparture(long id)
        {
            DO.LineDeparture lineDepartureDO = new DO.LineDeparture();
            lineDepartureDO = dal.RequestLineDeparture(id);
            BO.LineDeparture lineDepartureBO = lineDepartureDO.GetPropertiesFrom<BO.LineDeparture, DO.LineDeparture>();
            return lineDepartureBO;
        }
        public void UpdateLineDeparture(DateTime time_Start, DateTime timeEnd, int frequency)
        {
            LineDeparture lineDepartureBO = new LineDeparture(time_Start, timeEnd, frequency);
            DO.LineDeparture lineDepartureDO = lineDepartureBO.GetPropertiesFrom<DO.LineDeparture, BO.LineDeparture>();
            dal.UpdateLineDeparture(lineDepartureDO);
        }
        public void DeleteLineDeparture(DateTime time_Start, DateTime timeEnd, int frequency)
        {
            LineDeparture lineDepartureBO = new LineDeparture(time_Start, timeEnd, frequency);
            DO.LineDeparture lineDepartureDO = lineDepartureBO.GetPropertiesFrom<DO.LineDeparture, BO.LineDeparture>();
            dal.DeleteLineDeparture(lineDepartureDO);
        }
    }
}
