using System;
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
        private readonly Color LightGray = Color.FromArgb(170, 179, 170);
        private readonly Color LighterGray = Color.FromArgb(239, 239, 239);
        private readonly Color DarkGray = Color.FromArgb(69, 80, 86);
        private readonly Color Blue = Color.CadetBlue;
        private readonly Color BlueHover = Color.CornflowerBlue;

        public Color Transparent1 => Transparent;

        public Color Black1 => Black;

        public Color White1 => White;

        public Color LightGray1 => LightGray;

        public Color DarkGray1 => DarkGray;

        public Color Blue1 => Blue;

        public Color LighterGray1 => LighterGray;

        public Color BlueHover1 => BlueHover;
    }
}
