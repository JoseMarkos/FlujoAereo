using System.Windows.Forms;

namespace FlujoAereo.Logic.UI
{
    public partial class FlatComboBox : ComboBox
    {
        public FlatComboBox(string name, string text, int x, int y)
        {
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            FormattingEnabled = true;
            Location = new System.Drawing.Point(x, y);
            Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            Name = "combo" + name;
            Size = new System.Drawing.Size(314, 25);
            TabIndex = 1;
            Text = text;
        }
    }
}
