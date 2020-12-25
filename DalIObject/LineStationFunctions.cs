using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ds;
using DalApi;
using DO;


namespace DalObject
{
    public partial class DOImp : IDal
    {
        public void CreateLineStation(LineStation lineStation)
        {
            DataSource.Line_StationList.Add(lineStation);
        }
        public LineStation RequestLineStation(long id)
        {
            return DataSource.Line_StationList.Find(l=>l.Code == id);
        }
        public void UpdateLineStation(LineStation lineStation)
        {
            int indLine;
            if (lineStation.Code != null)
            {
                indLine = DataSource.Line_StationList.FindIndex(l => l.Code == lineStation.Code);
                DataSource.Line_StationList[indLine] = lineStation;
            }
            else
                throw new Exception("lineStation doesn't exist!!");
        }
        public void DeleteLineStation(LineStation lineStation)
        {
            if (lineStation.Code != null)
                DataSource.Line_StationList.Remove(lineStation);
            else
                throw new Exception("lineStation doesn't exist!!");
        }
        public IEnumerable<LineStation> GetAllLineStations(Func<LineStation, bool> predicate = null)
        {
            return from b in DataSource.Line_StationList
                   where (predicate(b))
                   select b;
        }

    }
}
