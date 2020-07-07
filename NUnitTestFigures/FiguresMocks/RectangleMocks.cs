using System.Collections.Generic;
using System.Drawing;

namespace NUnitTestFigures.FiguresMocks
{
    class RectangleMocks
    {
        public List<Point> Get(int i)
        {
            switch (i)
            {
                case 1:
                    return new List<Point>()
                    {
                        new Point(1,4),
                        new Point(1,6),
                        new Point(3,6),
                        new Point(3,4),
                    };
                default:
                    return new List<Point>();
            }
        }
    }
}
