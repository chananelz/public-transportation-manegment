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
            DataSource.UserList.Add(user);
        }
        public User RequestUser(string id)
        {
            return DataSource.UserList.Find(s => s.Password == id);
        }
        public void UpdateUser(User user)
        {
            int indLine;
            if (user.Password != null)
            {
                indLine = DataSource.UserList.FindIndex(l => l.Password == user.Password);
                DataSource.UserList[indLine] = user;
            }
            else
                throw new Exception("user doesn't exist!!");
        }
        public void DeleteUser(User user)
        {
            if (user.Password != null) 
                DataSource.UserList.Remove(user);
            else
                throw new Exception("user doesn't exist!!");
        }
        public IEnumerable<User> GetAllUsers(Predicate<User> pr = null)
        {
            if (pr == null)
            {
                IEnumerable<User> userList = new List<User>();
                userList = DataSource.UserList;
                var temp = DataSource.UserList;
                return temp as IEnumerable<User>;
                //return DataSource.UserList;
            }
            else
                return from b in DataSource.UserList
                       where (pr(b))
                       select b;
        }
    }
}
