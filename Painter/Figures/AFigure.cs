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

        List<Point> fig;

        IMathFigure math;

       // protected int thickness;

        public abstract List<Point> DoFigureMath();
       
        public abstract Color SetColor();

        public abstract int SetThickness();

        //public int SetThickness(int thickness)
        //{
        //    this.thickness = thickness;
        //    return thickness;
        //}

        public abstract void Update(Point e);

        public abstract bool IsPointInFigure(Point mousePoint);

        public abstract void Move(Point point);

    }

}
