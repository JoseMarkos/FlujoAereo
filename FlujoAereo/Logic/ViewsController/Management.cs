using FlujoAereo.Logic.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Logic.ViewsController
{
    public sealed class Management : Controller
    {
        public Management ()
        {
            InitializeComponent();
        }


        protected override void InitializeComponent()
        {
            Menu menu = new Menu();

            FlatPanel sidebar = menu.GetSidebar();

            form.Controls.Add(sidebar);
        }
    }
}
