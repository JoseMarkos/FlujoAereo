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
    public sealed class AirportDAO
    {
        private IDBAdapter adapter;

        public AirportDAO(Server server)
        {
            DBAdapterFactory fileFactory = new DBAdapterFactory();

            adapter = fileFactory.GetAdapter(server);
        }

        public void Save(Airport airport)
        {
            try
            {
                MySqlConnection conection = adapter.GetConection();

                string sql = "INSERT INTO `flujoaereo`.`airport` (`Name`, `Operator`, `Owner`, `ICAO`, `IATA`, `Type`, `Address`, `Serves`, `Large`, `Elevation`, `Status`) VALUES ('" + airport.Name + "', '" + airport.Operator + "', '" + airport.Owner + "', '" + airport.ICAO + "', '" + airport.IATA + "', '" + airport.Type + "', '" + airport.Address + "', '" + airport.Serves + "', '" + airport.Large + "', '" + airport.Elevation + "', '" + airport.Status + "');";

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

        public List<Airport> GetAllAirports()
        {
            List<Airport> list = new List<Airport>();

            MySqlConnection connection = adapter.GetConection();
            string sql = "SELECT * FROM `flujoaereo`.`airport` WHERE Status ='1';";

            using (var command = new MySqlCommand(sql, connection))

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Airport airport = new Airport()
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Operator = reader.GetString(2),
                        Owner = reader.GetString(3),
                        ICAO = reader.GetString(4),
                        IATA = reader.GetString(5),
                        Type = reader.GetString(6),
                        Address = reader.GetString(7),
                        Serves = reader.GetString(8),
                        Large = reader.GetInt32(9),
                        Elevation = reader.GetInt32(10),
                        Status = reader.GetInt32(11),
                    };
                    list.Add(airport);
                }
                return list;
            }
        }
    }
}
