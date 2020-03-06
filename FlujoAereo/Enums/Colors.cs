﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Enums
{
    public sealed class Colors
    {
        private readonly Color Transparent = Color.Transparent;
        private readonly Color Black = Color.Black;
        private readonly Color White = Color.White;
        private readonly Color LightGray = Color.LightGray;
        private readonly Color LighterGray = Color.FromArgb(10, 38, 38, 38);
        private readonly Color DarkGray = Color.DarkGray;
        private readonly Color Blue = Color.CadetBlue;

        public Color Transparent1 => Transparent;

        public Color Black1 => Black;

        public Color White1 => White;

        public Color LightGray1 => LightGray;

        public Color DarkGray1 => DarkGray;

        public Color Blue1 => Blue;

        public Color LighterGray1 => LighterGray;
    }
}
