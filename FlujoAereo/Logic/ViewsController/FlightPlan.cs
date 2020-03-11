using FlujoAereo.Logic.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.ViewsController
{
    public sealed class FlightPlan : Controller
    {
        public FlightPlan()
        {
            InitializeComponent();
        }

        protected override void InitializeComponent()
        {
            PortraitForm portrait = new PortraitForm("Flight Plan");
            form = portrait;
            form.Height = 400;
            form.Width = 300;
            form.FormClosed += new FormClosedEventHandler(Exit);

            // Avoid auto textbox focus
            FlatPanelTextBox _ = new FlatPanelTextBox("_");
            form.Controls.Add(_);
            _.BackColor = colors.Transparent1;
            _.Controls[0].Height = 0;
            _.Controls[0].Width = 0;
            _.Controls[0].MinimumSize = new System.Drawing.Size(0, 0);
            
            // Main controls

            FlatPanelTextBox flat = new FlatPanelTextBox("ID");
            form.Controls.Add(flat);
            flat.Top = 40;

            FlatPanelTextBox flat2 = new FlatPanelTextBox("Model");
            form.Controls.Add(flat2);
            flat2.Top = flat.Top + flat.Height + 20;

            FlatPanelTextBox flat3 = new FlatPanelTextBox("Pilot");
            form.Controls.Add(flat3);
            flat3.Top = flat2.Top + flat2.Height + 20;

            FlatPanelTextBox flat4 = new FlatPanelTextBox("Capacity");
            form.Controls.Add(flat4);
            flat4.Top = flat3.Top + flat3.Height + 20;

            CenterAllControls();
        }

        private void CenterAllControls()
        {
            foreach (var item in form.Controls)
            {
                if (item.GetType().ToString() == "FlujoAereo.Logic.UI.FlatPanelTextBox")
                {
                    FlatPanelTextBox ele = (FlatPanelTextBox)item;
                    int index = form.Controls.IndexOf(ele);

                    form.Controls[index].Left = centerElement.Horizontal(form.Controls[index].Width, form.ClientSize.Width);
                }
            }
        }
    }
}
