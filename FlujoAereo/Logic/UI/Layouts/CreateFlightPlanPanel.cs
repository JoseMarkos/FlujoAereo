using FlujoAereo.Enums;
using FlujoAereo.Models;
using FlujoAereo.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI.Layouts
{
    public sealed class CreateFlightPlanPanel : ControlParent
    {
        public CreateFlightPlanPanel()
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

            AirlineDAO airlineDAO = new AirlineDAO(Enums.Server.MariaDB);
            List<string> airlaneNames = airlineDAO.GetAllAirlinesNames();

            ComboBox comboBox = new ComboBox
            {
                Name = "comboAirline",
                Width = 222,
                Height = 600
            };

            comboBox.Items.Add(Enums.FlightType.Comercial);
            comboBox.Items.Add(Enums.FlightType.Cargo);
            comboBox.SelectedIndex = 0;

            //ComboBox comboBox2 = new ComboBox
            //{
            //    Name = "comboFlichtClass",
            //    Width = 222,
            //    Height = 600
            //};

            //comboBox2.Items.Add(Enums.FlightClass.Economi);
            //comboBox2.Items.Add(Enums.FlightClass.EconomiPlus);
            //comboBox2.Items.Add(Enums.FlightClass.Executive);
            //comboBox2.Items.Add(Enums.FlightClass.FirstClass);
            //comboBox2.Items.Add(Enums.FlightClass.Turist);
            //comboBox2.SelectedIndex = 0;

            ComboBox comboPist = new ComboBox
            {
                Name = "comboPist",
                Width = 222,
                Height = 600
            };

            List<int> pistIDList = new PistDAO(Server.MariaDB).GetAllID();
            foreach (int item in pistIDList)
            {
                comboPist.Items.Add(item);
            }
            comboPist.SelectedIndex = 0;

            AddElement(new FlatLabel("Flight", 0, 0));
            AddElement(comboBox);
            AddElement(new FlatPanelTextBox("Origin IATA"));
            AddElement(new FlatPanelTextBox("Destiny IATA"));

            DateTimePicker dateTimeDeparture = new DateTimePicker()
            {
                Name = "dateDeparture",
                Width = 222,
            };
            DateTimePicker dateTimeArrival = new DateTimePicker()
            {
                Name = "dateArrival",
                Width = 222,
            };


            AddElement(new FlatLabel("Departure Date", 0, 0));
            AddElement(dateTimeDeparture); // validation
            AddElement(new FlatPanelTextBox("Deperture 00:00:00"));
            AddElement(new FlatLabel("Arrival Date", 0, 0));
            AddElement(dateTimeArrival); // validation
            AddElement(new FlatPanelTextBox("Arrival 00:00:00"));
            AddElement(new FlatLabel("Pist", 0, 0));
            AddElement(comboPist);

            ComboBox comboStatus = new ComboBox
            {
                Name = "comboStatus",
                Width = 222,
                Height = 600
            };

            List<string> flightStatusNames = new FlightStatusDAO(Server.MariaDB).GetAllFlightStatusNames();

            foreach (string item in flightStatusNames)
            {
                comboStatus.Items.Add(item);
            }
            comboStatus.SelectedIndex = 0;
            AddElement(comboStatus);
            AddElement(new FlatButton("Save"));

            panelChild.Controls[panelChild.Controls.IndexOfKey("btnSave")].Click += new EventHandler(Save);
            panelChild.Controls[panelChild.Controls.IndexOfKey("btnSave")].Width = panelChild.Controls[panelChild.Controls.IndexOfKey("btnSave") - 5].Width;


            // Second Column

            int secondColumntX = panelChild.Controls[2].Width + panelChild.Controls[2].Left + 100;
            int secondColumntY = panelChild.Controls[1].Top;

            FlatLabel AirlineLabel = new FlatLabel("Airline", secondColumntX, secondColumntY);
            secondColumntY += AirlineLabel.Height + 16;
            panelChild.Controls.Add(AirlineLabel);


            ComboBox comboAirline = new ComboBox
            {
                Name = "comboAirline",
                Width = 222,
                Height = 600,
                Top = secondColumntY,
                Left = panelChild.Controls[2].Width + panelChild.Controls[2].Left + 100,
                
            };


            List<string> airlineNames = new AirlineDAO(Server.MariaDB).GetAllAirlinesNames();

            foreach (string item in airlineNames)
            {
                comboAirline.Items.Add(item);
            }
            comboAirline.SelectedIndex = 0;

            panelChild.Controls.Add(comboAirline);
            secondColumntY += comboAirline.Height + 20;

            // Airplane
            FlatLabel AirplaneLabel = new FlatLabel("Airplane", secondColumntX, secondColumntY);
            secondColumntY += AirplaneLabel.Height + 16;
            panelChild.Controls.Add(AirplaneLabel);

            ComboBox comboAircraft = new ComboBox
            {
                Name = "comboAircraft",
                Width = 222,
                Height = 600,
                Top = secondColumntY,
                Left = panelChild.Controls[2].Width + panelChild.Controls[2].Left + 100,
            };

            UpdateAirlineFromAirline(comboAirline.SelectedItem.ToString(), ref comboAircraft);

            comboAircraft.SelectedIndex = 0;

            panelChild.Controls.Add(comboAircraft);
            secondColumntY += comboAircraft.Height + 20;


            // Pilot

            FlatLabel PilotLabel = new FlatLabel("Pilot", secondColumntX, secondColumntY);
            secondColumntY += PilotLabel.Height + 16;
            panelChild.Controls.Add(PilotLabel);

            ComboBox comboPilot = new ComboBox
            {
                Name = "comboPilot",
                Width = 222,
                Height = 600,
                Top = secondColumntY,
                Left = panelChild.Controls[2].Width + panelChild.Controls[2].Left + 100,
            };

            UpdatePilotFromAirline(comboAirline.SelectedItem.ToString(), ref comboPilot);

            if (comboPilot.Items.Count > 0)
            {
                comboPilot.SelectedIndex = 0;
            }

            panelChild.Controls.Add(comboPilot);
            secondColumntY += comboAircraft.Height + 20;

            comboAirline.SelectedIndexChanged += new EventHandler(UpdateAirplaneCombo);
            comboAirline.SelectedIndexChanged += new EventHandler(UpdatePilotCombo);
        }

        private void Save(object sender, System.EventArgs e)
        {
            try
            {
                ComboBox myCombo = (ComboBox)panelChild.Controls[2];
                ComboBox myCombo2 = (ComboBox)panelChild.Controls[12];
                ComboBox myCombo3 = (ComboBox)panelChild.Controls[13];
                DateTime departureDate = DateTime.Parse(panelChild.Controls[6].Text);
                DateTime arrivalDate = DateTime.Parse(panelChild.Controls[9].Text);
                TimeSpan twentyFourHour = new TimeSpan(24,0,0);
                TimeSpan departureHour = TimeSpan.Parse(panelChild.Controls[7].Controls[0].Text);
                TimeSpan arrivalHour = TimeSpan.Parse(panelChild.Controls[10].Controls[0].Text);
                TimeSpan flightHour = (departureHour > arrivalHour) ? (twentyFourHour - departureHour) + arrivalHour : arrivalHour - departureHour;

                Flight flight = new Flight
                {
                    Type = myCombo.SelectedItem.ToString(),
                    Origin = panelChild.Controls[3].Controls[0].Text,
                    Destiny = panelChild.Controls[4].Controls[0].Text,
                    DepartureDate = departureDate.ToString(),
                    DepartureHour = departureHour.ToString(),
                    ArrivalDate = arrivalDate.ToString(),
                    ArrivalHour = arrivalHour.ToString(),
                    FlightTime = flightHour.ToString(),
                    Pist = int.Parse(myCombo2.SelectedItem.ToString()),
                    FlightStatus = myCombo3.SelectedItem.ToString(),
                };

                FlightDAO dao = new FlightDAO(Enums.Server.MariaDB);
                dao.Save(flight);

                // Button is the last child
                panelChild.Controls[panelChild.Controls.Count - 1].Enabled = false;

                FlatPanel parentPanel = (FlatPanel)panel.Parent;
                Control toolbar = parentPanel.Controls[0];

                MenuSection menuController = new MenuSection(0);
                menuController.ShowPanel(ref parentPanel, Enums.ItemMenuType.Flight);

                PanelAdjustment();

                void PanelAdjustment()
                {
                    parentPanel.Controls[1].Dock = DockStyle.None;
                    toolbar.Controls[0].Width = parentPanel.Width;
                    parentPanel.Controls[1].Top = toolbar.Top + toolbar.Height;
                    parentPanel.Controls[1].Width = parentPanel.Width;
                    parentPanel.Controls[1].Height = parentPanel.Height - toolbar.Height;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void UpdateAirplaneCombo(object sender, System.EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            ComboBox combo2 = (ComboBox)panelChild.Controls[18];

            int i = combo2.Items.Count - 1;

            while (combo2.Items.Count > 0)
            {
                combo2.Items.RemoveAt(i);
                i--;
            }

            UpdateAirlineFromAirline(combo.SelectedItem.ToString(), ref combo2);
        }

        private void UpdatePilotCombo(object sender, System.EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            ComboBox combo2 = (ComboBox)panelChild.Controls[20];

            int i = combo2.Items.Count - 1;

            while (combo2.Items.Count > 0)
            {
                combo2.Items.RemoveAt(i);
                i--;
            }

            UpdatePilotFromAirline(combo.SelectedItem.ToString(), ref combo2);
        }

        private void UpdateAirlineFromAirline(string name, ref ComboBox combo)
        {
            List<string> airplaneNames = new AirplaneDAO(Server.MariaDB).GetAllNamesFromAirline(name);
 
            foreach (string item in airplaneNames)
            {
                combo.Items.Add(item);
            }

            if (combo.Items.Count > 1)
            {
                combo.SelectedIndex = 0;
            }
        }

        private void UpdatePilotFromAirline(string name, ref ComboBox combo)
        {
            List<string> pilotNames = new PilotDAO(Server.MariaDB).GetAllNamesFromAirline(name);

            foreach (string item in pilotNames)
            {
                combo.Items.Add(item);
            }

            if (combo.Items.Count > 1)
            {
                combo.SelectedIndex = 0;
            }
        }
    }
}

