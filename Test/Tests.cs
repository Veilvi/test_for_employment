using System;
using System.Collections.Generic;
using test_for_employment;
using Xunit;

namespace Test
{
    public class Tests
    {
      /*  [Fact]
        public void Test1()
        {
            var circle = new Circle((0, 0), (3, 0));
            Assert.Equal((decimal)28.2743338823081, (decimal)circle.GetFigureArea());
           
        }
        */
        public static IEnumerable<object[]> CircleTestData() {
            yield return new object[] { (0.0,0.0), (0.0,3.0), 28.2743338823081};
            yield return new object[] { (0.0,0.0), (0.0,4.0), 50.2654824574367};
            yield return new object[] { (0.0,0.0), (0.0,5.0), 78.5398163397448};
            yield return new object[] { (0.0,0.0), (0.0,6.0), 113.097335529233};
            yield return new object[] { (0.0,0.0), (0.0,7.0), 153.938040025900};
            yield return new object[] { (0.0,0.0), (0.0,8.0), 201.061929829747};
            yield return new object[] { (0.0,0.0), (0.0,9.0), 254.469004940773};
            yield return new object[] { (0.0,0.0), (0.0,10.0),314.159265358979};
        }

        public static IEnumerable<object> TriangleTestData()
        {
            yield return new object[] { (0.0,0.0), new List<(double, double)>{(1,1),(-2,4),(-2,-2)}, 9};
            yield return new object[] { (0.0,0.0), new List<(double, double)>{(0,0),(-1,-4),(5,5)}, 7.5};
            yield return new object[] { (0.0,0.0), new List<(double, double)>{(2,5),(-3,2),(-10,-10)}, 19.5};
            yield return new object[] { (0.0,0.0), new List<(double, double)>{(-1,-1),(-10,-6),(-8,-8)}, 14};
        }

        public static IEnumerable<object> IsTriangleRightTestData()
        {
            yield return new object[] { (0.0,0.0), new List<(double, double)>{(1,1),(3,1),(1,5)}, false};
        }

        public static IEnumerable<object> PolygonTestData()
        {
            yield return new object[] { (0.0,0.0), new List<(double, double)>{(1,1),(-2,4),(-2,-2),(2,2)}, 9};
            yield return new object[] { (0.0,0.0), new List<(double, double)>{(1,1),(-2,4),(-2,-2),(2,2),(5,5)}, 9};
            yield return new object[] { (0.0,0.0), new List<(double, double)>{(1,1),(-2,4),(-2,-2),(-1,-1),(3,3),(-3,2),(6,6)}, 1.5};
        }
        
        [Theory]
        [MemberData(nameof(CircleTestData))]
      
        public void CircleTheory((double, double) center, (double, double) radius, double expected)
        {
            var circle = new Circle(center, radius);
            Assert.Equal((decimal)expected, (decimal)circle.GetFigureArea());
        }

        [Theory]
        [MemberData(nameof(TriangleTestData))]
        public void TriangleTheory((double, double) center, List<(double, double)> vertices, double expected)
        {
            var triangle= new Triangle(center,vertices);
            Assert.Equal((decimal)expected, (decimal)triangle.GetFigureArea());
        }

        [Theory]
        [MemberData(nameof(IsTriangleRightTestData))]
        public void IsTriangleRightTheory((double, double) center, List<(double, double)> vertices, bool expected)
        {
            var triangle= new Triangle(center,vertices);
            Assert.Equal(expected, triangle.IsTriangleRight());
        }
        
        [Theory]
        [MemberData(nameof(PolygonTestData))]
        public void PolygonTheory((double, double) center, List<(double, double)> vertices, double expected)
        {
            var polygon= new Polygon(center,vertices);
            Assert.Equal((decimal)expected, (decimal)polygon.GetFigureArea());
        }
    }
}