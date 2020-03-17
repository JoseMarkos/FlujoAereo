using FlujoAereo.Logic.UI;
using FlujoAereo.Logic.UI.Layouts;
using FlujoAereo.Logic.ViewsController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Enums
{
    public sealed class LayoutsDictionary
    {
        public Dictionary<int, FlatPanel> dictionary = new Dictionary<int, FlatPanel>();

        public LayoutsDictionary()
        {
            dictionary.Add((int)ItemMenuType.CreateAvion, new CreateAirplanePanel().GetPanel("Create Airplane"));
            dictionary.Add((int)ItemMenuType.CreateAvion, new CreateAirplanePanel().GetPanel("Create Airplane"));
        }
    }
}
