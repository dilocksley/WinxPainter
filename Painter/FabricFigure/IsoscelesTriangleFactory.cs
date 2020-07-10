using Painter.Figures;
using System.Drawing;

namespace Painter.FabricFigure
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
