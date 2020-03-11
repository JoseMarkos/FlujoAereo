using FlujoAereo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI
{
    public partial class FlatPanelTexBox : Panel
    {
        private Colors colors = new Colors();

        public FlatPanelTexBox(string name)
        {
            AutoSize = true;
            AutoSizeMode = new AutoSizeMode();
            BackColor = colors.White1;
            Dock = System.Windows.Forms.DockStyle.None;
            ForeColor = System.Drawing.Color.White;
            Location = new System.Drawing.Point(0, 0);
            Margin = new System.Windows.Forms.Padding(0);
            MinimumSize = new System.Drawing.Size(0, 0);
            Name = "panel" + name;
            Padding = new Padding(4);
        }
    }
}
