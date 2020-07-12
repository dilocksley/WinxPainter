using System.Collections.Generic;
using System.Drawing;

namespace NUnitTestFigures.FiguresMocks
{
    class NSidedPolygonMocks
    {
        public List<Point> Get(int a)
        {
            switch (a)
            {
                case 1:
                    return new List<Point>()
                    {
                        new Point(3,4),
                        new Point(1,2),
                        new Point(-1,4),
                        new Point(1,6),
                    };
                case 2:
                    return new List<Point>()
                    {
                        new Point(3, 4),
                        new Point(2, 3),
                        new Point(1, 2),
                        new Point(0, 3),
                        new Point(-1, 4),
                        new Point(0, 5),
                        new Point(1, 6),
                        new Point(2, 5),
                    };
                case 3:
                    return new List<Point>()
                    {
                        new Point(3, 4),
                        new Point(0, 2),
                        new Point(0, 6),
                    };
                default:
                    return new List<Point>();
            }
        }
    }
}
