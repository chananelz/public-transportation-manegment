using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public enum authority
    {
        Passenger,
        Driver,
        CEO
    }
    public class User
    {
        public bool Valid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public authority Permission { get; set; }//should this be static?

        public User()//not implemented
        {

        }
        public User(User m_user)//not implemented
        {
            Valid = m_user.Valid;
            UserName = m_user.UserName;
            Password = m_user.Password;
            Permission = m_user.Permission;
        }

        public override string ToString()
        {
            return ("Valid:" + Valid + "userName:" + UserName + "password:" + Password + "permission" + Permission);
        }

    }
   
}
