﻿using FlujoAereo.Enums;
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

        public void Save(Models.Pilot pilot)
        {
            MySqlConnection conection = adapter.GetConection();

            string sql = "INSERT INTO `flujoaereo`.`pilot` (`Name`, `Sex`, `Status`, `AirlineID`) VALUES ('" + pilot.Name + "', '" + pilot.Sex + "', '" + pilot.PilotStatus + "', '" + pilot.AirlineID + "');";

            MySqlCommand insertCommnad = new MySqlCommand(sql)
            {
                Connection = conection
            };
            insertCommnad.ExecuteNonQuery();
            insertCommnad.Connection.Close();
        }

        public List<Pilot> GetAllPilots()
        {
            List<Pilot> list = new List<Pilot>();

            MySqlConnection connection = adapter.GetConection();
            string sql = "SELECT * FROM `flujoaereo`.`pilot` WHERE Status = '1';";

            using (var command = new MySqlCommand(sql, connection))

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Pilot pilot = new Pilot()
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Sex = reader.GetString(2),
                        PilotStatus = reader.GetInt32(3),
                        AirlineID = reader.GetInt32(4),
                    };
                    list.Add(pilot);
                }
                return list;
            }
        }

        public List<string> GetAllNames()
        {
            List<string> vs = new List<string>();

            MySqlConnection connection = adapter.GetConection();
            string sql = "SELECT Name FROM `flujoaereo`.`pilot` WHERE Status = '1';";


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
            string sql = "SELECT Name FROM `flujoaereo`.`pilot` WHERE AirlineID = '" + airlineDAO.GetID(airlineName) + "';";


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
            string sql = "SELECT ID FROM `flujoaereo`.`pilot` WHERE Name ='" + name + "';";


            using (var command = new MySqlCommand(sql, connection))

            using (var reader = command.ExecuteReader())
                while (reader.Read())
                    readerString += reader.GetString(0);

            return int.Parse(readerString);
        }
    }
}
