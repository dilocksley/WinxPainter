using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Instruments
{
    public interface IFillFigure
    {
        Point FindPointFigure(Point first, Point second);
        void FillFigure(Point e, Color fillColor);
    }
}
