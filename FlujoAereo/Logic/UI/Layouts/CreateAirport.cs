using FlujoAereo.Enums;
using FlujoAereo.Models;
using FlujoAereo.Services;
using System;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI.Layouts
{
    public sealed class CreateAirportPanel : ControlParent
    {
        public CreateAirportPanel()
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
            AddElement(new FlatPanelTextBox("Name"));
            AddElement(new FlatPanelTextBox("Operator"));
            AddElement(new FlatPanelTextBox("Owner"));
            AddElement(new FlatPanelTextBox("ICAO"));
            AddElement(new FlatPanelTextBox("IATA"));
            AddElement(new FlatPanelTextBox("Airport Type"));
            AddElement(new FlatPanelTextBox("Address"));
            AddElement(new FlatPanelTextBox("Serves"));
            AddElement(new FlatPanelTextBox("Meters Large"));
            AddElement(new FlatPanelTextBox("Meters Elevation"));
            AddElement(new FlatLabel("Available", 0, 0));
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
                RadioButton myRadio = (RadioButton)panelChild.Controls[12];

                Airport airport = new Airport
                {
                    Name = panelChild.Controls[1].Controls[0].Text,
                    Operator = panelChild.Controls[2].Controls[0].Text,
                    Owner = panelChild.Controls[3].Controls[0].Text,
                    ICAO = panelChild.Controls[4].Controls[0].Text,
                    IATA = panelChild.Controls[5].Controls[0].Text,
                    Type = panelChild.Controls[6].Controls[0].Text,
                    Address = panelChild.Controls[7].Controls[0].Text,
                    Serves = panelChild.Controls[8].Controls[0].Text,
                    Large = int.Parse(panelChild.Controls[9].Controls[0].Text),
                    Elevation = int.Parse(panelChild.Controls[10].Controls[0].Text),
                    Status = (myRadio.Checked) ? 1 : 0,
                };


                AirportDAO dao = new AirportDAO(Server.MariaDB);
                dao.Save(airport);

                // Button is the last child
                panelChild.Controls[panelChild.Controls.Count - 1].Enabled = false;

                FlatPanel parentPanel = (FlatPanel)panel.Parent;
                Control toolbar = parentPanel.Controls[0];

                MenuSection menuController = new MenuSection(0);
                menuController.ShowPanel(Enums.ItemMenuType.Airports);

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

