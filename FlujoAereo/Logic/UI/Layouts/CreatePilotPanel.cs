using FlujoAereo.Enums;
using FlujoAereo.Models;
using FlujoAereo.Services;
using System;
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
                RadioButton myRadio = (RadioButton)panelChild.Controls[4];

                Piloto piloto = new Piloto
                {
                    Name = panelChild.Controls[1].Controls[0].Text,
                    Sex = (Gender)int.Parse(panelChild.Controls[2].Controls[0].Text),
                    PilotStatus = (myRadio.Checked) ? 1 : 0,
                };

                PilotDAO dao = new PilotDAO(Enums.Server.MariaDB);
                dao.Save(piloto);

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

