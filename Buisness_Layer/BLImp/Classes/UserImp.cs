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

            string exception = "";
            bool foundException = false;
            try
            {
                valid.UserNameExist(userName);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                valid.GoodString(userName);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                valid.GoodPassword(password);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                valid.GoodPermission(permission);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            if (foundException)
                throw new Exception(exception);
            User userBO = new User(userName, password, permission);
            DO.User userDO = userBO.GetPropertiesFrom<DO.User, BO.User>();
            dal.CreateUser(userDO);
        }
        public User RequestUser(Predicate<User> pr)
        {
            if (pr == null)
                throw new Exception("can't request user with no predicate!");
            return dal.RequestUser(user => pr(user.GetPropertiesFrom<BO.User, DO.User>())).GetPropertiesFrom<BO.User, DO.User>();

        }
        public void UpdateName(string name, string nameId)
        {
            string exception = "";
            bool foundException = false;
            try
            {
                valid.UserNameExist(name);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                valid.GoodString(name);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            if (foundException)
                throw new Exception(exception);
            dal.UpdateName(name, nameId);
        }

        public void UpdatePassword(string password, string nameId)
        {
            valid.GoodPassword(password);
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
                return dal.GetAllUsers().Select(user => user.GetPropertiesFrom<BO.User, DO.User>()).ToList();
            }
            IEnumerable<DO.User> temp =  dal.GetAllUsers();
            if (temp.ToList().Count == 0)
                throw new Exception("no such user!");
            else
                return temp.Select(user => user.GetPropertiesFrom<BO.User, DO.User>()).Where(b => pr(b)).ToList();

        }

        public User Authinticate(string username, string password,authority au)
        {
            IEnumerable<User> temp = GetAllUsers(user => user.UserName == username && user.Password == password && au == user.Permission);
            if (temp.ToList().Count == 0)
                throw new Exception("no such user!");
            else return temp.First();
        }
        public IEnumerable<User> GetAllDrivers()
        {
            return GetAllUsers(user => user.Permission == authority.Driver);
        }
        public IEnumerable<User> GetAllPassengers()
        {
            return GetAllUsers(user => user.Permission == authority.Passenger);
        }
    }
}