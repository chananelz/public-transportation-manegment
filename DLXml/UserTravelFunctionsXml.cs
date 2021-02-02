using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalApi;
using DO;


namespace DL
{
    public partial class DLXML : IDal
    {
        #region UserTravel

        /// <summary>
        /// add new userTravel to database
        /// </summary>
        /// <param name="userTravel"></param>
        public void CreateUserTravel(UserTravel userTravel)
        {
            List<UserTravel> UserTravelList = XMLTools.LoadListFromXMLSerializer<UserTravel>(userTravelPath);
            userTravel.Valid = true;

            try
            {
                GetUserTravel(userTravel.IdTravel);
            }
            catch (Exception ex)
            {
                if (ex.Message == "no user with such license number!!")
                {
                    UserTravelList.Add(userTravel);
                }
                else if (ex.Message == "bus is not valid!!")
                {
                    UserTravelList.Find(ut => ut.IdTravel == userTravel.IdTravel).Valid = true;
                }
                XMLTools.SaveListToXMLSerializer(UserTravelList, userTravelPath);
                return;
            }

            throw new Exception("user already exists!!!");


        }




        /// <summary>
        /// request a UserTravel according to a predicate
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserTravel RequestUserTravel(Predicate<UserTravel> pr = null)
        {
            List<UserTravel> UserTravelList = XMLTools.LoadListFromXMLSerializer<UserTravel>(userTravelPath);
            return UserTravelList.Find(l => pr(l));
        }



        /// <summary>
        /// sets user travel valid to false
        /// </summary>
        /// <param name="userTravel"></param>
        public void DeleteUserTravel(long id)
        {
            List<UserTravel> UserTravelList = XMLTools.LoadListFromXMLSerializer<UserTravel>(userTravelPath);

            GetUserTravel(id); // בודק אם קיים אוטובוס כזה אם לא זורק חריגות

            UserTravelList.Find(p => p.IdTravel == id).Valid = false;
            XMLTools.SaveListToXMLSerializer(UserTravelList, userTravelPath);
        }

        /// <summary>
        /// gets all user travels according to predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public IEnumerable<UserTravel> GetAllUserTravels()
        {
            List<UserTravel> UserTravelList = XMLTools.LoadListFromXMLSerializer<UserTravel>(userTravelPath);
            
            var temList = new List<UserTravel>();

            foreach (UserTravel busTravel in UserTravelList)
            {
                if (busTravel.Valid == true)
                    temList.Add(busTravel);
            }
            return temList;
        }


        public UserTravel GetUserTravel(long id)
        {
            List<UserTravel> UserTravelList = XMLTools.LoadListFromXMLSerializer<UserTravel>(userTravelPath);

            var t = from ut in UserTravelList
                    where (ut.IdTravel == id)
                    select ut;

            if (t.ToList().Count == 0)
                throw new Exception("no user with such license number!!");
            if (!t.First().Valid)
                throw new Exception("bus is not valid!!");

            return t.ToList().First();
        }


        #endregion
    }
}
