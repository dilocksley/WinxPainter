using Painter.Figures;
using System.Drawing;

namespace Painter.FactoryOfFigures
{
    class RightTriangleFactory : IFigureFactory
    {
        public AFigure Create(Point first, int n, Color color, Color fillColor, int thickness)
        {
            RightTriangle rightTriangle = new RightTriangle(first, color, thickness);
            return rightTriangle;
        }

    }
    
}
