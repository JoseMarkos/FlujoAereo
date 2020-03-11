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
            form.Height = 400;
            form.Width = 300;
            form.FormClosed += new FormClosedEventHandler(Exit);

            // Avoid auto textbox focus
            FlatPanelTextBox _ = new FlatPanelTextBox("_");
            form.Controls.Add(_);
            _.BackColor = colors.Transparent1;
            _.Controls[0].Height = 0;
            _.Controls[0].Width = 0;
            _.Controls[0].MinimumSize = new System.Drawing.Size(0, 0);

            // Main controls

            FlatPanelTextBox flat2 = new FlatPanelTextBox("Model");
            form.Controls.Add(flat2);
            flat2.Top = 40;

            FlatPanelTextBox flat3 = new FlatPanelTextBox("Capacity");
            form.Controls.Add(flat3);
            flat3.Top = flat2.Top + flat2.Height + 20;

            FlatButton btnSave = new FlatButton("Save");
            form.Controls.Add(btnSave);
            btnSave.Top = flat3.Top + flat3.Height + 20;
            btnSave.Click += new EventHandler(Save);
            btnSave.Width = flat3.Width;

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

                MessageBox.Show(form.Controls.Count.ToString());

                AirplaneDAO dao = new AirplaneDAO(Enums.Server.MariaDB);

                dao.Save(avion);
                form.Controls[form.Controls.Count - 1].Enabled = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
