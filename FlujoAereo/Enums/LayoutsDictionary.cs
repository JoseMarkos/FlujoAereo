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
            dictionary.Add((int)ItemMenuType.CreateAirline, new CreateAirlinePanel().GetPanel("Create Airline"));
            dictionary.Add((int)ItemMenuType.CreateAirplane, new CreateAirplanePanel().GetPanel("Create Airplane"));
            dictionary.Add((int)ItemMenuType.CreateAirport, new CreateAirportPanel().GetPanel("Create Airport"));
            dictionary.Add((int)ItemMenuType.CreatePiloto, new CreatePilotPanel().GetPanel("Create Airplane"));
            dictionary.Add((int)ItemMenuType.CreatePist, new CreatePistPanel().GetPanel("Create Pist"));

            dictionary.Add((int)ItemMenuType.Airplanes, new AirplaneList().GetPanel("Airplanes"));
            dictionary.Add((int)ItemMenuType.Airlines, new AirlineList().GetPanel("Airlines"));
            dictionary.Add((int)ItemMenuType.Airports, new AirportList().GetPanel("Airports"));
            dictionary.Add((int)ItemMenuType.Pilots, new PilotList().GetPanel("Airlines"));
            dictionary.Add((int)ItemMenuType.Pists, new PistList().GetPanel("Pists"));
        }
    }
}
