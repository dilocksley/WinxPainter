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
                default:
                    return new List<Point>();
            }
        }
    }
}
