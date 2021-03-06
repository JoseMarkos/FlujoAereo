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
            BackColor = new Colors().Transparent1;
            Font = new System.Drawing.Font("Microsoft YaHei UI", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ForeColor = new Colors().Black1;
            Location = new System.Drawing.Point(x, y);
            Margin = new Padding(0, 0, 0, 0);
            Padding = new Padding(0);
            Name = "label" + name;
            Text = name;
            
        }
    }
}
