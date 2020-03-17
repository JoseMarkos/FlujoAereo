using FlujoAereo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI.Layouts
{
    public sealed class Toolbar : ControlParent
    {
        private UserDAO userDao = new UserDAO(Enums.Server.MariaDB);

        public Toolbar()
        {
            InitializeComponent();
        }

        private new void InitializeComponent()
        {
            panel.Dock = System.Windows.Forms.DockStyle.Top;
            panel.BackColor = colors.White1;
            panel.AutoSize = true;
            panel.DockChanged += new EventHandler(SetFillWidth);

            panel.Controls.Add(panelChild);

            AddElement(new FlatLabel(userDao.GetLoggedUserName(), 0, 60));
            panel.Controls[0].Controls[0].Text = "Hi, " + panel.Controls[0].Controls[0].Text;
          
            AddElement(new FlatButton("Logout", true));
        }

        public void AlignElementsRight (Control.ControlCollection collection)
        {
            panelChild.Padding = new Padding(20);

            foreach (Control item in collection)
            {
                item.Dock = DockStyle.Right;
            }
        }
    }
}
