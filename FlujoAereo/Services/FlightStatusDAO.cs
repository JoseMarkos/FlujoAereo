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
    public sealed class FlightStatusDAO
    {
        private IDBAdapter adapter;

        public FlightStatusDAO(Server server)
        {
            DBAdapterFactory fileFactory = new DBAdapterFactory();

            adapter = fileFactory.GetAdapter(server);
        }

        //public void Save(Models.Flight flight)
        //{
        //    MySqlConnection conection = adapter.GetConection();

        //    string sql = "INSERT INTO `flujoaereo`.`flightStatus` (`Type`, `Origin`, `Destiny`, `Pist`, `DepartureDate`, `DepartureHour`, `ArrivalDate`, `ArrivalHour`, `FlightTime`) VALUES ('" + flight.Type + "', '" + flight.Origin + "', '" + flight.Destiny + "', '" + flight.Pist + "', '" + flight.DepartureDate + "', '" + flight.DepartureHour + "', '" + flight.ArrivalDate + "', '" + flight.ArrivalHour + "', '" + flight.FlightTime + "');";

        //    try
        //    {
        //        MySqlCommand insertCommnad = new MySqlCommand(sql)
        //        {
        //            Connection = conection
        //        };
        //        insertCommnad.ExecuteNonQuery();
        //        insertCommnad.Connection.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new InvalidOperationException(e.Message);
        //    }
        //}

        public List<Status> GetAllFlightStatus()
        {
            List<Status> list = new List<Status>();

            MySqlConnection connection = adapter.GetConection();
            string sql = "SELECT * FROM `flujoaereo`.`flightStatus`;";

            try
            {
                using (var command = new MySqlCommand(sql, connection))

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Status flightStatus = new Status()
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                        };
                        list.Add(flightStatus);
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


        public List<string> GetAllFlightStatusNames()
        {
            List<string> list = new List<string>();

            MySqlConnection connection = adapter.GetConection();
            string sql = "SELECT Name FROM `flujoaereo`.`flightStatus`;";

            try
            {
                using (var command = new MySqlCommand(sql, connection))

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(0));
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
