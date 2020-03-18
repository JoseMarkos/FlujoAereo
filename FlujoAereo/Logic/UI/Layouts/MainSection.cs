using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Logic.UI.Layouts
{
    public class MainSection
    {
        private readonly FlatPanel MainPanel = new FlatPanel("Main");

        public MainSection(int width)
        {
            MainPanel.Width = width;
            MainPanel.Dock = System.Windows.Forms.DockStyle.Right;
            MainPanel.Padding = new System.Windows.Forms.Padding(40);

            InitializeLayout();
        }

        private void InitializeLayout()
        {

        }

        public FlatPanel GetSidebar()
        {
            return MainPanel;
        }
    }
}
