﻿using FlujoAereo.Logic.UI;
using FlujoAereo.Logic.ViewsController;
using FlujoAereo.Models;
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
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Login login = new Login();
            //Form form = login.GetForm();
            //Application.Run(form);

            Management management = new Management();
            await management.InitializeComponentAsync();

            Application.Run(management.GetForm());
        }
    }
}
