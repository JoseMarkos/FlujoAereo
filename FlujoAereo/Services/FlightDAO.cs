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
    public sealed class FlightDAO
    {
        private IDBAdapter adapter;

        public FlightDAO(Server server)
        {
            DBAdapterFactory fileFactory = new DBAdapterFactory();

            adapter = fileFactory.GetAdapter(server);
        }

        public void Save(Models.Flight flight)
        {
            MySqlConnection conection = adapter.GetConection();

            string sql = "INSERT INTO `flujoaereo`.`flight` (`Type`, `Origin`, `Destiny`, `Pist`, `Departure`, `Arrival`, `FlightStatus`) VALUES ('" + flight.Type + "', '" + flight.Origin + "', '" + flight.Destiny + "', '" + flight.Pist + "', '" + flight.Departure + "', '" + flight.Arrival + "', '" + flight.FlightStatus + "');";

            try
            {
                MySqlCommand insertCommnad = new MySqlCommand(sql)
                {
                    Connection = conection
                };
                insertCommnad.ExecuteNonQuery();
                insertCommnad.Connection.Close();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        public List<Flight> GetAllFlights()
        {
            List<Flight> list = new List<Flight>();

            MySqlConnection connection = adapter.GetConection();
            string sql = "SELECT * FROM `flujoaereo`.`flight` WHERE Enabled = '1';";

            try
            {
                using (var command = new MySqlCommand(sql, connection))

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flight flight = new Flight()
                        {
                            ID = reader.GetInt32(0),
                            Type = reader.GetString(1),
                            Origin = reader.GetString(3),
                            Destiny = reader.GetString(4),
                            Pist = reader.GetInt32(5),
                            Departure = reader.GetDateTime(6),
                            Arrival = reader.GetDateTime(7),
                            FlightStatus = reader.GetString(8),
                            Enabled = reader.GetInt32(9),
                        };
                        list.Add(flight);
                    }
                    return list;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return list;
            }
        }
    }
}
