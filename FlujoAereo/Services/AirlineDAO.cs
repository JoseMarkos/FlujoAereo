using FlujoAereo.Enums;
using FlujoAereo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FlujoAereo.Models;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace FlujoAereo.Services
{
    public sealed class AirlineDAO
    {
        private IDBAdapter adapter;

        public AirlineDAO(Server server)
        {
            DBAdapterFactory fileFactory = new DBAdapterFactory();

            adapter = fileFactory.GetAdapter(server);
        }

        public void Save(Airline airline)
        {
            try
            {
                MySqlConnection conection = adapter.GetConection();

                string sql = "INSERT INTO `flujoaereo`.`airline` (`Code`, `Name`, `Country`, `Region`, `Status`) VALUES ('" + airline.Code + "', '" + airline.Name + "', '" + airline.Country + "', '" + airline.Region + "', '" + airline.AirlineStatus + "');";

                MySqlCommand insertCommnad = new MySqlCommand(sql)
                {
                    Connection = conection
                };
                insertCommnad.ExecuteNonQuery();
                insertCommnad.Connection.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show
                    (e.Message);
            }
        }
    }
}
