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
            UserTravelList.Add(userTravel);
            XMLTools.SaveListToXMLSerializer(UserTravelList, userTravelPath);
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
           
        }

        /// <summary>
        /// gets all user travels according to predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public IEnumerable<UserTravel> GetAllUserTravels()
        {
            return null;
        }










        public UserTravel GetUserTravel(long id)
        {
            return null;
        }


        #endregion
    }
}
