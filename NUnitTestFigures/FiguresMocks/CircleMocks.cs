using System.Collections.Generic;
using System.Drawing;

namespace NUnitTestFigures.FiguresMocks
{
    class CircleMocks
    {
        public List<Point> Get(int i)
        {
            switch (i)
            {
                case 1:
                    return new List<Point>()
                    {
                        new Point(358,215),
                        new Point(358,216),
                    };
                case 2:
                    return new List<Point>()
                    {
                        new Point(0, 0),
                    };
                default:
                    return new List<Point>();
            }
        }
    }
}
