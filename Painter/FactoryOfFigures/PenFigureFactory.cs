using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Painter.Figures;
using System.Drawing;


namespace Painter.FactoryOfFigures
{
    class PenFigureFactory : IFigureFactory
    {
        //List<Point> list;
        //public PenFigureFactory(List<Point> list)
        //{
        //    this.list = list;
        //}
        public AFigure Create(Point first, int n, Color color)
        {
            PenFigure pencil = new PenFigure(first, color);
            return pencil;
        }
    }
}
