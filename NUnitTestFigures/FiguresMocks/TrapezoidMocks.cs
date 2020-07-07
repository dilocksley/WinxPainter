using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NUnitTestFigures.FiguresMocks
{
    class TrapezoidMocks
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
                        new Point(2,6),
                        new Point(3,4),
                    };
                case 2:
                    return new List<Point>()
                    {
                        new Point(10,40),
                        new Point(82,600),
                        new Point(227,600),
                        new Point(300,40),
                    };
                default:
                    return new List<Point>();
            }
        }
    }
}
