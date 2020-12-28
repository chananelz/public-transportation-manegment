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
            string exception = "";
            bool foundException = false;
            try
            {
                Validator.GoodLong(number);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                Validator.GoodString(area);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                Validator.GoodInt(firstStop);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                Validator.GoodInt(lastStop);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            if (foundException)
                throw new Exception(exception);
            Line lineBO = new Line(number, area, firstStop, lastStop);
            DO.Line lineDO = lineBO.GetPropertiesFrom<DO.Line, BO.Line>();
            dal.CreateLine(lineDO);
        }
        public Line RequestLine(Predicate<Line> pr = null)
        {
            if (pr == null)
                throw new Exception("can't request a line with no predicate");
            return dal.RequestLine(line => pr(line.GetPropertiesFrom<BO.Line, DO.Line>())).GetPropertiesFrom<BO.Line, DO.Line>();

        }
        public void UpdateLineNumber(long number, long id)
        {
            Validator.GoodLong(number);
            dal.UpdateLineNumber(number, id);
        }

        public void UpdateLineArea(string area, long id)
        {
            Validator.GoodString(area);
            dal.UpdateLineArea(area, id);
        }

        public void UpdateLineFirstStop(int firstStop, long id)
        {
            Validator.GoodInt(firstStop);
            dal.UpdateLineFirstStop(firstStop, id);
        }
        public void UpdateLineLastStop(int lastStop, long id)
        {
            Validator.GoodInt(lastStop);
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
                return dal.GetAllLines().Select(line => line.GetPropertiesFrom<BO.Line, DO.Line>()).ToList(); ;
            }
            return dal.GetAllLines().Select(line => line.GetPropertiesFrom<BO.Line, DO.Line>()).Where(b => pr(b));
        }


    }
}
