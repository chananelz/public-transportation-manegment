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
        public void CreateLineStation(long code, long number)
        {
            LineStation lineStationBO = new LineStation(code, number);
            DO.LineStation lineStationDO = lineStationBO.GetPropertiesFrom<DO.LineStation, BO.LineStation>();
            dal.CreateLineStation(lineStationDO);
        }
        public LineStation RequestLineStation(long id)
        {
            DO.LineStation lineStationDO = new DO.LineStation();
            lineStationDO = dal.RequestLineStation(id);
            BO.LineStation lineStationBO = lineStationDO.GetPropertiesFrom<BO.LineStation, DO.LineStation>();
            return lineStationBO;
        }
        public void UpdateLineStation(long code, long number)
        {
            LineStation lineStationBO = new LineStation(code, number);
            DO.LineStation lineStationDO = lineStationBO.GetPropertiesFrom<DO.LineStation, BO.LineStation>();
            dal.UpdateLineStation(lineStationDO);
        }
        public void DeleteLineStation(long code, long number)
        {
            LineStation lineStationBO = new LineStation(code, number);
            DO.LineStation lineStationDO = lineStationBO.GetPropertiesFrom<DO.LineStation, BO.LineStation>();
            dal.DeleteLineStation(lineStationDO);
        }
    }
}
