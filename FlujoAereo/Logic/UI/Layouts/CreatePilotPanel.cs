using FlujoAereo.Enums;
using FlujoAereo.Models;
using FlujoAereo.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI.Layouts
{
    public sealed class CreatePilotPanel : ControlParent
    {
        public CreatePilotPanel()
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
            AddElement(new FlatPanelTextBox("Full Name"));
            AddElement(new FlatPanelTextBox("Sexo"));
            AirlineDAO airlineDAO = new AirlineDAO(Enums.Server.MariaDB);
            List<string> airlaneNames = airlineDAO.GetAllAirlinesNames();


            ComboBox comboBox = new ComboBox
            {

                Name = "comboAirline",
                Width = panelChild.Controls[1].Width,
            };

            foreach (string item in airlaneNames)
            {
                comboBox.Items.Add(item);
            }

            AddElement(comboBox);
            AddElement(new FlatLabel("Active", 0, 0));
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

