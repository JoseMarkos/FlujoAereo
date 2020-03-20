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

                string sql = "INSERT INTO `flujoaereo`.`airline` (`Name`, `ICAO`, `IATA`,  `Country`, `Region`, `Status`, `Aircraft`) VALUES ('" + airline.Name + "', '" + airline.ICAO + "', '" + airline.IATA + "', '" + airline.Country + "', '" + airline.Region + "', '" + airline.AirlineStatus + "', '" + airline.AircraftList + "');";

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
                        Name = reader.GetString(1),
                        ICAO = reader.GetString(2),
                        IATA = reader.GetString(3),
                        Country = reader.GetString(4),
                        Region = reader.GetString(5),
                        AirlineStatus = reader.GetInt32(6),
                        AircraftList = reader.GetString(7)
                    };
                    list.Add(airline);
                }
                return list;
            }
        }

        public int GetID(string name)
        {
            string readerString = String.Empty;

            MySqlConnection connection = adapter.GetConection();
            string sql = "SELECT ID FROM `flujoaereo`.`airline` WHERE Name ='" + name + "';";


            using (var command = new MySqlCommand(sql, connection))

            using (var reader = command.ExecuteReader())
                while (reader.Read())
                    readerString += reader.GetString(0);

            return int.Parse(readerString);
        }

        public List<string> GetAllAirlinesNames()
        {
            List<string> vs = new List<string>();

            MySqlConnection connection = adapter.GetConection();
            string sql = "SELECT Name FROM `flujoaereo`.`airline`;";


            using (var command = new MySqlCommand(sql, connection))

            using (var reader = command.ExecuteReader())
                while (reader.Read())
                    vs.Add(reader.GetString(0));


            return vs;
        }
    }
}
