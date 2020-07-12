using Painter.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.FabricFigure
{
    class LineFactory : IFigureFactory
    {
        public AFigure Create(Point first, int n, Color color)
        {
            Line line = new Line(first, color);
            return line;
        }
    }
}
