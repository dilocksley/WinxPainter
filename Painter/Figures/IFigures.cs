using Painter.Draw;
using Painter.MathFigures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Figures
{
    public abstract class IFigures
    {
        List<Point> fig;

        IMathFigures math;
        IDraw draw;
        
        public List<Point> Math(Point first, Point second)
        {
          return math.MathFigure(first, second);          
           
        }

        public  void Draw(List<Point> listPoint, Color color)
        {
            draw.DrawFigures(listPoint, color);
        }
    }
}
