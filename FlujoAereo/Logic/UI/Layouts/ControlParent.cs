using FlujoAereo.Enums;
using FlujoAereo.Logic.ViewsController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI.Layouts
{
    public abstract class ControlParent
    {
        protected CenterElement centerElement = new CenterElement();
        protected Colors colors = new Colors();
        protected FlatPanel panel = new FlatPanel("_")
        {
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink,
            Dock = DockStyle.None,
            MaximumSize = new System.Drawing.Size(1000, 1000),
            Padding = new Padding(50, 0, 50, 30)
        };

        protected abstract void InitializeComponent();

        public FlatPanel GetPanel()
        {
            return panel;
        }

        protected void AddElement(Control element)
        {
            panel.Controls.Add(element);

            if (panel.Controls.Count == 1 & element.GetType().ToString() != "FlujoAereo.Logic.UI.FlatTextBoxAutoFocus")
            {
                element.Top = 40;
            }

            else if (panel.Controls.Count == 2 & panel.Controls[0].GetType().ToString() == "FlujoAereo.Logic.UI.FlatTextBoxAutoFocus")
            {
                element.Top = 40;
            }

            if (panel.Controls.Count > 2)
            {
                int index = panel.Controls.IndexOf(element);

                panel.Controls[index].Top = panel.Controls[index - 1].Top + panel.Controls[index - 1].Height + 20;
            }
        }

        protected void CenterAllControls()
        {

            foreach (Control item in panel.Controls)
            {
                item.Left = centerElement.Horizontal(item.Width, panel.Width);

                MessageBox.Show(item.Width.ToString() + " " + panel.Width.ToString() + " " + centerElement.Horizontal(item.Width, panel.ClientSize.Width).ToString());
            }
        }
    }
}
