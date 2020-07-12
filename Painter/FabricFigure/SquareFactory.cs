using Painter.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.FabricFigure
{
    class SquareFactory : IFigureFactory
    {
        public AFigure Create( Point first, int n, Color color)
        {
            Square square = new Square(first, color);
            return square;
        }
    }
}
