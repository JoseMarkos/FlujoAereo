﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlujoAereo.Enums;

namespace FlujoAereo.Logic.UI
{
    public partial class FlatLabel : Label
    {
        public FlatLabel(string name, int x, int y)
        {
            AutoSize = true;
            BackColor = new Colors().Transparent;
            Font = new System.Drawing.Font("Microsoft YaHei UI", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ForeColor = new Colors().Black;
            Location = new System.Drawing.Point(x, y);
            Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            Name = "label" + name;
            Text = name;
            Size = new System.Drawing.Size(100, 25);
            TabIndex = 7;
        }
    }
}
