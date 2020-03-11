using FlujoAereo.Logic.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.ViewsController
{

    public sealed class FlightPlan : Controller
    {
        public FlightPlan()
        {
            InitializeComponent();
        }

        protected override void InitializeComponent()
        {
            PortraitForm square = new PortraitForm("Flight Plan");
            form = (Form)square;
            form.FormClosed += new FormClosedEventHandler(Exit);

            FlatPanelTexBox flat = new FlatPanelTexBox("Test");

            form.Controls.Add(flat);
        }
    }
}
