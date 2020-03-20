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
            AddElement(new FlatLabel("Flight", 0, 0));

            AirlineDAO airlineDAO = new AirlineDAO(Enums.Server.MariaDB);
            List<string> airlaneNames = airlineDAO.GetAllAirlinesNames();

            ComboBox comboBox = new ComboBox
            {
                Name = "comboAirline",
                Width = 222,
                Height = 600
            };

            comboBox.Items.Add(Enums.Flight.Comercial);
            comboBox.Items.Add(Enums.Flight.Cargo);
            comboBox.SelectedIndex = 0;

            ComboBox comboBox2 = new ComboBox
            {
                Name = "comboFlichtClass",
                Width = 222,
                Height = 600
            };

            comboBox2.Items.Add(Enums.FlightClass.Economi);
            comboBox2.Items.Add(Enums.FlightClass.EconomiPlus);
            comboBox2.Items.Add(Enums.FlightClass.Executive);
            comboBox2.Items.Add(Enums.FlightClass.FirstClass);
            comboBox2.Items.Add(Enums.FlightClass.Turist);
            comboBox2.SelectedIndex = 0;

            AddElement(comboBox);
            AddElement(new FlatLabel("Class", 0, 0));
            AddElement(comboBox2);
            AddElement(new FlatPanelTextBox("Origin IATA"));
            AddElement(new FlatPanelTextBox("Destiny IATA"));
            AddElement(new FlatPanelTextBox("No. Pist")); // validation

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

            AddElement(new FlatLabel("Date Departure", 0, 0));
            AddElement(dateTimeDeparture); // validation
            AddElement(new FlatLabel("Date Arrival", 0, 0));
            AddElement(dateTimeArrival); // validation
            AddElement(new FlatButton("Save"));

            panelChild.Controls[panelChild.Controls.IndexOfKey("btnSave")].Click += new EventHandler(Save);
            panelChild.Controls[panelChild.Controls.IndexOfKey("btnSave")].Width = panelChild.Controls[panelChild.Controls.IndexOfKey("btnSave") - 5].Width;
        }

        private void Save(object sender, System.EventArgs e)
        {
            try
            {
                // Use trim for filelds names
                RadioButton myRadio = (RadioButton)panelChild.Controls[5];
                ComboBox myCombo = (ComboBox)panelChild.Controls[3];
                int airlaineID = new AirlineDAO(Enums.Server.MariaDB).GetID(myCombo.SelectedItem.ToString());

                Piloto piloto = new Piloto
                {
                    Name = panelChild.Controls[1].Controls[0].Text,
                    Sex = panelChild.Controls[2].Controls[0].Text,
                    PilotStatus = (myRadio.Checked) ? 1 : 0,
                    AirlineID = airlaineID
                };

                PilotDAO dao = new PilotDAO(Enums.Server.MariaDB);
                dao.Save(piloto);

                // Button is the last child
                panelChild.Controls[panelChild.Controls.Count - 1].Enabled = false;

                FlatPanel parentPanel = (FlatPanel)panel.Parent;
                Control toolbar = parentPanel.Controls[0];

                MenuSection menuController = new MenuSection(0);
                menuController.ShowPanel(ref parentPanel, Enums.ItemMenuType.Pilots);

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
            catch (Exception)
            {
                throw new OperationCanceledException("Wrong filed.");
            }
        }
    }
}

