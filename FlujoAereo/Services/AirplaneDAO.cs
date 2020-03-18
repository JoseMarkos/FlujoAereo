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
    public sealed class AirplaneDAO
    {
        private IDBAdapter adapter;

        public AirplaneDAO(Server server)
        {
            DBAdapterFactory fileFactory = new DBAdapterFactory();

            adapter = fileFactory.GetAdapter(server);
        }

        public void Save(Models.Airplane airplane)
        {
            MySqlConnection conection = adapter.GetConection();

            string sql = "INSERT INTO `flujoaereo`.`airplane` (`Model`, `ICAO`, `IATA`, `MaximunPassengers`, `MaximunCargo`, `Code`, `Enabled`) VALUES ('" + airplane.Model + "', '" + airplane.ICAO + "', '" + airplane.IATA + "', '" + airplane.MaximunPassengers + "', '" + airplane.MaximunCargo + "', '" + airplane.AircraftRegistration + "', '" + airplane.Enabled + "');";

            MySqlCommand insertCommnad = new MySqlCommand(sql);

            insertCommnad.Connection = conection;
            insertCommnad.ExecuteNonQuery();
            insertCommnad.Connection.Close();
        }
    }
}
