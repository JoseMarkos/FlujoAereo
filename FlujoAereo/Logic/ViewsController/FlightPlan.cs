using FlujoAereo.Logic.UI;
using FlujoAereo.Logic.UI.Layouts;
using FlujoAereo.Services;
using System;
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
           // mainPanel.BackColor = colors.BlueHover1;

           // AirplanePanelForm.BackColor = colors.Blue1;
            AirplanePanelForm.Left = 0;
            AirplanePanelForm.Dock = DockStyle.Left;
            AirplanePanelForm.Padding = new Padding(40, 0, 0, 20);


            Toolbar toolbarController = new FlujoAereo.Logic.UI.Layouts.Toolbar();
            FlatPanel toolbar = toolbarController.GetPanel("Toolbar");
            form.Controls.Add(toolbar);

            toolbar.Height = 200;
            toolbar.Height = toolbar.Controls[0].Height;
            toolbar.Controls[0].Dock = DockStyle.None;
            toolbar.Controls[0].Width = toolbar.Width;
            toolbarController.AlignElementsRight(toolbar.Controls[0].Controls);
            toolbar.Controls[0].Controls[1].Click += new EventHandler(SetLogout);

            FlatPanel menuWrapper = new FlatPanel("MenuWrapper");
            FlatPanel menu = new MenuSection(200).GetSidebar();
            menuWrapper.Controls.Add(menu);
            mainPanel.Controls.Add(menuWrapper);

            menuWrapper.Dock = DockStyle.Left;
            menuWrapper.Left = 0;
            menuWrapper.BackColor = colors.Black1;

            AirplanePanelForm.Width = mainPanel.Width - menuWrapper.Width;

            //AirplanePanelForm.Dispose();
        }

        private void SetLogout(object seter, EventArgs e)
        {
            UserDAO userDao = new UserDAO(Enums.Server.MariaDB);

            userDao.SetLogout(userDao.GetID(userDao.GetLoggedUserName()));
            form.Close();
            form.Dispose();

            Login login = new Login();
            login.GetForm().Show();
        }
    }
}
