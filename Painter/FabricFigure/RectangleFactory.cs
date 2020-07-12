using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Painter.Figures;
using System.Drawing;

namespace Painter.FabricFigure
{
    class RectangleFactory : IFigureFactory
    {
        public AFigure Create(Point first, int n, Color color)
        {
            Figures.Rectangle rectangle = new Figures.Rectangle(first, color);
            return rectangle;
        }
    }
}
