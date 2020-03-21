using FlujoAereo.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI
{
    public partial class SquareForm : Form
    {
        private Colors colors = new Colors();

        public SquareForm(string name)
        {
            SuspendLayout();
            // 
            // Square
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            BackColor = Color.White;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(600, 600);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            HelpButton = true;
            Name = name;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = name;
            Font = new System.Drawing.Font("Microsoft YaHei UI", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ForeColor = colors.Black1;
            ShowIcon = false;

            ResumeLayout(false);
        }
    }
}
