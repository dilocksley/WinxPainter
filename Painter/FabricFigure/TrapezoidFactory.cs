using Painter.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.FabricFigure
{
    class TrapezoidFactory : IFigureFactory
    {
        public AFigure Create(Point first, int n, Color color)
        {
            Trapezoid trapezoid = new Trapezoid(first, color);
            return trapezoid;
        }
    }
}
