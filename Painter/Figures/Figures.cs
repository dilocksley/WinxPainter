using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Figures
{
    public abstract class AFigures
    {
        protected Point FirstPoint;
        protected Point SecondPoint;

        public abstract List<Point> GetPoints();

    }
}
