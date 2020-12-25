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
        public void CreateBusTravel(BusTravel busTravel)
        {
            DataSource.BusTravelList.Add(busTravel);
        }
        public BusTravel RequestBusTravel(long id)
        {
            return DataSource.BusTravelList.Find(b => b.License_Number == id);
        }
        public void UpdateBusTravel(BusTravel busTravel)
        {
            int indBus;
            if (busTravel.License_Number != null)
            {
                indBus = DataSource.BusTravelList.FindIndex(b => busTravel.License_Number == b.License_Number);
                DataSource.BusTravelList[indBus] = busTravel;
            }
            else
                throw new Exception("busTravel doesn't exist!!");
        }
        public void DeleteBusTravel(BusTravel busTravel)
        {
            if (busTravel.License_Number != null)
                DataSource.BusTravelList.Remove(busTravel);
            else
                throw new Exception("busTravel doesn't exist!!");
        }
        public IEnumerable<BusTravel> GetAllBusTravels(Predicate<BusTravel> pr = null)
        {
            if (pr == null)
                return DataSource.BusTravelList;
            else
                return from b in DataSource.BusTravelList
                   where (pr(b))
                   select b;
        }
    }
}
