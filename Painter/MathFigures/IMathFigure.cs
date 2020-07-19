using Painter.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.MathFigures
{
    public interface IMathFigure 
    {
        List<Point> MathFigure(Point first, Point second, int angle);
        
    }
}
