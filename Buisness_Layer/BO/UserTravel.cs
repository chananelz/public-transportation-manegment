using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class UserTravel
    {
        public bool Valid { get; set; }
        public string UserName { get; set; }
        public int LineNumber { get; set; }
        public DateTime OnStopTime { get; set; }
        public DateTime OffStopTime { get; set; }


        public UserTravel()
        {

        }
        public UserTravel(string userName, int lineNumber, DateTime onStopTime, DateTime offStopTime)
        {
            Valid = true;
            UserName = userName;
            LineNumber = lineNumber;
            OnStopTime = onStopTime;
            OffStopTime = offStopTime;
        }
        public override string ToString()
        {
            return ("userName:" + UserName  + "onStopTime:" + OnStopTime + "offStopTime:" + OffStopTime + "valid" + Valid);
        }
    }
}
