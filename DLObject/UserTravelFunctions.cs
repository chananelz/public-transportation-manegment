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
        /// <summary>
        /// add new userTravel to database
        /// </summary>
        /// <param name="userTravel"></param>
        public void CreateUserTravel(UserTravel userTravel)
        {
            DataSource.UserTravelList.Add(userTravel);
        }
        /// <summary>
        /// request a UserTravel according to a predicate
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserTravel RequestUserTravel(long Id)
        {
            return DataSource.UserTravelList.Find(l => l.LineId == Id);
        }
        /// <summary>
        /// update userTravel in database
        /// </summary>
        /// <param name="userTravel"></param>
        public void UpdateUserTravel(UserTravel userTravel)
        {
            int indLine;
            indLine = DataSource.UserTravelList.FindIndex(l => l.LineId == userTravel.LineId);
            DataSource.UserTravelList[indLine] = userTravel;
        }
        /// <summary>
        /// sets user travel valid to false
        /// </summary>
        /// <param name="userTravel"></param>
        public void DeleteUserTravel(UserTravel userTravel)
        {
            DataSource.UserTravelList.Remove(userTravel);
        }
        /// <summary>
        /// gets all user travels according to predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
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
