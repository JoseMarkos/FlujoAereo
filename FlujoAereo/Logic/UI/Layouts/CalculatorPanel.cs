using System.Windows.Forms;

namespace FlujoAereo.Logic.UI.Layouts
{
    class CalculatorPanel : ControlParent
    {
        public CalculatorPanel()
        {
            InitializeComponent();
        }

        private new void InitializeComponent()
        {
            panel.Controls.Add(panelChild);
            panel.Dock = DockStyle.Fill;
            panel.Padding = new Padding(40, 0, 0, 20);

            AddElement(new FlatTextBoxAutoFocus("_")); // 0
            AddElement(new FlatLabelTitle("Calculator", 0, 0));
            AddElement(new FlatPanelTextBox("Pilots number"));
            AddElement(new FlatPanelTextBox("Passengers number"));
            AddElement(new FlatPanelTextBox("Average Mass"));
            AddElement(new FlatPanelTextBox("Average Speed"));
            AddElement(new FlatButton("Calculate"));

            panelChild.Controls[6].Width = panelChild.Controls[5].Width;
        }
    }
}
