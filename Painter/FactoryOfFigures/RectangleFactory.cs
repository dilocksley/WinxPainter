using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Painter.Figures;
using System.Drawing;

namespace Painter.FactoryOfFigures
{
    class RectangleFactory : IFigureFactory
    {
        public AFigure Create(Point first, int n, Color color, Color fillColor)
        public AFigure Create(Point first, int n, Color color, int thickness)
        {
            Figures.Rectangle rectangle = new Figures.Rectangle(first, color, thickness);
            return rectangle;
        }
    }
}
