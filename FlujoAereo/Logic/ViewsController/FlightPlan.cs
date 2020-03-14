using FlujoAereo.Logic.UI;
using FlujoAereo.Logic.UI.Layouts;
using FlujoAereo.Models;
using FlujoAereo.Services;
using System;
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
            PortraitForm portraitForm = new PortraitForm("test");
            form = portraitForm;
            form.Width = 1000;
           
            FlatPanel panel = new AirplanePanel().GetPanel("Hola");
            form.Controls.Add(panel);

            form.Controls[0].Left = centerElement.Horizontal(form.Controls[0].Width, form.ClientSize.Width);
        }
    }
}
