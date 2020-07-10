using Painter.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.FabricFigure
{
    public interface IFabricFigure 
    {
        AFigure Create(Point first, Point second, Color color);      
    }
}
