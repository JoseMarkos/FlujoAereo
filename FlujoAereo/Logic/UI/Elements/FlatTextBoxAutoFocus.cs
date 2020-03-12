using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI
{
    public partial class FlatTextBoxAutoFocus : TextBox
    {
        public FlatTextBoxAutoFocus (string name)
        {
            BorderStyle = BorderStyle.None;
            Margin = new Padding(0);
            MinimumSize = new System.Drawing.Size(0, 0);
            Padding = new Padding(0);
            Name = "txt" + name;
            Height = 0;
            Width = 0;
        }
    }
}
