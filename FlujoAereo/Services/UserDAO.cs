using FlujoAereo.Enums;
using FlujoAereo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Services
{
    public sealed class UserDAO
    {
        private IUserAccountAdapter adapter;

        public UserDAO(Server server)
        {
            UserAccountAdapterFactory fileFactory = new UserAccountAdapterFactory();

            adapter = fileFactory.GetAdapter(server);
        }

        public void Save()
        {

        }
    }
}
