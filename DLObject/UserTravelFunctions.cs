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
            userTravel.Valid = true;
            UserTravel a = new UserTravel();
            try
            {
                a = GetUserTravel(userTravel.IdTravel);
            }
            catch (DOBadBusIdException ex)
            {
                if (ex.Message == "no userTravel with such license number!!")
                    DataSource.UserTravelList.Add(userTravel);
                else if (ex.Message == "bus is not valid!!")
                {
                    DataSource.UserTravelList.Add(userTravel);
                }
                return;
            }
            throw new DOBadBusIdException(userTravel.IdTravel, "userTravel already exists!!!");
        }



        /// <summary>
        /// Get User Travel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserTravel GetUserTravel(long id)
        {
            var t = from userTravel in DataSource.UserTravelList
                    where (userTravel.IdTravel == id)
                    select userTravel;
            if (t.ToList().Count == 0)
                throw new DOBadBusIdException(id, "no userTravel with such license number!!");
            if (!t.First().Valid)
                throw new DOBadBusIdException(id, "userTravel is not valid!!");
            return t.ToList().First();
        }



        /// <summary>
        /// request a UserTravel according to a predicate
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserTravel RequestUserTravel(Predicate<UserTravel> pr = null)
        {

            UserTravel ret = DataSource.UserTravelList.Find(userTravel => pr(userTravel));
            if (ret == null)
                throw new DOBusException("no userTravel that meets these conditions!");
            if (ret.Valid == false)
                throw new DOBusException("userTravel that meets these conditions is not valid");
            return ret.GetPropertiesFrom<UserTravel, UserTravel>();
        }




     

  
        /// <summary>
        /// sets user travel valid to false
        /// </summary>
        /// <param name="userTravel"></param>
        public void DeleteUserTravel(long id)
        {
            GetUserTravel(id).Valid = false;
        }


        /// <summary>
        /// gets all user travels according to predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public IEnumerable<UserTravel> GetAllUserTravels()
        {
           

            var cloneList = new List<UserTravel>();
            foreach (UserTravel userTravel in DataSource.UserTravelList)
            {
                if (userTravel.Valid == true)
                    cloneList.Add(userTravel.GetPropertiesFrom<UserTravel, UserTravel>());
            }
            return cloneList;
        }

    }
}
