using FlujoAereo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Models
{
    public sealed class Usuario
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public Vuelo Flight { get; set; }

        public Usuario(int role)
        {
            Role = role;

            if (role == (int)Roles.FlightPlan)
            {
                Flight = null;
            }
        }    
    }
}
