
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
        
        protected IMathFigures math;

       
       
        public abstract List<Point> Math();
       

        public virtual Color retColor()
        {
           
            return Color.White; 
        }

        public virtual void Update(Point e) { }
       
    }
}
