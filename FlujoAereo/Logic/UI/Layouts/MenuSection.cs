using FlujoAereo.Enums;
using FlujoAereo.Logic.UI.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI
{
    public sealed class MenuSection : ControlParent
    {
        public MenuSection(int width)
        {
            panel.Width = width;
            panel.Dock = System.Windows.Forms.DockStyle.Left;
            //panel.Padding = new System.Windows.Forms.Padding(40);
            panel.BackColor = colors.Blue1;
            InitializeLayout();
        }

        private void InitializeLayout()
        {
            panel.Controls.Add(panelChild);
            panelChild.Dock = System.Windows.Forms.DockStyle.Fill;

            AddElement(new FlatLabel("Airplane", 10, 0));
            AddElement(new FlatButton("Create Airplane", true, System.Drawing.ContentAlignment.MiddleLeft));
            AddElement(new FlatButton("Airplanes", true, System.Drawing.ContentAlignment.MiddleLeft));

            AddElement(new FlatLabel("Airport", 10, 0));
            AddElement(new FlatButton("Crate Airport", true, System.Drawing.ContentAlignment.MiddleLeft));
            AddElement(new FlatButton("Airports", true, System.Drawing.ContentAlignment.MiddleLeft));

            AddElement(new FlatLabel("Flight Plan", 10, 0));
            AddElement(new FlatButton("Create Flightst Plan", true, System.Drawing.ContentAlignment.MiddleLeft));
            AddElement(new FlatButton("Flightst this week", true, System.Drawing.ContentAlignment.MiddleLeft));
        }

        public void SetMenuItemsWidth(int parentWidth)
        {
            foreach (Control item in panelChild.Controls)
            {
                item.Width = parentWidth;
            }
        }
    }
}
