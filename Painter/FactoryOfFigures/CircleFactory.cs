using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Painter.Figures;
using System.Drawing;

namespace Painter.FactoryOfFigures
{
    class CircleFactory : IFigureFactory
    {
       
        public AFigure Create(Point first, int n, Color color, Color fillColor, int thickness)
        {
            Circle circle = new Circle(first, color, fillColor , thickness);
            return circle;
        }
    }
}
