using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlujoAereo.Enums;

namespace FlujoAereo.Logic.UI
{
    public partial class FlatLabelTitle : Label
    {
        public FlatLabelTitle(string name, int x, int y)
        {
            AutoSize = true;
            BackColor = Color.Transparent;
            Font = new System.Drawing.Font("Microsoft YaHei UI", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ForeColor = Color.Black;
            Location = new System.Drawing.Point(x, y);
            Margin = new Padding(0, 0, 0, 0);
            Padding = new Padding(0);
            Name = "label" + name;
            Text = name;
        }
    }
}
