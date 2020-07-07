using System.Collections.Generic;
using System.Drawing;

namespace NUnitTestFigures.FiguresMocks
{
    class IsoscelesTriangleMocks
    {
        public List<Point> Get(int a)
        {
            switch (a)
            {
                case 1:
                    return new List<Point>()
                    {
                        new Point(1,4),
                        new Point(-1,6),
                        new Point(3,6),
                    };
                default:
                    return new List<Point>();
            }
        }
    }
}
