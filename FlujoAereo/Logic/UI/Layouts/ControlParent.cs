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
        protected FlatPanel panel = new FlatPanel("_");

        protected abstract void InitializeComponent();

        public FlatPanel GetPanel(string name)
        {
            panel.Name = name;
            panel.AutoSize = true;
            panel.Dock = DockStyle.None;
            panel.DockChanged += new EventHandler(SetFillWidth);
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

                panel.Controls[index].Top = panel.Controls[index - 1].Top + panel.Controls[index - 1].Height + 50;
            }

            CheckWidth();

            void CheckWidth()
            {
                if (panel.Width < element.Width)
                {
                    panel.Width = element.Width;
                }
            }
        }

        public void CenterAllControls()
        {
            panel.Refresh();

            foreach (Control item in panel.Controls)
            {
                MessageBox.Show(item.Width + " " + panel.ClientSize.Width.ToString());
                MessageBox.Show(centerElement.Horizontal(item.Width, panel.ClientSize.Width).ToString());
                item.Left = centerElement.Horizontal(item.Width, panel.ClientSize.Width);
            }
        }

        public void SetFillWidth(object sender, System.EventArgs e)
        {
            //panel.Width = panel.Parent.Width;
        }
    }
}
