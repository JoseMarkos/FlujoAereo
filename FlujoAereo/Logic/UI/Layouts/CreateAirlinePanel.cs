﻿using FlujoAereo.Models;
using FlujoAereo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI.Layouts
{
    public sealed class CreateAirlinePanel : ControlParent
    {
        public CreateAirlinePanel()
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
            AddElement(new FlatPanelTextBox("Code"));
            AddElement(new FlatPanelTextBox("ICAO"));
            AddElement(new FlatPanelTextBox("IATA"));
            AddElement(new FlatPanelTextBox("Name"));
            AddElement(new FlatPanelTextBox("Logo"));
            AddElement(new FlatPanelTextBox("Country"));
            AddElement(new FlatButton("Save"));

            panelChild.Controls[panelChild.Controls.IndexOfKey("btnSave")].Click += new EventHandler(Save);
            panelChild.Controls[panelChild.Controls.IndexOfKey("btnSave")].Width = panelChild.Controls[panelChild.Controls.IndexOfKey("btnSave") - 1].Width;

        }

        private void Save(object sender, System.EventArgs e)
        {
            try
            {

                MessageBox.Show(panel.Controls[0].Controls[1].Controls[0].Text);

                Aerolinea aerolinea = new Aerolinea
                {
                    Code = panel.Controls[0].Controls[1].Controls[0].Text,
                };

                //AirplaneDAO dao = new AirplaneDAO(Enums.Server.MariaDB);
                //dao.Save(avion);

                // Button is the last child
                panel.Controls[panel.Controls.Count - 1].Enabled = false;
            }
            catch (Exception)
            {
                throw new OperationCanceledException("Wrong filed.");
            }
        }
    }
}
