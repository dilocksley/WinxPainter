using Painter.Figures;
using System.Drawing;
using System.Collections.Generic;

namespace Painter.FabricFigure
{
    class TriangleFactory : IFigureFactory
    {
        List<Point> list;
        public TriangleFactory(List<Point> list)
        {
            this.list = list;
        }

        public AFigure Create(Point first, int n, Color color)
        {
            Triangle triangle = new Triangle(color, list);
            return triangle;
        }
    }

}
