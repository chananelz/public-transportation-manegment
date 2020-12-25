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
        public void CreateLineDeparture(LineDeparture lineDeparture)
        {
            DataSource.LineDepartureList.Add(lineDeparture);
        }
        public LineDeparture RequestLineDeparture(long id)
        {
            return DataSource.LineDepartureList.Find(ld => ld.Id == id);
        }
        public void UpdateLineDeparture(LineDeparture lineDeparture)
        {
            int indBus;
            if (lineDeparture.Id != null)
            {
                indBus = DataSource.LineDepartureList.FindIndex(ld => lineDeparture.Id == ld.Id);
                DataSource.LineDepartureList[indBus] = lineDeparture;
            }
            else
                throw new Exception("lineDeparture doesn't exist!!");
        }
        public void DeleteLineDeparture(LineDeparture lineDeparture)
        {
            if (lineDeparture.Id != null)
                DataSource.LineDepartureList.Remove(lineDeparture);
            else
                throw new Exception("lineDeparture doesn't exist!!");
        }
        public IEnumerable<LineDeparture> GetAllLineDepartures(Predicate<LineDeparture> pr = null)
        {
            if (pr == null)
                return DataSource.LineDepartureList;
            else
                return from ld in DataSource.LineDepartureList
                   where (pr(ld))
                   select ld;
        }
    }
}
