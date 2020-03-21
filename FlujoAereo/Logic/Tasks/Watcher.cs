using FlujoAereo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.Tasks
{
    class Watcher
    {
        public FlightDAO flightDAO = new FlightDAO(Enums.Server.MariaDB);

        public async Task WaitFlightTimeAsync()
        {
            MessageBox.Show("hh1");
            await Task.Delay(2000);
            MessageBox.Show("hh");
        }

        public async Task SetFlightStatus()
        {
            await WaitFlightTimeAsync();

            flightDAO.SetStatus(1, Enums.FlightStatus.Filling);
            MessageBox.Show("dos");
        }

        public void Hola(object sender, EventArgs e)
        {
            MessageBox.Show("es 0");
        }
    }
}
