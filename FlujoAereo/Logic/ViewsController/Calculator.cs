using FlujoAereo.Enums;
using FlujoAereo.Logic.UI;
using FlujoAereo.Logic.UI.Layouts;
using FlujoAereo.Models;
using FlujoAereo.Services;
using System.Drawing;
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
            form.Width = 750;


            FlatPanel panelMain = new FlatPanel("main")
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowOnly,
                Dock = System.Windows.Forms.DockStyle.None,
                BackColor = colors.White1,
                Padding = new Padding(1),
                Top = 90,
                Width = form.Width - 200,
                Height =  form.Height - 200,
            };

            panelMain.Left = centerElement.Horizontal(panelMain.Width, form.Width);
            form.Controls.Add(panelMain);

            CalculatorPanel calculatorPanel = new CalculatorPanel();
            FlatPanel flatPanel = calculatorPanel.GetPanel("Calculator");
            flatPanel.AutoSizeMode = AutoSizeMode.GrowOnly;

            panelMain.Controls.Add(flatPanel);

        }

        private void Calculate(object sender, System.EventArgs e)
        {
            FlatPanel panelName = (FlatPanel)form.Controls[1].Controls[0].Controls[2];
            FlatPanel panelPass = (FlatPanel)form.Controls[1].Controls[0].Controls[3];

            int index = panelName.Controls.IndexOfKey("Name");
            int indexPass = panelPass.Controls.IndexOfKey("Password");
        }
    }
}
