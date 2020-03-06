using FlujoAereo.Logic.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.ViewsController
{
    public sealed class CenterElement
    {
       public int Center(int elementWidth, ref Form form)
        {
            int formWidth = form.Width;

            return ((formWidth - elementWidth) / 2) - (elementWidth / 2);
        }
    }
}
