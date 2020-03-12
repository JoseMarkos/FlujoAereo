using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Logic.UI
{
    public sealed class MenuSection
    {
        private FlatPanel SidebarPanel = new FlatPanel("Sidebar");
        private int Width = 0;

        public MenuSection(int width)
        {
            SidebarPanel.Width = width;
            SidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            SidebarPanel.Padding = new System.Windows.Forms.Padding(40);
            InitializeLayout();
        }

        private void InitializeLayout()
        {
        }

        public FlatPanel GetSidebar()
        {
            return SidebarPanel;
        }
    }
}
