using FlujoAereo.Enums;
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
        protected Form form = new Form();
        protected Colors colors = new Colors();

        protected abstract void InitializeComponent();

        public Form GetForm()
        {
            return form;
        }
    }
}
