using FlujoAereo.Enums;
using FlujoAereo.Logic.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
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

            FlatPanel flatPanel = new FlatPanel("main")
            {
                Dock = System.Windows.Forms.DockStyle.None,
                BackColor = colors.LighterGray1,
            };

            form.Controls.Add(flatPanel);

            int faltPanelPositionY = centerElement.Vertical(flatPanel.Size.Height, form.ClientSize.Height);
            int faltPanelPositionX = centerElement.Horizontal(flatPanel.Size.Width, form.ClientSize.Width);

            flatPanel.Location = new System.Drawing.Point(faltPanelPositionX, faltPanelPositionY);

            FlatLabelTitle title = new FlatLabelTitle("Aeorpuerto XYZ", 0, 20);
            flatPanel.Controls.Add(title);
            int positionX = centerElement.Horizontal(title.Size.Width, flatPanel.ClientSize.Width);
            title.Location = new System.Drawing.Point(positionX, title.Location.Y);

            FlatLabel name = new FlatLabel("Name", 20, 70);
            flatPanel.Controls.Add(name);
        }

        public Form GetForm()
        {
            return form;
        }
    }
}
