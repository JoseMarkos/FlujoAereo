using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI.Layouts
{
    public sealed class Toolbar : ControlParent
    {
        public Toolbar()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            panel.Dock = System.Windows.Forms.DockStyle.Top;
            panel.BackColor = colors.White1;
            panel.AutoSize = true;
            panel.DockChanged += new EventHandler(SetFillWidth);

            panel.Controls.Add(panelChild);

            //AddElement(new FlatLabel("label in toolbar", 0, 0));
            AddElement(new FlatButton("Logout"));
            //AddElement(new FlatLabel("label in toolbar 3", 0, 0));
        }

        public void AlignElementsRight (Control.ControlCollection collection)
        {
            panelChild.Padding = new Padding(20);

            foreach (Control item in collection)
            {
                item.Top = 20;
                item.Dock = DockStyle.Right;
            }
        }
    }
}
