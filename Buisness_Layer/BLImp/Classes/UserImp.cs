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

            // check userName 

            //check password

            //check permission

            User userBO = new User(userName, password, permission);
            DO.User userDO = userBO.GetPropertiesFrom<DO.User, BO.User>();
            dal.CreateUser(userDO);
        }
        public User RequestUser(Predicate<User> pr)
        {
            return dal.RequestUser(user => pr(user.GetPropertiesFrom<BO.User, DO.User>())).GetPropertiesFrom<BO.User, DO.User>();

        }
        public void UpdateName(string name, string nameId)
        {
            // check name 
            dal.UpdateName(name, nameId);
        }

        public void UpdatePassword(string password, string nameId)
        {
            //check status
            dal.UpdatePassword(password, nameId);
        }
        public void DeleteUser(string nameId)
        {
            dal.DeleteUser(nameId);
        }

        public IEnumerable<User> GetAllUsers(Predicate<User> pr)
        {
            if (pr == null)
            {
                var tempList = dal.GetAllUsers();
                var secondTempList = tempList.Select(user => user.GetPropertiesFrom<BO.User, DO.User>()).ToList();
                return secondTempList;
            }
            return dal.GetAllUsers().Select(user => user.GetPropertiesFrom<BO.User, DO.User>()).Where(b => pr(b)).ToList();

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