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

        #region User  // Special initialization with XElement


        public enum authority
        {
            Passenger,
            Driver,
            CEO
        }


        public User GetUser(string nameId)
        {

            XElement userRootElem = XMLTools.LoadListFromXMLElement(usersPath);

            User myUser = (from temUser in userRootElem.Elements()
                           where temUser.Element("UserName").Value == nameId
                           select new User()
                           {
                               Valid = bool.Parse(temUser.Element("Valid").Value),
                               UserName = temUser.Element("UserName").Value,
                               Password = temUser.Element("Password").Value,
                               Permission = (DO.authority)authority.Parse(typeof(authority), temUser.Element("Permission").Value)

                           }
                                  ).FirstOrDefault();
            if (myUser == null)
            {
                throw new DO.DOBadUserIdException("no user with such UserName!!");
            }
            if (!myUser.Valid)
            {
                throw new Exception("user is not valid!!");
            }
            return myUser;

        }


        /// <summary>
        /// add new user to database
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(User user)
        {
            XElement userRootElem = XMLTools.LoadListFromXMLElement(usersPath);
            user.Valid = true;

            try
            {
                // GetUser(user.Password);
                GetUser(user.UserName);
            }
            catch (Exception ex)
            {
                if (ex.Message == "no user with such UserName!!")
                {
                    XElement userElem = new XElement("User",
                                  new XElement("Valid", user.Valid.ToString()),
                                  new XElement("UserName", user.UserName),
                                  new XElement("Password", user.Password),
                                  new XElement("Permission", user.Permission.ToString()));

                    userRootElem.Add(userElem);
                    XMLTools.SaveListToXMLElement(userRootElem, usersPath);



                }

                else if (ex.Message == "user is not valid!!")
                {
                    XElement per = (from temUser in userRootElem.Elements()
                                    where temUser.Element("UserName").Value == user.UserName
                                    select temUser).FirstOrDefault();

                    per.Element("Valid").Value = user.Valid.ToString();


                    XMLTools.SaveListToXMLElement(userRootElem, usersPath);
                }
                return;
            }
            throw new Exception("user already exists!!!");

        }

        /// <summary>
        /// request a User according to a predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
       
        public User RequestUser(Predicate<DO.User> pr = null)
        {
            XElement userRootElem = XMLTools.LoadListFromXMLElement(usersPath);
            var tem = from temUser in userRootElem.Elements()
                      let u1 = new User()
                      {
                          Valid = bool.Parse(temUser.Element("Valid").Value),
                          UserName = temUser.Element("UserName").Value,
                          Password = temUser.Element("Password").Value,
                          Permission = (DO.authority)authority.Parse(typeof(authority), temUser.Element("Permission").Value)
                      }
                      where pr(u1)
                      select u1;
            return tem.FirstOrDefault();
        }

        /// <summary>
        /// update name in database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nameId"></param>
        public void UpdateName(string name, string nameId)
        {
            XElement userRootElem = XMLTools.LoadListFromXMLElement(usersPath);

            XElement myUser = (from u in userRootElem.Elements()
                               where u.Element("UserName").Value == nameId
                               select u).FirstOrDefault();
            if (myUser.Element("Valid").Value.ToString() == "false")
            {
                throw new Exception("user is not valid!!");
            }

            if (myUser == null)
            {
                throw new Exception("no user with such UserName!!");
            }

            if (myUser != null)
            {
                myUser.Element("UserName").Value = nameId;
                XMLTools.SaveListToXMLElement(userRootElem, usersPath);
            }

        }

        /// <summary>
        /// sets a user id valid to false
        /// </summary>
        /// <param name="nameId"></param>
        /// 
        public void DeleteUser(string nameId)
        {
            XElement userRootElem = XMLTools.LoadListFromXMLElement(usersPath);

            XElement myUser = (from u in userRootElem.Elements()
                               where u.Element("UserName").Value == nameId
                               select u).FirstOrDefault();
            if (myUser.Element("Valid").Value == "false")
            {
                throw new Exception("user is not valid!!");
            }

            if (myUser == null)
            {
                throw new Exception("no user with such UserName!!");
            }

            if (myUser != null)
            {
                myUser.Element("Valid").Value = "false";
                XMLTools.SaveListToXMLElement(userRootElem, usersPath);
            }
        }

        /// <summary>
        /// update password in database
        /// </summary>
        /// <param name="password"></param>
        /// <param name="nameId"></param>
        public void UpdatePassword(string password, string nameId)
        {
            XElement userRootElem = XMLTools.LoadListFromXMLElement(usersPath);

            XElement myUser = (from u in userRootElem.Elements()
                               where u.Element("UserName").Value == nameId
                               select u).FirstOrDefault();

            if (myUser.Element("Valid").Value == "false")
            {
                throw new Exception("user is not valid!!");
            }

            if (myUser == null)
            {
                throw new Exception("no user with such UserName!!");
            }

            if (myUser != null)
            {
                myUser.Element("Password").Value = password;
                XMLTools.SaveListToXMLElement(userRootElem, usersPath);
            }
        }

        //// <summary>
        //// returns all users
        //// </summary>
        //// <returns></returns>
        //public IEnumerable<User> GetAllUsers()
        //{
        //    XElement userRootElem = XMLTools.LoadListFromXMLElement(usersPath);
        //    return from temUser in userRootElem.Elements()
        //           let u1 = new User()
        //           {
        //               Valid = bool.Parse(temUser.Element("Valid").Value),
        //               UserName = temUser.Element("UserName").Value,
        //               Password = temUser.Element("Password").Value,
        //               Permission = (DO.authority)authority.Parse(typeof(authority), temUser.Element("Permission").Value)
        //           }
        //           where u1.Valid == true
        //           select u1;
        //}



        public IEnumerable<User> GetAllUsers()
        {
            List<User> UsersList = XMLTools.LoadListFromXMLSerializer<User>(usersPath);
            //XMLTools.SaveListToXMLSerializer(BusesList, usersPath);
            var temList = new List<User>();

            foreach (User user in UsersList)
            {
                if (user.Valid == true)
                    temList.Add(user);
            }
            return temList;
        }








        #endregion
    }
}
