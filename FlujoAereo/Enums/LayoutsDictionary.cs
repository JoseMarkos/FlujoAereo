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
            dictionary.Add((int)ItemMenuType.CreateAiline, new CreateAirlinePanel().GetPanel("Create Airline"));
            dictionary.Add((int)ItemMenuType.CreateAirplae, new CreateAirplanePanel().GetPanel("Create Airplane"));
            dictionary.Add((int)ItemMenuType.CreatePiloto, new CreatePilotPanel().GetPanel("Create Airplane"));
            dictionary.Add((int)ItemMenuType.Airplanes, new AirplanesList().GetPanel("Airplanes"));
            dictionary.Add((int)ItemMenuType.Airlines, new AirlineList().GetPanel("Airlines"));
            dictionary.Add((int)ItemMenuType.Pilots, new PilotList().GetPanel("Airlines"));
        }
    }
}
