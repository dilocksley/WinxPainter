using Painter.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.FactoryOfFigures
{
    class SquareFactory : IFigureFactory
    {
        public AFigure Create( Point first, int n, Color color, Color fillColor, int thickness)
        {
            Square square = new Square(first, color, fillColor, thickness);
            return square;
        }
    }
}
