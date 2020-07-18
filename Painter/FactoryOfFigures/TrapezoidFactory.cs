using Painter.Figures;
using System.Drawing;


namespace Painter.FactoryOfFigures
{
    class TrapezoidFactory : IFigureFactory
    {
        public AFigure Create(Point first, int n, Color color, Color fillColor, int thickness)
        {
            Trapezoid trapezoid = new Trapezoid(first, color, fillColor, thickness);
            return trapezoid;
        }
    }
}
