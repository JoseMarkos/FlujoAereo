using FlujoAereo.Enums;
using FlujoAereo.Logic.UI.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.ViewsController
{
    public abstract class Controller
    {
        protected CenterElement centerElement = new CenterElement();
        protected Colors colors = new Colors();
        protected static Form form = new Form();
        protected abstract void InitializeComponent();

        public Form GetForm()
        {
            return form;
        }

        protected void Exit(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
