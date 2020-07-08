using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NUnitTestFigures.FiguresMocks
{
    class TriangleMocks
    {
        public List<Point> Get(int i)
        {
            switch (i)
            {
                case 1:
                    return new List<Point>()
                    {
                        new Point(1,4),
                        new Point(3,4),
                        new Point(3,6),
                    };
                default:
                    return new List<Point>();
            }
        }
    }
}
