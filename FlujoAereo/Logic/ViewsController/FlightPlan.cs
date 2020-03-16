using FlujoAereo.Logic.UI;
using FlujoAereo.Logic.UI.Layouts;
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
            PortraitForm portraitForm = new PortraitForm("test");
            form = portraitForm;
            form.Width = 1000;

            FlatPanel mainPanel = new FlatPanel("Main");
            form.Controls.Add(mainPanel);
            mainPanel.Dock = DockStyle.Fill;

            AirplanePanel panelControl = new AirplanePanel();
            FlatPanel AirplanePanelForm = panelControl.GetPanel("AirplaneForm");
            mainPanel.Controls.Add(AirplanePanelForm);
            //mainPanel.Padding = new Padding(30);
            //mainPanel.BackColor = colors.Blue1;

            //AirplanePanelForm.BackColor = colors.Black1;

            AirplanePanelForm.MaximumSize = new System.Drawing.Size(1000, 1000);
            AirplanePanelForm.Dock = DockStyle.Top;

           // panelControl.CenterAllControls();

            FlatPanel toolbar = new FlujoAereo.Logic.UI.Layouts.Toolbar().GetPanel("Toolbar");
            form.Controls.Add(toolbar);

            //toolbar.BackColor = colors.LightGray1;
            toolbar.Dock = DockStyle.Top;

            FlatPanel menu = new MenuSection(200).GetSidebar();
            form.Controls.Add(menu);
            //menu.BackColor = colors.Black1;

            //MessageBox.Show(mainPanel.Width.ToString() + " main panel");
            //MessageBox.Show(menu.Width.ToString() + " Sidebar panel");

        }
    }
}
