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
        public void CreateLine(long number, string area, int firstStop, int lastStop)
        {
            //check number
            //check area
            //check firstStop
            //check lastStop
            Line lineBO = new Line(number, area, firstStop, lastStop);
            DO.Line lineDO = lineBO.GetPropertiesFrom<DO.Line, BO.Line>();
            dal.CreateLine(lineDO);
        }
        public Line RequestLine(Predicate<Line> pr = null)
        {
            return dal.RequestLine(line => pr(line.GetPropertiesFrom<BO.Line, DO.Line>())).GetPropertiesFrom<BO.Line, DO.Line>();

        }
        public void UpdateLineNumber(long number, long id)
        {
            //check number 
            dal.UpdateLineNumber(number, id);
        }

        public void UpdateLineArea(string area, long id)
        {
            //check area 
            dal.UpdateLineArea(area, id);
        }

        public void UpdateLineFirstStop(int firstStop, long id)
        {
            //check firstStop 
            dal.UpdateLineFirstStop(firstStop, id);
        }
        public void UpdateLineLastStop(int lastStop, long id)
        {
            //check lastStop 
            dal.UpdateLineLastStop(lastStop, id);
        }

        public void DeleteLine(long id)
        {
            dal.DeleteLine(id);
        }


        public IEnumerable<Line> GetAllLines(Predicate<Line> pr = null)
        {
            if (pr == null)
            {
                var tempList = dal.GetAllLines();
                var secondTempList = tempList.Select(line => line.GetPropertiesFrom<BO.Line, DO.Line>()).ToList();
                return secondTempList;
            }
            return dal.GetAllLines().Select(line => line.GetPropertiesFrom<BO.Line, DO.Line>()).Where(b => pr(b));
        }


    }
}
