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

        public Views()
        {
            dictionary.Add((int)Roles.Administrator, new Form());
            dictionary.Add((int)Roles.FlightPlan, new FlightPlan().GetForm());
            dictionary.Add((int)Roles.FlightControl, new FlightPlan().GetForm());
        }
    }
}
