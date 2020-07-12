using Painter.MathFigures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Figures
{
    public abstract class AFigure
    {

        List<Point> fig;

        IMathFigure math;


        public abstract List<Point> Math();
       
        public abstract Color SetColor();
      
        public abstract void Update(Point e);
       
    }
}
