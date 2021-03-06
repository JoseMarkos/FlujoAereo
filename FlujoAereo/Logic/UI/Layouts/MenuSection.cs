﻿using FlujoAereo.Enums;
using FlujoAereo.Logic.UI.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.UI
{
    public sealed class MenuSection : ControlParent
    {
        public MenuSection(int width)
        {
            panel.Width = width;
            panel.Dock = System.Windows.Forms.DockStyle.Left;
            panel.BackColor = colors.Blue1;
            InitializeLayout();
        }

        private void InitializeLayout()
        {
            panel.Controls.Add(panelChild);
            panelChild.Dock = System.Windows.Forms.DockStyle.Right;

            AddElement(new FlatButton("Airplanes", true, System.Drawing.ContentAlignment.MiddleLeft));
            AddElement(new FlatButton("Airlines", true, System.Drawing.ContentAlignment.MiddleLeft));
            AddElement(new FlatButton("Pilots", true, System.Drawing.ContentAlignment.MiddleLeft));
            AddElement(new FlatButton("Pists", true, System.Drawing.ContentAlignment.MiddleLeft));
            AddElement(new FlatButton("Airports", true, System.Drawing.ContentAlignment.MiddleLeft));
            AddElement(new FlatButton("Flightst this week", true, System.Drawing.ContentAlignment.MiddleLeft));
        }

        public void SetMenuItemsWidth(int parentWidth)
        {
            foreach (Control item in panelChild.Controls)
            {
                item.Width = parentWidth;
            }
        }

        public void ShowPanel(ref FlatPanel panel, ItemMenuType menuType)
        {
            if (panel.Controls.Count > 1)
            {
                panel.Controls.RemoveAt(1);
            }

            LayoutsDictionary layouts = new LayoutsDictionary();

            panel.Controls.Add(layouts.dictionary[(int)menuType]);
            panel.Controls[1].Left = 0;
        }
    }
}
