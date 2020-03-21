using FlujoAereo.Logic.UI;
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
            dictionary.Add((int)Roles.Administrator, new Management().GetForm());
            dictionary.Add((int)Roles.Monitor, new Management().GetForm());
            dictionary.Add((int)Roles.FlightControl, new SquareForm("Other view"));
        }
    }
}
