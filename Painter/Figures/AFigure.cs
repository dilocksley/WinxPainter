using Painter.MathFigures;
using Painter.Instruments;
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

        protected IMathFigure math;
        public IFillFigure fillFigure;

        public abstract Point FindPoint();
        public abstract void FillFigure();
        public abstract List<Point> DoFigureMath();
       
        public abstract Color SetColor();

        public abstract int SetThickness();

        //public int SetThickness(int thickness)
        //{
        //    this.thickness = thickness;
        //    return thickness;
        //}

        public abstract void Update(Point e);
        public abstract Color FillSetColor();

        public abstract bool IsPointInFigure(Point mousePoint);

        
        public abstract void Move(Point point);

    }

}
