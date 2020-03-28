using System.Windows.Forms;

namespace FlujoAereo.Logic.UI.Layouts
{
    class CalculatorBreakingTime : ControlParent
    {
        public CalculatorBreakingTime()
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
            AddElement(new FlatPanelTextBox("altura avion"));
            AddElement(new FlatPanelTextBox("Pist Large"));
            AddElement(new FlatButton("Calculate"));
            AddElement(new FlatLabel("resultado", 0, 0));

            panelChild.Controls[7].Width = panelChild.Controls[5].Width;
            panelChild.Controls[7].Click += new System.EventHandler(Calculate);
            panelChild.Controls[8].Text = "";

        }

        private void Calculate(object sender, System.EventArgs e)
        {
            try
            {
                const int persongAverageW = 70;
                const int VFinal = 0;

                int pilots = int.Parse(panelChild.Controls[2].Controls[0].Text);
                int passengers = int.Parse(panelChild.Controls[3].Controls[0].Text);
                int mass = int.Parse(panelChild.Controls[4].Controls[0].Text);
                int vInicial = int.Parse(panelChild.Controls[5].Controls[0].Text);
                int altura = int.Parse(panelChild.Controls[6].Controls[0].Text);
                int distancia = int.Parse(panelChild.Controls[7].Controls[0].Text);

                int persons = pilots + passengers;

                int totalPersonW = persongAverageW * persons;
                int totalW = totalPersonW + mass;

                int time = distancia / (vInicial - 0);

                panelChild.Controls[panelChild.Controls.Count - 1].Text = time.ToString() + " s.";
            }
            catch (System.Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
