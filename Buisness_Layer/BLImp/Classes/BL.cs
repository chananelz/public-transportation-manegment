using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using BLApi;

namespace BLImp
{
    public partial class BL:IBL
    {
        Validator valid = new Validator();
        public static IDal dal =DalApi.Factory.GetDL();
        public BL()
        {
        }
    }
}
