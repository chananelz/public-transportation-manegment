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
        public void CreateUserTravel(UserTravel userTravel)
        {
            DataSource.UserTravelList.Add(userTravel);
        }
        public UserTravel RequestUserTravel(long Id)
        {
            return DataSource.UserTravelList.Find(l => l.LineId == Id);
        }
        public void UpdateUserTravel(UserTravel userTravel)
        {
            int indLine;
            indLine = DataSource.UserTravelList.FindIndex(l => l.LineId == userTravel.LineId);
            DataSource.UserTravelList[indLine] = userTravel;
        }
        public void DeleteUserTravel(UserTravel userTravel)
        {
            DataSource.UserTravelList.Remove(userTravel);
        }
        public IEnumerable<UserTravel> GetAllUserTravels(Predicate<UserTravel> pr = null)
        {
            if (pr == null)
                return DataSource.UserTravelList;
            else
                return from b in DataSource.UserTravelList
                   where (pr(b))
                   select b;
        }
    }
}
