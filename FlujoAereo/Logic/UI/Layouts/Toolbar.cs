using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Logic.UI.Layouts
{
    public sealed class Toolbar : ControlParent
    {
        public Toolbar()
        {
            InitializeComponent();
        }

        protected override void InitializeComponent()
        {
            panel.Dock = System.Windows.Forms.DockStyle.Top;

            AddElement(new FlatLabel("label in toolbar", 0, 0));
        }
    }
}
