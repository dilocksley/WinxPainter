using System.Collections.Generic;
using System.Drawing;

namespace NUnitTestFigures.FiguresMocks
{
    class LineMocks
    {
        public List<Point> Get(int a)
        {
            switch (a)
            {
                case 1:
                    return new List<Point>()
                    {
                        new Point(1,4),
                        new Point(3,6),
                    };
                case 2:
                    return new List<Point>()
                    {
                        new Point(0, 0),
                        new Point(0, 0),
                    };
                case 3:
                    return new List<Point>()
                    {
                        new Point(-6, -9),
                        new Point(10, 15),
                    };
                default:
                    return new List<Point>();
            }
        }
    }
}
