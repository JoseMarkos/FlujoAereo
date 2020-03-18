using FlujoAereo.Enums;
using FlujoAereo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Services
{
    class DBAdapterFactory
    {
        public IDBAdapter GetAdapter(Server type)
        {
            return type switch
            {
                Server.MariaDB => (new MariaDBAdapter()),
                _ => (new MariaDBAdapter())
            };
        }
    }
}
