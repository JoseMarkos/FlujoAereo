using FlujoAereo.Enums;
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
        private Colors colors = new Colors();

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
            Font = new System.Drawing.Font("Microsoft YaHei UI", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ForeColor = colors.Black1;

            ResumeLayout(false);
        }
    }
}
