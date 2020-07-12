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
        public AFigure Create(Point first, int n, Color color)
        {
            Figures.PenFigure pencil = new Figures.PenFigure(first, color);
            return pencil;
        }
    }
}
