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
        public void CreateLineDeparture(LineDeparture lineDeparture)
        {
            DataSource.Line_DepartureList.Add(lineDeparture);
        }
        public LineDeparture RequestLineDeparture(long id)  
        {
            return DataSource.Line_DepartureList.Find(ld=>ld.Id == id);
        }
        public void UpdateLineDeparture(LineDeparture lineDeparture)
        {
            int indBus;
            if (lineDeparture.Id != null)
            {
                indBus = DataSource.Line_DepartureList.FindIndex(ld => lineDeparture.Id == ld.Id);
                DataSource.Line_DepartureList[indBus] = lineDeparture;
            }
            else
                throw new Exception("lineDeparture doesn't exist!!");
        }
        public void DeleteLineDeparture(LineDeparture lineDeparture)
        {
            if (lineDeparture.Id != null)
                DataSource.Line_DepartureList.Remove(lineDeparture);
            else
                throw new Exception("lineDeparture doesn't exist!!");
        }
        public IEnumerable<LineDeparture> GetAllLineDepartures(Func<LineDeparture, bool> predicate = null)
        {
            return from ld in DataSource.Line_DepartureList
                   where (predicate(ld))
                   select ld;
        }
    }
}
