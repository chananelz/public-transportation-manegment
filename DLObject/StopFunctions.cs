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
        public void CreateStop(Stop stop)
        {
            DataSource.StopList.Add(stop);
        }
        public Stop RequestStop(long id)
        {
            return DataSource.StopList.Find(s => s.StopCode == id);
        }
        public void UpdateStop(Stop stop)
        {
            int indLine;
            if (stop.StopCode != null)
            {
                indLine = DataSource.StopList.FindIndex(l => l.StopCode == stop.StopCode);
                DataSource.StopList[indLine] = stop;
            }
            else
                throw new Exception("stop doesn't exist!!");
        }
        public void DeleteStop(Stop stop)
        {
            if (stop.StopCode != null)
                DataSource.StopList.Remove(stop);
            else
                throw new Exception("stop doesn't exist!!");
        }
        public IEnumerable<Stop> GetAllStops(Predicate<Stop> pr = null)
        {
            if (pr == null)
                return DataSource.StopList;
            else
                return from b in DataSource.StopList
                   where (pr(b))
                   select b;
        }
    }
}
