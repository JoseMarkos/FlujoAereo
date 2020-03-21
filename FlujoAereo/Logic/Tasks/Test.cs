using FlujoAereo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.Tasks
{
    class Test
    {
        public FlightDAO flightDAO = new FlightDAO(Enums.Server.MariaDB);

        public async Task Hola(Control hey)
        {
            await (Task.Run (() => {

            }));

            hey.Refresh();
        }

        public async Task hoo(Control hey)
        {

            await (Task.Run(() => MessageBox.Show("Hola")));

            flightDAO.SetStatus(0, Enums.FlightStatus.Arrived);
            hey.Refresh();
        }

        public async Task CountHour(TimeSpan time)
        {
            //System.Timers.Timer timer = new System.Timers.Timer(1);
            //timer.AutoReset = false;
            //timer.Elapsed += new System.Timers.ElapsedEventHandler(Humm);
            //int num = int.Parse(time.ToString());
            int num = 0;
            //MessageBox.Show(num.ToString());

            //flightDAO.SetStatus(0, Enums.FlightStatus.Arrived);
        }

        public void Humm()
        {
            MessageBox.Show("wow");
        }
    }
}
