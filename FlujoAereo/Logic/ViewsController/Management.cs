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
            PortraitForm portraitForm = new PortraitForm("Management");
            form = portraitForm;
            form.Width = 1000;
            form.Height = 850;

            // Main panel
            FlatPanel mainPanel = new FlatPanel("Main");
            form.Controls.Add(mainPanel);
            mainPanel.Dock = DockStyle.Fill;
           

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

            menu.Controls[0].Controls[1].Click += new EventHandler(
                (object sender, EventArgs e) =>
                {
                    menuController.ShowPanel(ref mainPanel, Enums.ItemMenuType.CreateAirplae);
                    mainPanel.Controls[1].Width = mainPanel.Width - menuWrapper.Width;
                }
                );
            menu.Controls[0].Controls[2].Click += new EventHandler(
                (object sender, EventArgs e) =>
                {
                    menuController.ShowPanel(ref mainPanel, Enums.ItemMenuType.Airplanes);
                    mainPanel.Controls[1].Width = mainPanel.Width - menuWrapper.Width;
                }
                );

            menu.Controls[0].Controls[4].Click += new EventHandler(
                (object sender, EventArgs e) =>
                {
                    menuController.ShowPanel(ref mainPanel, Enums.ItemMenuType.CreateAiline);
                    mainPanel.Controls[1].Width = mainPanel.Width - menuWrapper.Width;
                }
                );

            menu.Controls[0].Controls[7].Click += new EventHandler(
                (object sender, EventArgs e) =>
                {
                    menuController.ShowPanel(ref mainPanel, Enums.ItemMenuType.CreatePiloto);
                    mainPanel.Controls[1].Width = mainPanel.Width - menuWrapper.Width;
                }
                );

            mainPanel.Controls.Add(menuWrapper);
            menuController.SetMenuItemsWidth(menuWrapper.Width);

            // Default panel
            menuController.ShowPanel(ref mainPanel, Enums.ItemMenuType.CreateAirplae);

            
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
