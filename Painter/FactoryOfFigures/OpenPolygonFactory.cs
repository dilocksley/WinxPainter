using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Painter.Figures;
using System.Drawing;

namespace Painter.FactoryOfFigures
{
    class OpenPolygonFactory : IFigureFactory
    {
        List<Point> list;
        public OpenPolygonFactory(List<Point> list)
        {
            this.list = list;
        }
        public AFigure Create(Point first, int n, Color color)
        {
            OpenPolygon pencil = new OpenPolygon(first, color);
            return pencil;
        }
    }
}
