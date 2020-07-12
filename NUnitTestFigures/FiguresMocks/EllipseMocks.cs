using System.Collections.Generic;
using System.Drawing;


namespace NUnitTestFigures.FiguresMocks
{
    class EllipseMocks
    {
        public List<Point> Get(int a)
        {
            switch (a)
            {
                case 1:
                    return new List<Point>()
                    {
                        new Point(1,4),
                        new Point(2,6),
                        new Point(3,6),
                        new Point(4,6),
                        new Point(5,4),
                        new Point(5,4),
                        new Point(4,2),
                        new Point(3,2),
                        new Point(2,2),
                        new Point(1,4),

                    };
                case 2:
                    return new List<Point>()
                    {
                        new Point(0,0),

                    };
                case 3:
                    return new List<Point>()
                    {
                        new Point(0,0),

                    };
                default:
                    return new List<Point>();
            }
        }
    }
}
