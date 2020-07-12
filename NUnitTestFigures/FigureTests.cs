
using NUnit.Framework;
using Painter.Figures;
using System.Collections.Generic;
using System.Drawing;
using NUnitTestFigures.FiguresMocks;
using System.Runtime.ExceptionServices;

namespace NUnitTestFigures
{
    public class FigureTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [TestCase(1, 157, 113, 292, 314)]
        [TestCase(2, 0, 0, 0, 0)]
        public void CircleGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {
            Point first = new Point(x1, y1);
            Point second = new Point(x2, y2);

            Circle circle = new Circle(first, Color.Black);
            circle.Update(second);

            CircleMocks circleMocks = new CircleMocks();

            List<Point> Exp = circleMocks.Get(i);
            List<Point> Act = circle.Math();
            foreach (Point p in Exp)
            {
                Assert.IsTrue(Act.Contains(p));
            }
        }
        [TestCase(1, 1, 2, 5, 7)]
        [TestCase(2, 0, 0, 0, 0)]
        [TestCase(3, -1, -500, 0, 0)]
       
        public void EllipseGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {
            Point first = new Point(x1, y1);
            Point second = new Point(x2, y2);
            Ellipse ellipse = new Ellipse(first, Color.Black);
            ellipse.Update(second);


            EllipseMocks ellipseMocks = new EllipseMocks();

            List<Point> Exp = ellipseMocks.Get(i);
            List<Point> Act = ellipse.Math();

            CollectionAssert.AreEqual(Exp, Act);
        }

        [TestCase(1, 1, 4, 3, 6)]
        [TestCase(2, 0, 0, 0, 0)]
        [TestCase(3, -3, 1, 3, 1)]
        public void IsoscelesTriangleGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {
            Point first = new Point(x1, y1);
            Point second = new Point(x2, y2);

            IsoscelesTriangle triangle = new IsoscelesTriangle(first, Color.Black);
            triangle.Update(second);

            IsoscelesTriangleMocks isoscelesTriangleMocks = new IsoscelesTriangleMocks();

            List<Point> Exp = isoscelesTriangleMocks.Get(i);
            List<Point> Act = triangle.Math();

            CollectionAssert.AreEqual(Exp, Act);
        }

        [TestCase(1, 1, 4, 3, 6)]
        [TestCase(2, 0, 0, 0, 0)]
        [TestCase(3, -6, -9, 10, 15)]
        public void LineGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {
            Point first = new Point(x1, y1);
            Point second = new Point(x2, y2);
            Line line = new Line(first, Color.Black);
            line.Update(second);


            LineMocks lineMocks = new LineMocks();

            List<Point> Exp = lineMocks.Get(i);
            List<Point> Act = line.Math();

            CollectionAssert.AreEqual(Exp, Act);
        }
        [TestCase(1, 90, 4, 1, 4, 3, 6)]
        [TestCase(2, 45, 8, 1, 4, 3, 6)]
        [TestCase(3, 60, 3, 1, 4, 3, 6)]
        public void NSidedPolygonGetPointsTest(int i, double angle, int n, int x1, int y1, int x2, int y2)
        {
            Point first = new Point(x1, y1);
            Point second = new Point(x2, y2);
            NSidedPolygon nSided = new NSidedPolygon(first, n, Color.Black);
            nSided.Update(second);


            NSidedPolygonMocks nSidedMocks = new NSidedPolygonMocks();

            List<Point> Exp = nSidedMocks.Get(i);
            List<Point> Act = nSided.Math();

            CollectionAssert.AreEqual(Exp, Act);
        }

        [TestCase(1, 1, 4, 3, 6)]
        public void RectangleGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {
            Point first = new Point(x1, y1);
            Point second = new Point(x2, y2);
            Painter.Figures.Rectangle rectangle = new Painter.Figures.Rectangle(first, Color.Black);
            rectangle.Update(second);


            RectangleMocks rectangleMocks = new RectangleMocks();

            List<Point> Exp = rectangleMocks.Get(i);
            List<Point> Act = rectangle.Math();

            CollectionAssert.AreEqual(Exp, Act);
        }
    }
}