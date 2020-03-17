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
        public FlatButton(string name, bool small = false, System.Drawing.ContentAlignment texAlign = System.Drawing.ContentAlignment.MiddleCenter)
        {
            Name = "btn" + name;
            //FlatAppearance.BorderColor = System.Drawing.Color.White;
            FlatAppearance.BorderSize = 0;

            FlatAppearance.MouseDownBackColor = new Colors().DarkGray1;
            FlatAppearance.MouseOverBackColor = new Colors().DarkGray1;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ForeColor = System.Drawing.Color.White;
            Location = new System.Drawing.Point(0, 0);
            Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);

            TextAlign = texAlign;
            Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Size = new System.Drawing.Size(120, 63);
            
            if (small)
            {
                Font = new System.Drawing.Font("Microsoft YaHei UI", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Size = new System.Drawing.Size(120, 30);
            }
            
            Text = name;
            UseVisualStyleBackColor = true;
            BackColor = new Colors().Blue1;
           // Click += new System.EventHandler(this.btnNext_Click);
        }
    }
}
