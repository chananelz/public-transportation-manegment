using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using DalApi;
using BLApi;
using BLImp;
using BL;
//aa

namespace BLApi
{
    public static class Factory
    {
        public static IBL GetBL(string type)
        {
            switch (type)
            {
                case "1":
                    return new BLImp.BL();
                default:
                    return new BLImp.BL();
            }
        }
    }
}