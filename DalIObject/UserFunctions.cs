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
        public void CreateUser(User user)
        {
            DataSource.UserList.Add(user);
        }
        public User RequestUser(long id)
        {
            return DataSource.UserList.Find(s => s.password == id);
        }
        public void UpdateUser(User user)
        {
            int indLine;
            if (user.password != null)
            {
                indLine = DataSource.UserList.FindIndex(l => l.password == user.password);
                DataSource.UserList[indLine] = user;
            }
            else
                throw new Exception("user doesn't exist!!");
        }
        public void DeleteUser(User user)
        {
            if (user.password != null)
                DataSource.UserList.Remove(user);
            else
                throw new Exception("user doesn't exist!!");
        }
        public IEnumerable<User> GetAllUsers(Func<User, bool> predicate = null)
        {
            return from b in DataSource.UserList
                   where (predicate(b))
                   select b;
        }
    }
}
