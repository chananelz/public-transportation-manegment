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
    public partial class DOImp:IDal
    {
        public void CreateBusTravel(BusTravel busTravel)
        {
            DataSource.Bus_TravelList.Add(busTravel);
        }
        public BusTravel RequestBusTravel(long id)
        {
            return DataSource.Bus_TravelList.Find(b=>b.License_Number == id);
        }
        public void UpdateBusTravel(BusTravel busTravel)
        {
            int indBus;
            if (busTravel.License_Number != null)
            {
                indBus = DataSource.Bus_TravelList.FindIndex(b => busTravel.License_Number == b.License_Number);
                DataSource.Bus_TravelList[indBus] = busTravel;
            }
            else
                throw new Exception("busTravel doesn't exist!!");
        }
        public void DeleteBusTravel(BusTravel busTravel)
        {
            if (busTravel.License_Number != null)
                DataSource.Bus_TravelList.Remove(busTravel);
            else
                throw new Exception("busTravel doesn't exist!!");
        }
        public IEnumerable<BusTravel> GetAllBusTravels(Func<BusTravel, bool> predicate = null)
        {
            return from b in DataSource.Bus_TravelList
                   where (predicate(b))
                   select b;
        }
    }
}
