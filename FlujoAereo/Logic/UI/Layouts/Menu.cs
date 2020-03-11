using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Logic.UI
{
    public sealed class Menu
    {
        private FlatPanel sidebar = new FlatPanel("Sidebar");

        public Menu()
        {
            InitializeLayout();
        }

        private void InitializeLayout()
        {
            sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            sidebar.Padding = new System.Windows.Forms.Padding(20);
        }

        public FlatPanel GetSidebar()
        {
            return sidebar;
        }
    }
}
