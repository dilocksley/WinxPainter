using NUnit.Framework;
using Painter.Figures;
using System.Collections.Generic;
using System.Drawing;
using NUnitTestFigures.FiguresMocks;

namespace NUnitTestFigures
{
    public class FigureTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [TestCase(1, 157, 113, 292, 314)]
        public void CircleGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {
            Point FirstPoint = new Point(x1, y1);
            Point SecondPoint = new Point(x2, y2);
            Circle circle = new Circle(FirstPoint, SecondPoint);


            CircleMocks circleMocks = new CircleMocks();

            List<Point> Exp = circleMocks.Get(i);
            List<Point> Act = circle.GetPoints();

            CollectionAssert.Contains(Exp, Act);
        }
        [TestCase(1, 1, 2, 5, 7)]
        public void EllipseGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {
            Point FirstPoint = new Point(x1, y1);
            Point SecondPoint = new Point(x2, y2);
            Ellipse ellipse = new Ellipse(FirstPoint, SecondPoint);


            EllipseMocks ellipseMocks = new EllipseMocks();

            List<Point> Exp = ellipseMocks.Get(i);
            List<Point> Act = ellipse.GetPoints();

            CollectionAssert.AreEqual(Exp, Act);
        }

        [TestCase(1, 1, 4, 3, 6)]
        public void IsoscelesTriangleGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {
            Point FirstPoint = new Point(x1, y1);
            Point SecondPoint = new Point(x2, y2);
            IsoscelesTriangle triangle = new IsoscelesTriangle(FirstPoint, SecondPoint);


            IsoscelesTriangleMocks isoscelesTriangleMocks = new IsoscelesTriangleMocks();

            List<Point> Exp = isoscelesTriangleMocks.Get(i);
            List<Point> Act = triangle.GetPoints();

            CollectionAssert.AreEqual(Exp, Act);
        }

        [TestCase(1, 1, 4, 3, 6)]
        public void LineGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {
            Point FirstPoint = new Point(x1, y1);
            Point SecondPoint = new Point(x2, y2);
            Line line = new Line(FirstPoint, SecondPoint);


            LineMocks lineMocks = new LineMocks();

            List<Point> Exp = lineMocks.Get(i);
            List<Point> Act = line.GetPoints();

            CollectionAssert.AreEqual(Exp, Act);
        }
        [TestCase(1, 90, 4, 1, 4, 3, 6)]
        public void NSidedPolygonMocksGetPointsTest(int i, double angle, int n, int x1, int y1, int x2, int y2)
        {
            Point FirstPoint = new Point(x1, y1);
            Point SecondPoint = new Point(x2, y2);
            NSidedPolygon nSided = new NSidedPolygon(angle, n, FirstPoint, SecondPoint);


            NSidedPolygonMocks nSidedMocks = new NSidedPolygonMocks();

            List<Point> Exp = nSidedMocks.Get(i);
            List<Point> Act = nSided.GetPoints();

            CollectionAssert.AreEqual(Exp, Act);
        }

        [TestCase(1, 1, 4, 3, 6)]
        public void RectangleGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {
            Point FirstPoint = new Point(x1, y1);
            Point SecondPoint = new Point(x2, y2);
            RectangleMath rectangle = new RectangleMath(FirstPoint, SecondPoint);


            RectangleMocks rectangleMocks = new RectangleMocks();

            List<Point> Exp = rectangleMocks.Get(i);
            List<Point> Act = rectangle.GetPoints();

            CollectionAssert.AreEqual(Exp, Act);
        }

        [TestCase(1, 1, 4, 3, 6)]
        public void RightTriangleGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {
            Point FirstPoint = new Point(x1, y1);
            Point SecondPoint = new Point(x2, y2);
            RightTriangle rightTriangle = new RightTriangle(FirstPoint, SecondPoint);


            RightTriangleMocks rightTriangleMocks = new RightTriangleMocks();

            List<Point> Exp = rightTriangleMocks.Get(i);
            List<Point> Act = rightTriangle.GetPoints();

            CollectionAssert.AreEqual(Exp, Act);
        }

        [TestCase(1, 1, 4, 3, 6)]
        public void SquareGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {
            Point FirstPoint = new Point(x1, y1);
            Point SecondPoint = new Point(x2, y2);
            Square square = new Square(FirstPoint, SecondPoint);


            SquareMocks squareMocks = new SquareMocks(); 

            List<Point> Exp = squareMocks.Get(i);
            List<Point> Act = square.GetPoints();

            CollectionAssert.AreEqual(Exp, Act);
        }
        [TestCase(1, 1, 4, 3, 6)]
        [TestCase(2, 10, 40, 300, 600)]
        public void TrapezoidGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {
            Point FirstPoint = new Point(x1, y1);
            Point SecondPoint = new Point(x2, y2);
            Trapezoid trapezoid = new Trapezoid(FirstPoint, SecondPoint);


            TrapezoidMocks trapezoidMocks = new TrapezoidMocks();

            List<Point> Exp = trapezoidMocks.Get(i);
            List<Point> Act = trapezoid.GetPoints();

            CollectionAssert.AreEqual(Exp, Act);
        }
        [TestCase(1, 1, 4, 3, 4, 3, 6)]
        public void TriangleGetPointsTest(int i, int x1, int y1, int x2, int y2, int x3, int y3)
        {
            Point FirstPoint = new Point(x1, y1);
            Point SecondPoint = new Point(x2, y2);
            Point ThirdPoint = new Point(x3, y3);
            Triangle triangle = new Triangle(FirstPoint, SecondPoint, ThirdPoint);

            TriangleMocks triangleMocks = new TriangleMocks();

            List<Point> Exp = triangleMocks.Get(i);
            List<Point> Act = triangle.GetPoints();

            CollectionAssert.AreEqual(Exp, Act);
        }
    }
}