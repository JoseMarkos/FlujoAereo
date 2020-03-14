using FlujoAereo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Models
{
    public sealed class Usuario : UserAbstract
    {
        public int Role { get; set; }
        
        public Usuario(int role)
        {
            Role = role;
        }
    }
}
