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


        public MySql.Data.MySqlClient.MySqlConnection GetConection()
        {
            MySql.Data.MySqlClient.MySqlConnection conection = new MySql.Data.MySqlClient.MySqlConnection();

            try
            {
                string mariadbString = "Server=localhost;User ID=root;Password=mariaroot;Database=flujoaereo";

                conection.ConnectionString = mariadbString;

                conection.Open();
            }
            catch (Exception)
            {

                throw new Exception("Error");
            }

            return conection;
        }
    }
}
