using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI
{
    public partial class PortraitForm : Form
    {
        public PortraitForm(string name)
        {
            SuspendLayout();
            // 
            // Portrait
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(400, 600);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            HelpButton = true;
            Name = name;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = name;
            Padding = new Padding(0);

            ResumeLayout(false);
        }
    }
}
