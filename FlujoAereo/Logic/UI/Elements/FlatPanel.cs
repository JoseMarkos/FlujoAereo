using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI
{
    public partial class FlatPanel : Panel
    {
        public FlatPanel (string name)
        {
            BackColor = System.Drawing.Color.Transparent;
            Dock = System.Windows.Forms.DockStyle.Fill;
            ForeColor = System.Drawing.Color.White;
            Location = new System.Drawing.Point(0, 0);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "panel" + name;
            Padding = new System.Windows.Forms.Padding(0);
            MinimumSize = new System.Drawing.Size(0, 0);
            
        }
    }
}
