using Painter.Figures;
using System.Drawing;

namespace Painter.FactoryOfFigures
{
    class IsoscelesTriangleFactory : IFigureFactory
    {
        public AFigure Create(Point first, int n, Color color)
        {
            IsoscelesTriangle triangle = new IsoscelesTriangle(first, color);
            return triangle;
        }
       
    }
}
