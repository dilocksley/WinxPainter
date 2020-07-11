using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Draw
{
    public interface IDraw
    {

        void DrawFigures(List<Point> listPoint, Color color);
    }
}
