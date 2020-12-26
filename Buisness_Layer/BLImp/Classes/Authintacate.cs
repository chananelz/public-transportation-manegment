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
        public bool GoodLicense(long licenseNumber, DateTime dateTime)
        {
            return true;
        }
    }
}
