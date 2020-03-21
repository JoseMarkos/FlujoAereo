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

            string sql = "INSERT INTO `flujoaereo`.`airplane` (`Model`, `ICAO`, `IATA`, `MaximunPassengers`, `MaximunCargo`, `Code`, `Enabled`, `AirlineID`) VALUES ('" + airplane.Model + "', '" + airplane.ICAO + "', '" + airplane.IATA + "', '" + airplane.MaxPASS + "', '" + airplane.MaxCargo + "', '" + airplane.Aircraft + "', '" + airplane.Enabled + "', '" + airplane.AirlineID + "');";

            MySqlCommand insertCommnad = new MySqlCommand(sql)  
            {
                Connection = conection
            };
            insertCommnad.ExecuteNonQuery();
            insertCommnad.Connection.Close();
        }

        public List<Airplane> GetAllAirplanes()
        {
            List<Airplane> list = new List<Airplane>();

            MySqlConnection connection = adapter.GetConection();
            string sql = "SELECT * FROM `flujoaereo`.`airplane` WHERE Enabled ='1';";

            using (var command = new MySqlCommand(sql, connection))

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                   // MessageBox.Show(reader.GetInt32(0).ToString());
                    Airplane airplane = new Airplane()
                    {
                        ID = reader.GetInt32(0),
                        Model = reader.GetString(1),
                        ICAO = reader.GetString(2),
                        IATA = reader.GetString(3),
                        MaxPASS = reader.GetInt32(4),
                        MaxCargo = reader.GetInt32(5),
                        Aircraft = reader.GetString(6),
                        Enabled = reader.GetInt32(7),
                        Flights = reader.GetInt32(8),
                        Hours = reader.GetInt32(9),
                        AirlineID = reader.GetInt32(10),
                    };
                    list.Add(airplane);
                }
                return list;
            }
        }

        public List<string> GetAllNames()
        {
            List<string> vs = new List<string>();

            MySqlConnection connection = adapter.GetConection();
            string sql = "SELECT Model FROM `flujoaereo`.`airplane` WHERE Enabled = '1';";

            using (var command = new MySqlCommand(sql, connection))

            using (var reader = command.ExecuteReader())
                while (reader.Read())
                    vs.Add(reader.GetString(0));

            return vs;
        }


        public List<string> GetAllNamesFromAirline(string airlineName)
        {
            List<string> vs = new List<string>();
            AirlineDAO airlineDAO = new AirlineDAO(Server.MariaDB);


            MySqlConnection connection = adapter.GetConection();
            string sql = "SELECT Model FROM `flujoaereo`.`airplane` WHERE AirlineID = '" + airlineDAO.GetID(airlineName) + "';";

            using (var command = new MySqlCommand(sql, connection))

            using (var reader = command.ExecuteReader())
                while (reader.Read())
                    vs.Add(reader.GetString(0));

            return vs;
        }

        public int GetID(string name)
        {
            string readerString = String.Empty;

            MySqlConnection connection = adapter.GetConection();
            string sql = "SELECT ID FROM `flujoaereo`.`airplane` WHERE Model ='" + name + "';";


            using (var command = new MySqlCommand(sql, connection))

            using (var reader = command.ExecuteReader())
                while (reader.Read())
                    readerString += reader.GetString(0);

            return int.Parse(readerString);
        }
    }
}
