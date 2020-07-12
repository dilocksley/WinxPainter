﻿using Painter.Figures;
using System.Drawing;

namespace Painter.FabricFigure
{
    class RightTriangleFactory : IFigureFactory
    {
        public AFigure Create(Point first, int n, Color color)
        {
            RightTriangle rightTriangle = new RightTriangle(first, color);
            return rightTriangle;
        }

    }
    
}
