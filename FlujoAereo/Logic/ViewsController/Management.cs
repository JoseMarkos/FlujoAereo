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
            form.Width = 1410;
            form.Height = 900;
            form.Padding = new Padding(20);
            form.BackColor = colors.White1;

            // Main panel
            FlatPanel mainPanel = new FlatPanel("Main");
            form.Controls.Add(mainPanel);
            mainPanel.Dock = DockStyle.Fill;


            Toolbar toolbarController = new FlujoAereo.Logic.UI.Layouts.Toolbar();
            FlatPanel toolbar = toolbarController.GetPanel("Toolbar");
            mainPanel.Controls.Add(toolbar);
            toolbar.Controls[0].Dock = DockStyle.None;
            toolbar.Controls[0].Height = 70;
            toolbarController.AlignElementsRight(toolbar.Controls[0].Controls);
            toolbar.Controls[0].Controls[1].Click += new EventHandler(SetLogout);

            FlatPanel menuWrapper = new FlatPanel("MenuWrapper");
            MenuSection menuController = new MenuSection(200);
            FlatPanel menu = menuController.GetPanel("Menu");
            menuWrapper.Controls.Add(menu);
            menuWrapper.Dock = DockStyle.Left;
            menuWrapper.Left = 0;

            
            menu.Controls[0].Controls[0].Click += new EventHandler(
                (object sender, EventArgs e) =>
                {
                    menuController.ShowPanel(ref mainPanel, Enums.ItemMenuType.Airplanes);
                    PanelAdjustment();
                }
                );

            menu.Controls[0].Controls[1].Click += new EventHandler(
                (object sender, EventArgs e) =>
                {
                    menuController.ShowPanel(ref mainPanel, Enums.ItemMenuType.Airlines);
                    PanelAdjustment();
                }
                );

            menu.Controls[0].Controls[2].Click += new EventHandler(
                (object sender, EventArgs e) =>
                {
                    menuController.ShowPanel(ref mainPanel, Enums.ItemMenuType.Pilots);
                    PanelAdjustment();
                }
                );

            menu.Controls[0].Controls[3].Click += new EventHandler(
                (object sender, EventArgs e) =>
                {
                    menuController.ShowPanel(ref mainPanel, Enums.ItemMenuType.Pists);
                    PanelAdjustment();
                }
                );

            menu.Controls[0].Controls[4].Click += new EventHandler(
                (object sender, EventArgs e) =>
                {
                    menuController.ShowPanel(ref mainPanel, Enums.ItemMenuType.Airports);
                    PanelAdjustment();
                }
                );

            menu.Controls[0].Controls[5].Click += new EventHandler(
                (object sender, EventArgs e) =>
                {
                    menuController.ShowPanel(ref mainPanel, Enums.ItemMenuType.Flight);
                    PanelAdjustment();
                }
                );

            form.Controls.Add(menuWrapper);
            menuController.SetMenuItemsWidth(menuWrapper.Width);

            // Default panel
            menuController.ShowPanel(ref mainPanel, Enums.ItemMenuType.CreateFlightPlan);
            PanelAdjustment();

            //TimeSpan timeSpan = new TimeSpan(0, 2, 0,0);
            //TimeSpan timeSpan2 = TimeSpan.Parse("20:00");
            //MessageBox.Show(timeSpan2.ToString());

            void PanelAdjustment()
            {
                mainPanel.Controls[1].Dock = DockStyle.None;
                mainPanel.Width = form.Width - menu.Width;
                toolbar.Controls[0].Width = mainPanel.Width;
                mainPanel.Controls[1].Top = toolbar.Top + toolbar.Height;
                mainPanel.Controls[1].Width = mainPanel.Width;
                mainPanel.Controls[1].Height = mainPanel.Height - toolbar.Height;
            }
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
