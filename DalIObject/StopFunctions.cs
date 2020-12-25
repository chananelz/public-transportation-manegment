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
        public void CreateStop(Stop stop)
        {
            DataSource.StopList.Add(stop);
        }
        public Stop RequestStop(long id)
        {
            return DataSource.StopList.Find(s => s.stopCode == id);
        }
        public void UpdateStop(Stop stop)
        {
            int indLine;
            if (stop.stopCode != null)
            {
                indLine = DataSource.StopList.FindIndex(l => l.stopCode == stop.stopCode);
                DataSource.StopList[indLine] = stop;
            }
            else
                throw new Exception("stop doesn't exist!!");
        }
        public void DeleteStop(Stop stop)
        {
            if (stop.stopCode != null)
                DataSource.StopList.Remove(stop);
            else
                throw new Exception("stop doesn't exist!!");
        }
        public IEnumerable<Stop> Get_All_Stops(Func<Stop, bool> predicate = null)
        {
            return from b in DataSource.StopList
                   where (predicate(b))
                   select b;
        }

    }
}
