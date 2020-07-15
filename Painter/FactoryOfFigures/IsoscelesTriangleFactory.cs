using Painter.Figures;
using System.Drawing;

namespace Painter.FactoryOfFigures
{
    class IsoscelesTriangleFactory : IFigureFactory
    {
        public AFigure Create(Point first, int n, Color color, int thickness)
        public AFigure Create(Point first, int n, Color color, Color fillColor)
        {
            IsoscelesTriangle triangle = new IsoscelesTriangle(first, color, thickness);
            return triangle;
        }
       
    }
}
