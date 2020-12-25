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
        public void CreateLineStation(LineStation lineStation)
        {
            DataSource.LineStationList.Add(lineStation);
        }
        public LineStation RequestLineStation(long id)
        {
            return DataSource.LineStationList.Find(l => l.Code == id);
        }
        public void UpdateLineStation(LineStation lineStation)
        {
            int indLine;
            if (lineStation.Code != null)
            {
                indLine = DataSource.LineStationList.FindIndex(l => l.Code == lineStation.Code);
                DataSource.LineStationList[indLine] = lineStation;
            }
            else
                throw new Exception("lineStation doesn't exist!!");
        }
        public void DeleteLineStation(LineStation lineStation)
        {
            if (lineStation.Code != null)
                DataSource.LineStationList.Remove(lineStation);
            else
                throw new Exception("lineStation doesn't exist!!");
        }
        public IEnumerable<LineStation> GetAllLineStations(Predicate<LineStation> pr = null)
        {

            if (pr == null)
                return DataSource.LineStationList;
            else
                return from b in DataSource.LineStationList
                   where (pr(b))
                   select b;
        }
    }
}
