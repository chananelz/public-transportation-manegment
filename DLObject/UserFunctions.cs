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
        public void CreateUser(User user)
        {
            user.Valid = true;
            try
            {
                GetUser(user.Password);
            }
            catch (Exception ex)
            {
                if (ex.Message == "no user with such UserName!!")
                    DataSource.UserList.Add(user);
                else if (ex.Message == "user is not valid!!")
                {
                    var t = from userInput in DataSource.UserList
                            where (userInput.Password == user.Password)
                            select user;
                    t.ToList().First().Valid = true;
                }
                return;
            }
            throw new Exception("user already exists!!!");
        }

        public User RequestUser(Predicate<User> pr = null)
        {
            User ret = DataSource.UserList.Find(bus => pr(bus));
            if (ret == null)
                throw new Exception("no user with such UserName!!");
            ret = DataSource.UserList.Find(user => user.Valid == true);
            if (ret == null)
                throw new Exception("user is not valid!!");
            return ret.GetPropertiesFrom<User, User>();
        }
       

        public void UpdateName(string name, string nameId)
        {
            GetUser(nameId).UserName = name;
        }
        public void UpdatePassword(string password, string nameId)
        {
            GetUser(nameId).Password = password;
        }
        public void DeleteUser(string nameId)
        {
            GetUser(nameId).Valid = false;

        }


        public User GetUser(string password)
        {
            var t = from user in DataSource.UserList
                    where (user.Password == password)
                    select user;
            if (t.ToList().Count == 0)
                throw new Exception("no user with such UserName!!");
            if (!t.First().Valid)
                throw new Exception("user is not valid!!");
            return t.ToList().First();
        }

        public IEnumerable<User> GetAllUsers()
        {
            var cloneList = new List<User>();
            foreach (User user in DataSource.UserList)
            {
                if (user.Valid == true)
                    cloneList.Add(user.GetPropertiesFrom<User, User>());
            }
            return cloneList;
        }
    }
}





