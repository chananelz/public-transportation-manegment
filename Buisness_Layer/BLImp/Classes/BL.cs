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
        public static IDal dal;
        public BL()
        {
            dal = DalApi.Factory.GetDL();
        }
    }
}
