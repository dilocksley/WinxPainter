using Painter.Figures;
using System.Drawing;


namespace Painter.FactoryOfFigures
{
    class TrapezoidFactory : IFigureFactory
    {
        public AFigure Create(Point first, int n, Color color, int thickness)
        {
            Trapezoid trapezoid = new Trapezoid(first, color, thickness);
            return trapezoid;
        }
    }
}
