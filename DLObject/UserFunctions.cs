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
        /// add new user to database
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(User user)
        {
            user.Valid = true;
            try
            {
                // GetUser(user.Password);
                GetUser(user.UserName);
            }
            catch (Exception ex)
            {
                if (ex.Message == "no user with such UserName!!")
                    DataSource.UserList.Add(user);
                else if (ex.Message == "user is not valid!!")
                {
                    DataSource.UserList.Find(userInput => userInput.Password == user.Password).Valid = true;
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
        public User RequestUser(Predicate<User> pr = null)
        {
            User ret = DataSource.UserList.Find(bus => pr(bus));
            if (ret == null)
                throw new Exception("no user with such UserName!!");
            if (ret.Valid == false)
                throw new Exception("user is not valid!!");
            return ret.GetPropertiesFrom<User, User>();
        }

        /// <summary>
        /// update name in database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nameId"></param>
        public void UpdateName(string name, string nameId)
        {
            GetUser(nameId).UserName = name;
        }
        /// <summary>
        /// update password in database
        /// </summary>
        /// <param name="password"></param>
        /// <param name="nameId"></param>
        public void UpdatePassword(string password, string nameId)
        {
            GetUser(nameId).Password = password;
        }
        /// <summary>
        /// sets a user id valid to false
        /// </summary>
        /// <param name="nameId"></param>
        public void DeleteUser(string nameId)
        {
            GetUser(nameId).Valid = false;

        }
        /// <summary>
        /// gets a user according to name
        /// </summary>
        /// <param name="nameId"></param>
        /// <returns></returns>

        public User GetUser(string nameId)
        {
            var t = from user in DataSource.UserList
                    where (user.UserName == nameId)
                    select user;
            if (t.ToList().Count == 0)
                throw new Exception("no user with such UserName!!");
            if (!t.First().Valid)
                throw new Exception("user is not valid!!");
            return t.ToList().First();
        }
        /// <summary>
        /// returns all users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAllUsers()
        {
            var cloneList = new List<User>();
            foreach (User user in DataSource.UserList)
            {
                if (user.Valid == true)
                    cloneList.Add(user.GetPropertiesFrom<User, User>());
            }
            return cloneList.ToList();
        }
    }
}





