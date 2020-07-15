using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Painter.Figures;
using System.Drawing;

namespace Painter.FactoryOfFigures
{
    class EllipseFactory : IFigureFactory
    {
        public AFigure Create(Point first, int n, Color color, Color fillColor)
        public AFigure Create(Point first, int n, Color color, int thickness)
        {
            Ellipse ellipse = new Ellipse(first, color, thickness);
            return ellipse;
        }
    }
}
