using FlujoAereo.Logic.UI;
using FlujoAereo.Logic.UI.Layouts;
using FlujoAereo.Services;
using System;
using System.Windows.Forms;

namespace FlujoAereo.Logic.ViewsController
{
    public sealed class Management : Controller
    {
        public Management()
        {
            InitializeComponent();
        }

        protected override void InitializeComponent()
        {
            PortraitForm portraitForm = new PortraitForm("test");
            form = portraitForm;
            form.Width = 1000;
            form.Height = 800;

            FlatPanel mainPanel = new FlatPanel("Main");
            form.Controls.Add(mainPanel);
            mainPanel.Dock = DockStyle.Fill;

            // ----

            //CreateAirplanePanel panelControl = new CreateAirplanePanel();
            //FlatPanel AirplanePanelForm = panelControl.GetPanel("AirplaneForm");
            //mainPanel.Controls.Add(AirplanePanelForm);
            // ----
           

            Toolbar toolbarController = new FlujoAereo.Logic.UI.Layouts.Toolbar();
            FlatPanel toolbar = toolbarController.GetPanel("Toolbar");
            form.Controls.Add(toolbar);

            toolbar.Controls[0].Dock = DockStyle.None;
            toolbar.Controls[0].Width = toolbar.Width;
            toolbar.Controls[0].Height = 70;
            toolbarController.AlignElementsRight(toolbar.Controls[0].Controls);
            toolbar.Controls[0].Controls[1].Click += new EventHandler(SetLogout);

            FlatPanel menuWrapper = new FlatPanel("MenuWrapper");
            MenuSection menuController = new MenuSection(200);
            FlatPanel menu = menuController.GetPanel("Menu");
            menuWrapper.Controls.Add(menu);
            menuWrapper.Dock = DockStyle.Left;
            menuWrapper.Left = 0;

            mainPanel.Controls.Add(menuWrapper);
            menuController.SetMenuItemsWidth(menuWrapper.Width);
            menuController.ShowPanel(ref mainPanel, Enums.ItemMenuType.CreateAeroline);


            mainPanel.Controls.Add(new FlatLabel("test", 0, 0) { 
                Text = mainPanel.Controls.Count.ToString(),
            });

            mainPanel.Controls[1].Width = mainPanel.Width - menuWrapper.Width;
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
