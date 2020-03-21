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

            string sql = "INSERT INTO `flujoaereo`.`flight` (`Type`, `Origin`, `Destiny`, `Pist`, `DepartureDate`, `DepartureHour`, `ArrivalDate`, `ArrivalHour`, `FlightTime`) VALUES ('" + flight.Type + "', '" + flight.Origin + "', '" + flight.Destiny + "', '" + flight.Pist + "', '" + flight.DepartureDate + "', '" + flight.DepartureHour + "', '" + flight.ArrivalDate + "', '" + flight.ArrivalHour + "', '" + flight.FlightTime + "');";

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
                            Origin = reader.GetString(2),
                            Destiny = reader.GetString(3),
                            Pist = reader.GetInt32(4),
                            DepartureDate = reader.GetString(5),
                            DepartureHour = reader.GetString(6),
                            ArrivalDate = reader.GetString(7),
                            ArrivalHour = reader.GetString(8),
                            FlightTime = reader.GetString(9),
                            FlightStatus = reader.GetString(10),
                            Enabled = reader.GetInt32(11),
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
