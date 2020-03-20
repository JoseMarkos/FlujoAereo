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
    public sealed class PistDAO
    {
        private IDBAdapter adapter;

        public PistDAO(Server server)
        {
            DBAdapterFactory fileFactory = new DBAdapterFactory();

            adapter = fileFactory.GetAdapter(server);
        }

        public void Save(Models.Pist pist)
        {
            MySqlConnection conection = adapter.GetConection();

            string sql = "INSERT INTO `flujoaereo`.`pist` (`Description`, `Status`) VALUES ('" + pist.Description + "', '" + pist.Status + "');";

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

        public List<Pist> GetAllPists()
        {
            List<Pist> list = new List<Pist>();

            MySqlConnection connection = adapter.GetConection();
            string sql = "SELECT * FROM `flujoaereo`.`pist`;";

            try
            {
                using (var command = new MySqlCommand(sql, connection))

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pist pist = new Pist()
                        {
                            ID = reader.GetInt32(0),
                            Description = reader.GetString(1),
                            Status = reader.GetInt32(2),
                        };
                        list.Add(pist);
                    }
                    return list;
                }
            }
            catch (Exception)
            {

                throw new InvalidCastException("Wrong data.");
            }
        }
    }
}
