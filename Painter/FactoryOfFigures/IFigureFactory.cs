using Painter.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.FactoryOfFigures
{
    public interface IFigureFactory 
    {
        AFigure Create(Point first, int n, Color color);      
    }
}
