﻿using Painter.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.FactoryOfFigures
{
    class LineFactory : IFigureFactory
    {
        public AFigure Create(Point first, int n, Color color, Color fillColor, int thickness)
        {
            Line line = new Line(first, color, thickness);
            return line;
        }
    }
}
