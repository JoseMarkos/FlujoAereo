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
        protected FlatPanel panelChild = new FlatPanel("__");

        protected void InitializeComponent()
        {
            panel.AutoSize = true;
            panel.Dock = DockStyle.None;
            panel.DockChanged += new EventHandler(SetFillWidth);

            panel.Controls.Add(panelChild);
        }

        public FlatPanel GetPanel(string name)
        {
            return panel;
        }

        protected void AddElement(Control element)
        {
            panelChild.Controls.Add(element);

            if (panelChild.Controls.Count == 1 & element.GetType().ToString() != "FlujoAereo.Logic.UI.FlatTextBoxAutoFocus")
            {
                element.Top = 40;
            }

            else if (panelChild.Controls.Count == 2 & panelChild.Controls[0].GetType().ToString() == "FlujoAereo.Logic.UI.FlatTextBoxAutoFocus")
            {
                element.Top = 40;
            }

            if (panelChild.Controls.Count > 2)
            {
                int index = panelChild.Controls.IndexOf(element);

                panelChild.Controls[index].Top = panelChild.Controls[index - 1].Top + panelChild.Controls[index - 1].Height + 50;
            }

            CheckWidth();

            void CheckWidth()
            {
                if (panelChild.Width < element.Width)
                {
                    panelChild.Width = element.Width;
                }
            }
        }

        public void SetFillWidth(object sender, System.EventArgs e)
        {
            //panel.Width = panel.Parent.Width;
        }
    }
}
