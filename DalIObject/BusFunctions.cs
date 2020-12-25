using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ds;
using DalApi;
using DO;
//11

namespace DalObject
{
    public partial class DOImp:IDal
    {
        public void CreateBus(Bus bus)
        {
            DataSource.BusesList.Add(bus);
        }
        public Bus RequestBus(long id)
        {
            return DataSource.BusesList.Find(b=> b.License_Number == id);
        }
        public void UpdateBus(Bus bus)
        {
            int indBus;
            if (bus.License_Number != null)
            {
                indBus = DataSource.BusesList.FindIndex(b => bus.License_Number == b.License_Number);
                DataSource.BusesList[indBus] = bus;
            }
            else
                throw new Exception("bus doesn't exist!!");
        }
        public void DeleteBus(Bus bus)
        {
            if (bus.License_Number != null)
                DataSource.BusesList.Remove(bus);
            else
                throw new Exception("bus doesn't exist!!");
        }
        public IEnumerable<Bus> GetAllBusses(Func<Bus, bool> predicate = null)
        {
            return from b in DataSource.BusesList
                   where (predicate(b))
                   select b;   
        }
    }
}
