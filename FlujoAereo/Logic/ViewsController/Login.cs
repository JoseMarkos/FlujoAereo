using FlujoAereo.Logic.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.ViewsController
{
    public sealed class Login : Controller
    {


        public Login()
        {
            SquareForm square = new SquareForm("Login");
            FlatLabel title = new FlatLabel("Aeropuerto XYZ", 0, 0);

            form = (Form)square;
            int positionX = centerElement.Center(title.Width, ref form);
            title.Location = new System.Drawing.Point(positionX, title.Location.Y);

            form.Controls.Add(title);
        }

        public Form GetForm()
        {
            return form;
        }
    }
}
