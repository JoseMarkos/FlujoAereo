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

                string sql = "INSERT INTO `flujoaereo`.`airline` (`Code`, `Name`, `Country`, `Region`, `Status`, `Aircraft`) VALUES ('" + airline.Code + "', '" + airline.Name + "', '" + airline.Country + "', '" + airline.Region + "', '" + airline.AirlineStatus + "', '" + airline.AircraftList + "');";

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

        public List<Airline> GetAllAirlines()
        {
            List<Airline> list = new List<Airline>();

            MySqlConnection connection = adapter.GetConection();
            string sql = "SELECT * FROM `flujoaereo`.`airline`;";

            using (var command = new MySqlCommand(sql, connection))

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Airline airline = new Airline()
                    {
                        ID = reader.GetInt32(0),
                        Code = reader.GetString(1),
                        Name = reader.GetString(2),
                        Country = reader.GetString(3),
                        Region = reader.GetString(4),
                        AirlineStatus = reader.GetInt32(5),
                        AircraftList = reader.GetString(6)
                    };
                    list.Add(airline);
                }
                return list;
            }
        }
    }
}
