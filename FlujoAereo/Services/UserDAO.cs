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
    public sealed class UserDAO
    {
        private IUserAccountAdapter adapter;

        public UserDAO(Server server)
        {
            DBAdapterFactory fileFactory = new DBAdapterFactory();

            adapter = fileFactory.GetAdapter(server);
        }

        public void Save(Usuario user)
        {
            MySqlConnection conection = adapter.GetConection();

            string sql = "INSERT INTO `flujoaereo`.`users` (`ID`, `Name`, `Password`, `Role`) VALUES ('5', 'JorgeAdmin', 'Change', 'Administrator');";

            MySqlCommand insertCommnad = new MySqlCommand(sql);

            insertCommnad.Connection = conection;
            insertCommnad.ExecuteNonQuery();
            insertCommnad.Connection.Close();
        }

        public string GetPassword(string name)
        {
            string readerString = String.Empty;

            MySqlConnection connection = adapter.GetConection();
            string sql = "SELECT Password FROM `flujoaereo`.`users` WHERE Name ='" + name + "';";


            using (var command = new MySqlCommand(sql, connection))

            using (var reader = command.ExecuteReader())
                while (reader.Read())
                    readerString += reader.GetString(0);

            return readerString;
        }

        public int GetRole(string role)
        {
            string readerString = String.Empty;

            MySqlConnection connection = adapter.GetConection();
            string sql = "SELECT Role FROM `flujoaereo`.`users` WHERE Name ='" + role + "';";


            using (var command = new MySqlCommand(sql, connection))

            using (var reader = command.ExecuteReader())
                while (reader.Read())
                    readerString += reader.GetString(0);

            return int.Parse(readerString);
        }
    }
}
