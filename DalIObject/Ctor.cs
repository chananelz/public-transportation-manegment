using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ds;
using DalApi;
using DO;


namespace DalObject
{
    public partial class DOImp : IDal
    {
        public DOImp()
        {
            DataSource Ds = new DataSource();
        }
    }
}
