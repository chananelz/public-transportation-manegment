using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using BO;
using BL;






namespace BLImp
{
    public partial class BL : IBL
    {
        public void CreateUser(string userName, string password, int permission)
        {
            User userBO = new User(userName, password, permission);
            DO.User userDO = userBO.GetPropertiesFrom<DO.User, BO.User>();
            dal.CreateUser(userDO);
        }
        public User RequestUser(string id)
        {
            DO.User userDO = new DO.User();
            userDO = dal.RequestUser(id);
            BO.User userBO = userDO.GetPropertiesFrom<BO.User, DO.User>();
            return userBO;
        }
        public void UpdateUser(string userName, string password, int permission)
        {
            User userBO = new User(userName, password, permission);
            DO.User userDO = userBO.GetPropertiesFrom<DO.User, BO.User>();
            dal.UpdateUser(userDO);
        }
        public void DeleteUser(string userName, string password, int permission)
        {
            User userBO = new User(userName, password, permission);
            DO.User userDO = userBO.GetPropertiesFrom<DO.User, BO.User>();
            dal.DeleteUser(userDO);
        }

        public IEnumerable<User> GetAllUsers(Predicate<User> pr)
        {
            //var tempList = new List<DO.User>();
            //tempList = dal.GetAllUsers().ToList();
            var tempList = dal.GetAllUsers();
            IEnumerable<User> thirdTempList = tempList.Select(user => user.GetPropertiesFrom<BO.User, DO.User>()).ToList();
          
            List<User> secondTempList = thirdTempList.Where(b => pr(b)).ToList();
            if (secondTempList.Count ==0)
                return null;
            return secondTempList.ToList();
        }

        public User Authinticate(string username, string password,authority au)
        {
            IEnumerable<User> temp = GetAllUsers(user => user.UserName == username && user.Password == password && au == user.Permission);
            if (temp == null)
                throw new Exception("no such user!");
            else return temp.First();
        }
    }
}