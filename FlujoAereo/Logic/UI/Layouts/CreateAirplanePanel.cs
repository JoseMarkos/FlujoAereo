using FlujoAereo.Models;
using FlujoAereo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI.Layouts
{
    public sealed class CreateAirplanePanel : ControlParent
    {
        public CreateAirplanePanel()
        {
            InitializeComponent();
        }

        private new void InitializeComponent()
        {
            panel.Controls.Add(panelChild);

            panel.Dock = DockStyle.Right;
            panel.Padding = new Padding(40, 0, 0, 20);

            // Avoid textbox auto focus
            AddElement(new FlatTextBoxAutoFocus("_"));

            // Main controls
            AddElement(new FlatPanelTextBox("Model"));
            AddElement(new FlatPanelTextBox("ICAO"));
            AddElement(new FlatPanelTextBox("IATA"));
            AddElement(new FlatPanelTextBox("Maximun Passengers"));
            AddElement(new FlatPanelTextBox("Maximun Cargo"));
            AddElement(new FlatPanelTextBox("Aircraft Registration"));
            AddElement(new FlatLabel("Enabeld", 0, 0));
            AddElement(new RadioButton() 
            { 
                Name = "radioEnabledYES", 
                Text = "Yes",
                Size = new System.Drawing.Size(67, 23),
                ForeColor = colors.Black1
            });
            AddElement(new RadioButton()
            {
                Name = "radioEnabledNo",
                Text = "No",
                Size = new System.Drawing.Size(67, 23),
                ForeColor = colors.Black1
            });
            AddElement(new FlatButton("Save"));

            panelChild.Controls[panelChild.Controls.IndexOfKey("btnSave")].Click += new EventHandler(Save);
            panelChild.Controls[panelChild.Controls.IndexOfKey("btnSave")].Width = panelChild.Controls[panelChild.Controls.IndexOfKey("btnSave") - 4].Width;

        }

        private void Save(object sender, System.EventArgs e)
        {
            try
            {
                // Use trim for filelds names
                RadioButton myRadio = (RadioButton)panelChild.Controls[8];

                Airplane avion = new Airplane
                {
                    Model = (Enums.AirplaneModels)int.Parse(panelChild.Controls[1].Controls[0].Text),
                    ICAO = panelChild.Controls[2].Controls[0].Text.ToUpper(),
                    IATA = panelChild.Controls[3].Controls[0].Text,
                    MaximunPassengers = int.Parse(panelChild.Controls[4].Controls[0].Text),
                    MaximunCargo = int.Parse(panelChild.Controls[5].Controls[0].Text),
                    AircraftRegistration = panelChild.Controls[6].Controls[0].Text,
                    Enabled = (myRadio.Checked) ? 1 : 0,
                };

                AirplaneDAO dao = new AirplaneDAO(Enums.Server.MariaDB);
                dao.Save(avion);

                // Button is the last child
                panelChild.Controls[panelChild.Controls.Count - 1].Enabled = false;
            }
            catch (Exception)
            {
                throw new OperationCanceledException("Wrong filed.");
            }
        }
    }
}
