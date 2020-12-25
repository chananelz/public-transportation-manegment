using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public enum authority
    {
        CEO = 0,
        USER

    }
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public authority Permission { get; set; }


        public User(string userName, string password, int permission) 
        {
            UserName = userName;
            Password = password;
            switch(permission)
            {
                case 0:
                    Permission = authority.CEO;
                    break;
                case 1:
                    Permission = authority.USER;
                    break;
            }
        }
        public User(){ }


        public override string ToString()
        {
            return (/*"Valid:" + Valid +*/ "userName:" + UserName + "password:" + Password + "permission" + Permission);
        }

    }
}
