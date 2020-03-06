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
            form = (Form)square;

            FlatLabel title = new FlatLabel("Aeorpuerto XYZ", 0, 20); 
            form.Controls.Add(title);
            int positionX = centerElement.Center(title.Size.Width, ref form);
            form.Controls[0].Location = new System.Drawing.Point(positionX, title.Location.Y);

            FlatLabel name = new FlatLabel("Name", 20, 70);
            form.Controls.Add(name);

            //form.Controls[1].Location = new System.Drawing.Point(centerElement.Center(otherLabel.Size.Width, ref form), otherLabel.Location.Y);
        }

        public Form GetForm()
        {
            return form;
        }
    }
}
