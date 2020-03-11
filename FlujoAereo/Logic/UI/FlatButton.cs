using FlujoAereo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI
{
    public partial class FlatButton : Button
    {
        public FlatButton(string name)
        {
            Name = "btn" + name;
            //FlatAppearance.BorderColor = System.Drawing.Color.White;
            FlatAppearance.BorderSize = 0;

            FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ForeColor = System.Drawing.Color.White;
            Location = new System.Drawing.Point(240, 16);
            Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            Size = new System.Drawing.Size(120, 63);
            TabIndex = 2;
            Text = "Next";
            UseVisualStyleBackColor = true;
            BackColor = new Colors().Blue1;
           // Click += new System.EventHandler(this.btnNext_Click);
        }

        public void ClickOnce()
        {
            this.Dispose();
        }
    }
}
