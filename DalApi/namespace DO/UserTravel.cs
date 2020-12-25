using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class UserTravel
    {
        public bool Valid { get; set; }
        public long IdTravel { get; set; }
        public string UserName { get; set; }
        public int LineId { get; set; }
        public int OnStopId { get; set; }
        public DateTime OnStopTime { get; set; }
        public int OffStopId { get; set; }
        public DateTime OffStopTime { get; set; }


        public UserTravel()
        {

        }
        public UserTravel(UserTravel m_user)
        {
            Valid = m_user.Valid;
            IdTravel = m_user.IdTravel;
            UserName = m_user.UserName;
            LineId = m_user.LineId;
            OnStopId = m_user.OnStopId;
            OnStopTime = m_user.OnStopTime;
            OffStopId = m_user.OffStopId;
            OffStopTime = m_user.OffStopTime;
        }
        public override string ToString()
        {
            return ("Valid:" + Valid + "IdTravel:" + IdTravel + "userName:" + UserName + "lineID" + LineId + "onStopId:" + OnStopId + "onStopTime:" + OnStopTime + "offStopId" + OffStopId + "offStopTime:" + OffStopTime );
        }
    }
}
