using FlujoAereo.Logic.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.ViewsController
{
    public sealed class ClientService : Controller
    {
        public ClientService()
        {
            InitializeComponent();
        }

        protected override void InitializeComponent()
        {
            LandscapeForm square = new LandscapeForm("Client Service");
            form = (Form)square;
            form.Height = 599;
            form.Width = 750;
        }
    }
}
