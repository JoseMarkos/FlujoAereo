using FlujoAereo.Logic.ViewsController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Enums
{
    public sealed class Views
    {
        public Dictionary<int, Form> dictionary = new Dictionary<int, Form>();

        public void Inicialize()
        {
            Management management = new Management();
            management.InitializeComponentAsync();

            dictionary.Add((int)Roles.Administrator, management.GetForm());
            dictionary.Add((int)Roles.Monitor, management.GetForm());
            dictionary.Add((int)Roles.FlightControl, management.GetForm());
        }
    }
}
