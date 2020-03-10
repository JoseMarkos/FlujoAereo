using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FlujoAereo.Interfaces
{
    public interface IUserAccountAdapter
    {
        MySqlConnection GetConection();
    }
}
