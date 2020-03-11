﻿using FlujoAereo.Logic.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlujoAereo.Logic.ViewsController
{

    public sealed class FlightPlan : Controller
    {
        public FlightPlan()
        {
            InitializeComponent();
        }

        protected override void InitializeComponent()
        {
            LandscapeForm square = new LandscapeForm("Flight Plan");
            form = (Form)square;
            form.Height = 599;
            form.Width = 750;
            form.FormClosed += new FormClosedEventHandler(Exit);

            FlatPanelTexBox flat = new FlatPanelTexBox("Test");

            form.Controls.Add(flat);
        }
    }
}