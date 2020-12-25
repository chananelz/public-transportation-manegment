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
            Line lineBO = new Line(number, area, firstStop, lastStop);
            DO.Line lineDO = lineBO.GetPropertiesFrom<DO.Line, BO.Line>();
            dal.CreateLine(lineDO);
        }
        public Line RequestLine(long id)
        {
            DO.Line lineDO = new DO.Line();
            lineDO = dal.RequestLine(id);
            BO.Line lineBO = lineDO.GetPropertiesFrom<BO.Line, DO.Line>();
            return lineBO;
        }
        public void UpdateLine(long number, string area, int firstStop, int lastStop)
        {
            Line lineBO = new Line(number, area, firstStop, lastStop);
            DO.Line lineDO = lineBO.GetPropertiesFrom<DO.Line, BO.Line>();
            dal.UpdateLine(lineDO);
        }
        public void DeleteLine(long number, string area, int firstStop, int lastStop)
        {
            Line lineBO = new Line(number, area, firstStop, lastStop);
            DO.Line lineDO = lineBO.GetPropertiesFrom<DO.Line, BO.Line>();
            dal.DeleteLine(lineDO);
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
