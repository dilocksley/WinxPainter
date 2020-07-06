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
        protected Point first;
        protected Point second;

        public abstract List<Point> GetPoints();

    }
}
