using System;


namespace wk6
{
    public interface IShape
    {


        // missing method will be implemented by the child class
        double GetArea();
        double GetPerimeter();

    }
    public class Circle : IShape
    {
        // attr
        private double _Radius;

        //prop
        public double Radius
        {
            get { return _Radius; }
            set { _Radius = value; }
        }
        //constr
        public Circle(double radius)
        {
            _Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * _Radius * _Radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * _Radius;
        }
        public override string ToString()
        {
            return string.Format("{0} with Radius {1}\n\t- Area: {2:F4} Perimiter: {3:F4}", base.ToString(), "Circle Shape", GetArea(), GetPerimeter());
        }
    }

    public class Rectangle : IShape
    {
        // attr
        private double _Length, _Width;

        //prop
        public double Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

        public double Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        //constr
        public Rectangle(double length, double width)
        {
            _Length = length;
            _Width = width;
        }

        public double GetArea()
        {
            return _Length * _Width;
        }

        public double GetPerimeter()
        {
            return (2 * _Length) + (2 * _Width);
        }


        public override string ToString()
        {
            return string.Format("{0} with Length: {1} and Width: {2}\n\t- Area: {3:F4} Perimiter: {4:F4}", "Rectangle Shape", _Length, _Width, GetArea(), GetPerimeter());
        }
    }

    public class Triangle : IShape
    {
        // attr
        private double _A, _B, _C;

        //prop
        public double A
        {
            get { return _A; }
            set { _A = value; }
        }

        public double B
        {
            get { return _B; }
            set { _B = value; }
        }

        public double C
        {
            get { return _C; }
            set { _C = value; }
        }
        //constr
        public Triangle(double a, double b, double c)
            
        {
            _A = a;
            _B = b;
            _C = c;
        }

        public double GetArea()
        {
            double s = 0.5 + GetPerimeter();
            return Math.Sqrt(s * (s - _A) * (s - _B) * (s - _C));
        }

        public double GetPerimeter()
        {
            return _A + _B + _C;
        }


        public override string ToString()
        {
            return string.Format("{0} with Side A: {1} Side B: {2} Side C: {3}\n\t- Area: {4:F4} Perimiter: {5:F4}", "Triangle Shape", _A, _B, _C, GetArea(), GetPerimeter());
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            IShape[] someShapes = new IShape[3];
            // Dynamic Binding => object and invoke method for the data unkown until the runtime
            int Count = 0; // keep track of how many current shapes in the array
            string Selection = "";


            /*
            // static binding
            someShapes[0] = new Circle(5.0);
            someShapes[1] = new Rectangle(5.0, 6.0);
            someShapes[2] = new Triangle(5.0, 5.0, 6.0);
            */
            do
            {
                //show menu
                Console.WriteLine("Menu Seclection:\n1. Circle\n2. Rectangle\n3. Triangle\n4. Display shapes\n5. Exit Program");
                Console.Write("Enter your choice (1..5)?");
                Selection = Console.ReadLine();

                switch (Selection)
                {
                    case "1":
                        if (Count < someShapes.Length)
                        {
                            Console.Write("Enter radius for circle:");
                            double radius = double.Parse(Console.ReadLine());

                            // create ref obj store at Count
                            someShapes[Count++] = new Circle(radius);
                        }
                        else Console.WriteLine("No more room to add shape");
                        break;

                    case "2":
                        if (Count < someShapes.Length)
                        {
                            Console.Write("Enter Length of Rectangle:");
                            double length = double.Parse(Console.ReadLine());

                            Console.Write("Enter Width of Rectangle:");
                            double width = double.Parse(Console.ReadLine());

                            // create ref obj store at Count
                            someShapes[Count++] = new Rectangle(length, width);
                        }
                        else Console.WriteLine("No more room to add shape");
                        break;

                    case "3":
                        if (Count < someShapes.Length)
                        {
                            Console.Write("Enter Side A Triangle:");
                            double a = double.Parse(Console.ReadLine());

                            Console.Write("Enter Width of Rectangle:");
                            double b = double.Parse(Console.ReadLine());

                            Console.Write("Enter Width of Rectangle:");
                            double c = double.Parse(Console.ReadLine());

                            // create ref obj store at Count
                            someShapes[Count++] = new Triangle(a, b, c);
                        }
                        else Console.WriteLine("No more room to add shape");
                        break;

                    case "4":
                        if (Count == 0) Console.WriteLine("No shape in the array");
                        else
                            foreach (IShape s in someShapes)
                                if (s != null) Console.WriteLine(s);
                        break;

                    case "5": Console.WriteLine(" End of the program");
                        for (int i = 0; i < Count; i++)
                            someShapes[i] = null; // call GC to release all reference shape
                        break;
                    default: Console.WriteLine("Invalid Choice.. Try again");
                        break;
                }


            } while (Selection != "5");
            foreach (IShape s in someShapes) Console.WriteLine(s);
            // Console.WriteLine("{0,-16} area is {1:f3}", s, s.GetArea());
        }
    }
}

