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
            System.Timers.Timer timer = new System.Timers.Timer(2000)
            {
                AutoReset = true
            };
            timer.Elapsed += SetFlightStatus;

            await Task.Run(() =>
            {
                timer.Start();
            });
        }


        private void SetFlightStatus(object sender, EventArgs e)
        {
                
            // change the status once the sync works
            //flightDAO.SetStatus(1, Enums.FlightStatus.Filling);
            MessageBox.Show("dos");
        }
    }
}
