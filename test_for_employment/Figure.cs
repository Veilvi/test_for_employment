using System;
using System.Collections.Generic;
using System.Linq;

namespace test_for_employment
{
    public abstract class FigureArea
    {
        protected (double x, double y) Center;
        protected List<(double x, double y)> Vertices= new List<(double x, double y)>();
        public abstract double GetFigureArea();
        public abstract void ToCenter();
    }

    public class Circle : FigureArea
    {
        public Circle((double, double) center, (double, double) radius)
        {
            Center = center;
            Vertices.Add(radius);
        }

        public override double GetFigureArea()
        {
           var rad=Math.Sqrt(Math.Pow(Vertices.First().y - Center.y, 2) + Math.Pow(Vertices.First().x - Center.x, 2));
           return  Math.PI * Math.Pow(rad, 2);
        }

        public override void ToCenter()
        {
            var valueTuple = Vertices.First();
            valueTuple.x = +Center.x;
            valueTuple.y = +Center.y;
            Vertices[0] = valueTuple;
            Center = (0, 0);
        }
    }

    public class Triangle : FigureArea
    {
        public Triangle((double, double) center, List<(double, double)> vertices)
        {
            Center = center;
            for (int i = 0; i < 3; i++)
            {
                Vertices.Add(vertices[i]);
            }
        }
        public override double GetFigureArea()
        {
            double sum=0;
            for (var i = 0; i < Vertices.Count-1; i++)
            {
                sum += Vertices[i].x * Vertices[i + 1].y - Vertices[i].y * Vertices[i + 1].x;
            }
            sum += Vertices[Vertices.Count-1].x * Vertices[0].y - Vertices[Vertices.Count-1].y * Vertices[0].x;
            return Math.Abs(sum)/2 ;
        }

        public override void ToCenter()
        {
            for (var i = 0; i < Vertices.Count-1; i++)
            {
                var valueTuple = Vertices[i];
                valueTuple.x = +Center.x;
                valueTuple.y = +Center.y;
                Vertices[i] = valueTuple;
                Center = (0, 0);
            }
        }

        public bool TriangleIsIsosceles()
        {
            var sideOneLength = (decimal) Math.Sqrt(Math.Pow(Vertices[1].x-Vertices[0].x,2)+Math.Pow(Vertices[1].y-Vertices[0].y,2));
            var sideTwoLength = (decimal) Math.Sqrt(Math.Pow(Vertices[2].x-Vertices[1].x,2)+Math.Pow(Vertices[2].y-Vertices[1].y,2));
            var sideThreeLength = (decimal) Math.Sqrt(Math.Pow(Vertices[0].x-Vertices[2].x,2)+Math.Pow(Vertices[0].y-Vertices[2].y,2));
            return (sideOneLength==sideTwoLength || sideOneLength==sideThreeLength)
                   ||(sideTwoLength==sideOneLength || sideTwoLength==sideThreeLength)
                   ||(sideThreeLength==sideOneLength || sideThreeLength==sideTwoLength);
        }

        public bool IsTriangleRight()
        {
            var sideOneLength = (decimal) Math.Sqrt(Math.Pow(Vertices[1].x-Vertices[0].x,2)+Math.Pow(Vertices[1].y-Vertices[0].y,2));
            var sideTwoLength = (decimal) Math.Sqrt(Math.Pow(Vertices[2].x-Vertices[1].x,2)+Math.Pow(Vertices[2].y-Vertices[1].y,2));
            var sideThreeLength = (decimal) Math.Sqrt(Math.Pow(Vertices[0].x-Vertices[2].x,2)+Math.Pow(Vertices[0].y-Vertices[2].y,2));
            return (sideOneLength == sideTwoLength && sideOneLength == sideThreeLength);
        } 
    }

    public class Polygon:FigureArea
    {
        public Polygon((double x, double y) center, List<(double x, double y)> vertices)
        {
            Center = center;
            foreach (var v in vertices)
            {
                Vertices.Add(v);
            }
        }
        public override double GetFigureArea()
        {
            double sum=0;
            for (var i = 0; i < Vertices.Count-1; i++)
            {
                sum += Vertices[i].x * Vertices[i + 1].y - Vertices[i].y * Vertices[i + 1].x;
            }
            sum += Vertices[Vertices.Count-1].x * Vertices[0].y - Vertices[Vertices.Count-1].y * Vertices[0].x;
            return Math.Abs(sum)/2 ;
        }

        public override void ToCenter()
        {
            for (var i = 0; i < Vertices.Count-1; i++)
            {
                var valueTuple = Vertices[i];
                valueTuple.x = +Center.x;
                valueTuple.y = +Center.y;
                Vertices[i] = valueTuple;
                Center = (0,0);
                
            }
        }
    }

}