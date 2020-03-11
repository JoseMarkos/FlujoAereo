using FlujoAereo.Logic.UI;
using FlujoAereo.Logic.ViewsController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Login login = new Login();

            //Application.Run(login.GetForm());
            FlightPlan clientService = new FlightPlan();
            
            Application.Run(clientService.GetForm());
        }
    }
}
