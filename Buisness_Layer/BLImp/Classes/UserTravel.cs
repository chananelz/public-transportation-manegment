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
        public void CreateUserTravel(string userName, long lineNumber, DateTime onStopTime, DateTime offStopTime)
        {
            string exception = "";
            bool foundException = false;
            try
            {
                //userName
            }
            catch (BOBadBusIdException ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                //validate lineNumber
            }
            catch (BOBadBusIdException ex)
            {
                if (!foundException)
                {
                    exception += ex.Message;
                    foundException = true;
                }
            }
            try
            {
                //onStopTime
            }
            catch (BOBadBusIdException ex)
            {
                if (!foundException)
                {
                    exception += ex.Message;
                    foundException = true;
                }
            }
            try
            {
                //OffStopTime
            }
            catch (BOBusException ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            if (foundException)
                throw new BOBusException("There is something wrong with your input." + "Please Check these things :\n" + exception);  //להוסיף את האינפוט שלו עם דולר

            UserTravel userTravelBO = new UserTravel(userName, lineNumber, onStopTime, offStopTime);
            DO.UserTravel userTravelDO = userTravelBO.GetPropertiesFrom<DO.UserTravel, BO.UserTravel>();
            try
            {
                dal.CreateUserTravel(userTravelDO);
            }
            catch (DO.DOBadBusIdException ex)
            {

                throw new BODOBadBusIdException("cant create this userTravel", ex);
            }



        }
        public UserTravel RequestUserTravel(Predicate<UserTravel> pr = null)
        {
            try
            {
                return dal.RequestUserTravel(user => pr(user.GetPropertiesFrom<BO.UserTravel, DO.UserTravel>())).GetPropertiesFrom<BO.UserTravel, DO.UserTravel>();
            }
            catch (DO.DOBusException ex)
            {

                throw new BODOBadBusIdException("can't find this bus", ex);
            }
        }
        public void DeleteUserTravel(long id)
        {
           
            dal.DeleteUserTravel(id);
        }


        public IEnumerable<UserTravel> GetAllUserTravels(Predicate<UserTravel> pr = null)
        {
            if (pr == null)
            {
                return dal.GetAllUserTravels().Select(userTravel => userTravel.GetPropertiesFrom<BO.UserTravel, DO.UserTravel>()).ToList(); ;
            }
            return dal.GetAllUserTravels().Select(bus => bus.GetPropertiesFrom<BO.UserTravel, DO.UserTravel>()).Where(b => pr(b));
        }
        public IEnumerable<UserTravel> GetAllDriverTravel()
        {
            return GetAllUserTravels(userTravel => GetUser(userTravel.UserName).Permission == authority.Driver);
        }
        public IEnumerable<UserTravel> GetAllPassengersTravel()
        {
            return GetAllUserTravels(userTravel => GetUser(userTravel.UserName).Permission == authority.Passenger);
        }




        public UserTravel GetUserTravel(long id)
        {
            try
            {
                return dal.GetUserTravel(id).GetPropertiesFrom<BO.UserTravel, DO.UserTravel>();
            }
            catch (DO.DOBadBusIdException ex)
            {
                throw new BODOBadBusIdException(ex.Message, ex);
            }
        }


        public UserTravel GetDriverTravel(long lineNumber, DateTime formalDepartureTime)
        {
            return RequestUserTravel(userTravel => userTravel.LineNumber == lineNumber && userTravel.OnStopTime == formalDepartureTime);
        }

    }
}