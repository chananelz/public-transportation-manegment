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
        public void CreateBus(Bus bus)
        {
            DataSource.BusesList.Add(bus);
        }

        public Bus RequestBus(long id)
        {
            Bus tem = DataSource.BusesList.Find(b => b.LicenseNumber == id);
            if (tem != null)
                return tem; //.Clone();
            else
                throw new DO.Exceptions.DOBadBusIdException(id);


        }

        public void UpdateBus(Bus bus)
        {
            int indBus;
            if (bus.LicenseNumber != null)
            {
                indBus = DataSource.BusesList.FindIndex(b => bus.LicenseNumber == b.LicenseNumber);
                if (indBus == -1)
                {
                    throw new DO.Exceptions.DOBadBusIdException((long)bus.LicenseNumber);  // ההמרה רק כדי לבטל את הסימן שאלה
                }
                DataSource.BusesList[indBus] = bus;
            }
            //else
            //    throw new Exception("bus doesn't exist!!");  
        }

        public void DeleteBus(Bus bus)
        {
            bool flage;

            if (bus.LicenseNumber != null)
            {
                flage = DataSource.BusesList.Remove(bus);
            }
            else
                throw new ArgumentNullException();
            if (!flage)
            {
                throw new DO.Exceptions.DOBadBusIdException((long)bus.LicenseNumber);
            }
        }

        public IEnumerable<Bus> GetAllBusses(Predicate<Bus> pr = null)
        {
            if (pr == null)
                return DataSource.BusesList;
            else
                return from b in DataSource.BusesList
                   where (pr(b))
                   select b;
        }
    }
}

