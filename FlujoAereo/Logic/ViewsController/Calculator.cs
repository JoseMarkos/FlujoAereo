using FlujoAereo.Enums;
using FlujoAereo.Logic.UI;
using FlujoAereo.Logic.UI.Layouts;
using FlujoAereo.Services;
using System;
using System.Windows.Forms;

namespace FlujoAereo.Logic.ViewsController
{
    public sealed class Calculator : Controller
    {
        private FlatButton button;

        public Calculator()
        {
            InitializeComponent();
        }

        protected override void InitializeComponent()
        {
            form = new SquareForm("Calculator");
            form.Height = 599;
            form.Width = 766;

            FlatPanel mainPanel = new FlatPanel("Main");
            form.Controls.Add(mainPanel);
            mainPanel.Dock = DockStyle.Fill;

            form.Controls.Add(mainPanel);
            Toolbar toolbarController = new FlujoAereo.Logic.UI.Layouts.Toolbar();
            FlatPanel toolbar = toolbarController.GetPanel("Toolbar");
            mainPanel.Controls.Add(toolbar);
            toolbar.Controls[0].Dock = DockStyle.None;
            toolbar.Controls[0].Height = 70;
            toolbarController.AlignElementsRight(toolbar.Controls[0].Controls);
            toolbar.Controls[0].Controls[1].Click += new EventHandler(SetLogout);

            FlatPanel menuWrapper = new FlatPanel("MenuWrapper");
            menuWrapper.Width = 350;
            CalculatorMenuSection calculatorMenuSection = new CalculatorMenuSection(350);
            FlatPanel menuPanel = calculatorMenuSection.GetPanel("Menu");
            form.Controls.Add(menuWrapper);
            calculatorMenuSection.SetMenuItemsWidth(menuPanel.Width);

            menuWrapper.Controls.Add(menuPanel);
            menuWrapper.Dock = DockStyle.Left;
            menuWrapper.Left = 0;
            menuPanel.Controls[0].Dock = DockStyle.Fill;

            menuPanel.Controls[0].Controls[0].Click += new EventHandler(
              (object sender, EventArgs e) =>
              {
                  calculatorMenuSection.ShowPanel(ref mainPanel, Enums.ItemMenuType.CalculatorAverageLandingTimeFlight);
                  PanelAdjustment();
              }
              );

            menuPanel.Controls[0].Controls[1].Click += new EventHandler(
                (object sender, EventArgs e) =>
                {
                    calculatorMenuSection.ShowPanel(ref mainPanel, Enums.ItemMenuType.CalculatorAverageBrakingTime);
                    PanelAdjustment();
                }
                );

            calculatorMenuSection.ShowPanel(ref mainPanel, ItemMenuType.CalculatorAverageLandingTimeFlight);
            PanelAdjustment();

            void PanelAdjustment()
            {
                mainPanel.Controls[1].Dock = DockStyle.None;
                mainPanel.Width = form.Width - menuPanel.Width;
                toolbar.Controls[0].Width = mainPanel.Width;
                mainPanel.Controls[1].Top = toolbar.Top + toolbar.Height;
                mainPanel.Controls[1].Width = mainPanel.Width;
                mainPanel.Controls[1].Height = mainPanel.Height - toolbar.Height;
            }

        }

        private void Calculate(object sender, System.EventArgs e)
        {
            FlatPanel panelName = (FlatPanel)form.Controls[1].Controls[0].Controls[2];
            FlatPanel panelPass = (FlatPanel)form.Controls[1].Controls[0].Controls[3];

            int index = panelName.Controls.IndexOfKey("Name");
            int indexPass = panelPass.Controls.IndexOfKey("Password");
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
