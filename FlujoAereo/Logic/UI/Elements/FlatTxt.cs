using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI
{
    public partial class FlatTxt : TextBox
    {
        public FlatTxt (string name, int x, int y)
        {
            BackColor = System.Drawing.Color.White;
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Location = new System.Drawing.Point(47, 284);
            Margin = new System.Windows.Forms.Padding(0);
            MinimumSize = new System.Drawing.Size(x, y);
            Name = "txt" + name;
            Size = new System.Drawing.Size(314, 21);
            TabIndex = 1;
            //KeyUp += new System.Windows.Forms.KeyEventHandler( my_method );
        }
    }
}
