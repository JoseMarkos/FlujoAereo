using FlujoAereo.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Services
{
    class MariaDBAdapter : IUserAccountAdapter
    {

        private static string Year = DateTime.Now.Year.ToString();
        private static string Month = DateTime.Now.Month.ToString();
        private static string Day = DateTime.Now.Day.ToString();
        

        Stream IUserAccountAdapter.GetParkingAccountConnection()
        {
            throw new NotImplementedException();
        }
    }
}
