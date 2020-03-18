using FlujoAereo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI
{
    public partial class FlatPanelTextBox : Panel
    {
        private readonly Colors colors = new Colors();
        private readonly FlatTextBox flatTextBox;

        public FlatPanelTextBox(string name)
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = colors.White1;
            Dock = System.Windows.Forms.DockStyle.None;
            ForeColor = System.Drawing.Color.White;
            Location = new System.Drawing.Point(0, 0);
            Margin = new System.Windows.Forms.Padding(0);
            MinimumSize = new System.Drawing.Size(0, 0);
            Name = "panel" + name;
            Padding = new Padding(4);

            flatTextBox = new FlatTextBox(name, 4, 4);
            this.Controls.Add(flatTextBox);
        }
    }
}
