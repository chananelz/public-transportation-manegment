using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public enum authority
    {
        Passenger = 0,
        Driver,
        CEO
    }
    public class User
    {
        public bool Valid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public authority Permission { get; set; }


        public User(string userName, string password, int permission) 
        {
            Valid = true;
            UserName = userName;
            Password = password;
            switch(permission)
            {
                case 0:
                    Permission = authority.Passenger;
                    break;
                case 1:
                    Permission = authority.Driver;
                    break;
                case 2:
                    Permission = authority.CEO;
                    break;
            }
        }
        public User(){ }


        public override string ToString()
        {
            return (/*"Valid:" + Valid +*/ "userName:" + UserName + "password:" + Password + "permission" + Permission + "valid" + Valid);
        }

    }
}
