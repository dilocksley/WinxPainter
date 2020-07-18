using Painter.Figures;
using System.Drawing;
using System.Collections.Generic;

namespace Painter.FactoryOfFigures
{
    class TriangleFactory : IFigureFactory
    {
        List<Point> list;
        public TriangleFactory(List<Point> list)
        {
            this.list = list;
        }

        public AFigure Create(Point first, int n, Color color, Color fillColor, int thickness)
        {
            Triangle triangle = new Triangle(color, list, fillColor, thickness);
            return triangle;
        }
    }

}
