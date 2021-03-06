﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI
{
    public partial class FlatLabelError : Label
    {
        public FlatLabelError (string name, int x, int y)
        {
            AutoSize = true;
            BackColor = System.Drawing.Color.Crimson;
            Font = new System.Drawing.Font("Microsoft YaHei UI", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ForeColor = System.Drawing.Color.White;
            Location = new System.Drawing.Point(x, y);
            Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            Name = "label" + name;
            Text = name;
            Size = new System.Drawing.Size(100, 25);
            TabIndex = 7;
            Padding = new Padding(4);
        }
    }
}
