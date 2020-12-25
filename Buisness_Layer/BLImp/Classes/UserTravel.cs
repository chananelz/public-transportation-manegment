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
        public void CreateUserTravel(string userName, int lineNumber, DateTime onStopTime, DateTime offStopTime)
        {
            UserTravel userTravelBO = new UserTravel(userName, lineNumber, onStopTime, offStopTime);
            DO.UserTravel userTravelDO = userTravelBO.GetPropertiesFrom<DO.UserTravel, BO.UserTravel>();
            dal.CreateUserTravel(userTravelDO);
        }
        public UserTravel RequestUserTravel(long id)
        {
            DO.UserTravel userTravelDo = new DO.UserTravel();
            userTravelDo = dal.RequestUserTravel(id);
            BO.UserTravel userTravelBo = userTravelDo.GetPropertiesFrom<BO.UserTravel, DO.UserTravel>();
            return userTravelBo;
        }
        public void UpdateUserTravel(string userName, int lineNumber, DateTime onStopTime, DateTime offStopTime)
        {
            UserTravel userTravelBO = new UserTravel(userName, lineNumber, onStopTime, offStopTime);
            DO.UserTravel userTravelDO = userTravelBO.GetPropertiesFrom<DO.UserTravel, BO.UserTravel>();
            dal.UpdateUserTravel(userTravelDO);
        }
        public void DeleteUserTravel(string userName, int lineNumber, DateTime onStopTime, DateTime offStopTime)
        {
            UserTravel userTravelBO = new UserTravel(userName, lineNumber, onStopTime, offStopTime);
            DO.UserTravel userTravelDO = userTravelBO.GetPropertiesFrom<DO.UserTravel, BO.UserTravel>();
            dal.DeleteUserTravel(userTravelDO);
        }
    }
}
