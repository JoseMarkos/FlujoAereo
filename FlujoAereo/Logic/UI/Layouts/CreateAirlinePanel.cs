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
            AddElement(new FlatPanelTextBox("Name"));
            AddElement(new FlatPanelTextBox("Country"));
            AddElement(new FlatPanelTextBox("Region"));
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
                RadioButton myRadio = (RadioButton)panelChild.Controls[6];

                Airline aerolinea = new Airline
                {
                    Code = panelChild.Controls[1].Controls[0].Text,
                    Name = panelChild.Controls[2].Controls[0].Text,
                    Country = panelChild.Controls[3].Controls[0].Text,
                    Region = panelChild.Controls[4].Controls[0].Text,
                    AirlineStatus = (myRadio.Checked) ? 1 : 0,
                };

                MessageBox.Show(aerolinea.Code);
                MessageBox.Show(aerolinea.Name);
                MessageBox.Show(aerolinea.Country);
                MessageBox.Show(aerolinea.Region);
                MessageBox.Show(aerolinea.AirlineStatus.ToString());

                AirlineDAO dao = new AirlineDAO(Enums.Server.MariaDB);
                dao.Save(aerolinea);

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
