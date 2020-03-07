using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI
{
    public partial class FlatTextBox : TextBox
    {
        public FlatTextBox (string name, int x, int y)
        {
            BackColor = System.Drawing.Color.White;
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Location = new System.Drawing.Point(x, y);
            Margin = new System.Windows.Forms.Padding(0);
            MinimumSize = new System.Drawing.Size(0, 21);
            Name = "txt" + name;
            Size = new System.Drawing.Size(214, 21);
            //TextChanged += new System.EventHandler(this.txtPlateNumber_TextChanged);
        }
    }
}
