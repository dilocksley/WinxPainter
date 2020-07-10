using Painter.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.FabricFigure
{
    class FactoringSquare : IFabricFigure
    {
        public AFigure Create( Point first,Point second,  Color color)
        {
            Square square = new Square(first,second, color);
            return square;
        }
    }
}
