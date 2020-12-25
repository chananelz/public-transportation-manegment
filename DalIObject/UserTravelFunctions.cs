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
        public void CreateUserTravel(UserTravel userTravel)
        {
            DataSource.User_TravelList.Add(userTravel);
        }
        public UserTravel RequestUserTravel(long Id)  //check this...
        {
            return DataSource.User_TravelList.Find(l => l.lineID == Id);
        }
        public void UpdateUserTravel(UserTravel userTravel)
        {
            int indLine;
            if (userTravel.lineID != null)
            {
                indLine = DataSource.User_TravelList.FindIndex(l => l.lineID == userTravel.lineID);
                DataSource.User_TravelList[indLine] = userTravel;
            }
            else
                throw new Exception("userTravel doesn't exist!!");
        }
        public void DeleteUserTravel(UserTravel userTravel)
        {
            if (userTravel.lineID != null)
                DataSource.User_TravelList.Remove(userTravel);
            else
                throw new Exception("userTravel doesn't exist!!");
        }
        public IEnumerable<UserTravel> GetAllUserTravels(Func<UserTravel, bool> predicate = null)
        {
            return from b in DataSource.User_TravelList
                   where (predicate(b))
                   select b;
        }

    }
}
