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
    public sealed class AirplanesList : ControlParent
    {
        public AirplanesList()
        {
            InitializeComponent();
        }


        private new void InitializeComponent()
        {
            panel.Controls.Add(panelChild);

            panel.Dock = DockStyle.Right;
            panel.Padding = new Padding(40, 0, 0, 20);

            // DAO

            AirplaneDAO airplaneDAO = new AirplaneDAO(Enums.Server.MariaDB);

            // Avoid textbox auto focus
            AddElement(new FlatTextBoxAutoFocus("_"));

            BindingSource bindingSource = new BindingSource
            {
                DataSource = airplaneDAO.GetAirplanesIDs()
            };

            // main controls
            AddElement(new DataGridView
            {
                Name = "dgvairplanes",
                DataSource = bindingSource,
                Width = 700,
                ForeColor = colors.Black1
            });

            AddElement(new FlatButton("Save tmp"));

            //panelChild.Controls[panelChild.Controls.IndexOfKey("btnSave")].Click += new EventHandler(Save);
            //panelChild.Controls[panelChild.Controls.IndexOfKey("btnSave")].Width = panelChild.Controls[panelChild.Controls.IndexOfKey("btnSave") - 4].Width;
        }

        private void Save(object sender, System.EventArgs e)
        {
            try
            {
                //RadioButton myRadio = (RadioButton)panelChild.Controls[6];

                //Airline aerolinea = new Airline
                //{
                //    Code = panelChild.Controls[1].Controls[0].Text,
                //    Name = panelChild.Controls[2].Controls[0].Text,
                //    Country = panelChild.Controls[3].Controls[0].Text,
                //    Region = panelChild.Controls[4].Controls[0].Text,
                //    AirlineStatus = (myRadio.Checked) ? 1 : 0,
                //};

                //AirlineDAO dao = new AirlineDAO(Enums.Server.MariaDB);
                //dao.Save(aerolinea);

                // Button is the last child
               // panelChild.Controls[panelChild.Controls.Count - 1].Enabled = false;
            }
            catch (Exception)
            {
                throw new OperationCanceledException("Wrong filed.");
            }
        }
    }
}
