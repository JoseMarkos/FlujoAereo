using FlujoAereo.Logic.UI;
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
            PortraitForm portrait = new PortraitForm("Flight Plan");
            form = portrait;
            form.Width = 300;
            form.FormClosed += new FormClosedEventHandler(Exit);

            // Avoid textbox auto focus
            AddElement(new FlatTextBoxAutoFocus("_"));

            // Main controls

            AddElement(new FlatPanelTextBox("Model"));
            AddElement(new FlatPanelTextBox("Capacity"));
            AddElement(new FlatPanelTextBox("ICAO"));
            AddElement(new FlatPanelTextBox("IATA"));
            AddElement(new FlatButton("Save"));

            form.Controls[form.Controls.IndexOfKey("btnSave")].Click += new EventHandler(Save);
            form.Controls[form.Controls.IndexOfKey("btnSave")].Width = form.Controls[form.Controls.IndexOfKey("btnSave") - 1].Width;

            CenterAllControls();
        }

        private void CenterAllControls()
        {
            foreach (Control item in form.Controls)
            {
                int index = form.Controls.IndexOf(item);
                form.Controls[index].Left = centerElement.Horizontal(form.Controls[index].Width, form.ClientSize.Width);
            }
        }

        private void Save(object sender, System.EventArgs e)
        {
            try
            {
                Avion avion = new Avion();
                avion.Model = (Enums.Airplane)int.Parse(form.Controls[1].Controls[0].Text);
                avion.Capacity = int.Parse(form.Controls[2].Controls[0].Text);
                avion.ICAO = form.Controls[3].Controls[0].Text.ToUpper();
                avion.IATA = form.Controls[4].Controls[0].Text.ToUpper();

                AirplaneDAO dao = new AirplaneDAO(Enums.Server.MariaDB);
                    
                dao.Save(avion);
                form.Controls[form.Controls.Count - 1].Enabled = false;
            }
            catch (Exception)
            {
                throw new OperationCanceledException("Wrong field.");
            }
        }
    }
}
