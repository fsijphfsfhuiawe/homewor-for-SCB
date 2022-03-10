using System;
using System.Collections.Generic;

namespace ShapeClass
{

    public interface Shape
    {
        double CalculateArea();
        bool IsLegal();
    }

    public class Rectangle : Shape{
        double Width { get; set; }
        double Length { get; set; }
        
        public Rectangle(double w, double l){ Width = w; Length = l;}

        public double CalculateArea()
        {
            //通过简单计算就可以获得的面积，不需要作为字段，减少冗余
            //否则需要一直保持与长宽乘积的一致性，非常不方便
            double area = Width * Length;
            return area;
        }
        public bool IsLegal()
        {
            if (Width > 0 && Length > 0) { return true; }
            else return false;
        }


    }
    public class Square : Shape {
        double Side { get; set; }

        public Square(double s) { Side = s; }

        public double CalculateArea()
        {
            double area = Side * Side;
            return area;
        }
        public bool IsLegal()
        {
            if (Side > 0) { return true; }
            else return false;
        }


    }
    public class Triangle : Shape
    {
        double Side1 { get; set; } 
        double Side2 { get; set; }
        double Side3 { get; set; }

        public Triangle(double s1, double s2, double s3) { Side1 = s1;  Side2 = s2; Side3 = s3; }

        public double CalculateArea()
        {
            //利用海伦公式求三角形面积
            double p = (Side1 + Side2 + Side3) / 2;
            double area = Math.Sqrt(p);
            return area;
        }
        public bool IsLegal()
        {
            bool b1 = (Side1 + Side2 > Side3) && (Math.Abs(Side1 - Side2) < Side3);
            bool b2 = (Side2 + Side3 > Side1) && (Math.Abs(Side2 - Side3) < Side1);
            bool b3 = (Side1 + Side3 > Side2) && (Math.Abs(Side1 - Side3) < Side2);
            if (Side1 > 0 && Side2 > 0 && Side3 > 0 && b1 && b2 && b3) { return true; }
            else return false;
        }
    }

    //创建了一个圆 的类，但是之后使用参数数量和类型会和正方形冲突，
    //没想到同时可以保留两者的方案，故注释掉了
/*    public class Circle : Shape {
        double Radius;

        public Circle(double r) { Radius = r; }

        public double CalculateArea()
        {
            double area = Math.PI * Radius * Radius;
            return area;
        }

        public bool IsLegal()
        {
            if (Radius > 0) { return true; }
            else return false;
        }


    }*/

    public class ShapeFactory
    {
        public static Shape GetShape(List<double> attributes)
        {
            switch (attributes.Count)
            {
                case 1:
                    return new Square(attributes[0]);
                case 2:
                    return new Rectangle(attributes[0], attributes[1]);
                case 3:
                    return new Triangle(attributes[0], attributes[1], attributes[2]);
                default:
                    return null;

            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            double sumArea = 0;

            for(int i = 0; i < 10; i++)
            {//产生十个形状
                List<double> dList = new List<double>();

                for (int j = 0; j < rd.Next(1, 4); j++)
                {//随机产生不同数量的参数list
                    dList.Add(10 * rd.NextDouble());
                }
                try
                {//据list产生形状，判断是否合法，合法则计算面积
                    Shape s = ShapeFactory.GetShape(dList);
                    if (s.IsLegal())
                    {
                        Console.WriteLine(s.GetType());
                        sumArea += s.CalculateArea();
                    }
                    else i--;
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("Failed...");
                }
            }

            Console.WriteLine(sumArea);
        }
    }
}
