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
namespace FlujoAereo.Services
{
    public sealed class PilotDAO
    {
        private IDBAdapter adapter;

        public PilotDAO(Server server)
        {
            DBAdapterFactory fileFactory = new DBAdapterFactory();

            adapter = fileFactory.GetAdapter(server);
        }

        public void Save(Models.Piloto pilot)
        {
            MySqlConnection conection = adapter.GetConection();

            string sql = "INSERT INTO `flujoaereo`.`pilot` (`Name`, `Sex`, `Status`) VALUES ('" + pilot.Name + "', '" + pilot.Sex + "', '" + pilot.PilotStatus + "');";

            MySqlCommand insertCommnad = new MySqlCommand(sql)
            {
                Connection = conection
            };
            insertCommnad.ExecuteNonQuery();
            insertCommnad.Connection.Close();
        }
    }
}
