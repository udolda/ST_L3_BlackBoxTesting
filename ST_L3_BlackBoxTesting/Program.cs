using System;

namespace ST_L3_BlackBoxTesting
{

    // y = sin((e^x-3a)/(a^2+b^2)) + 10/x^3
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, xMin, xMax, dx;

            Console.WriteLine("Hello, User!\nI can count value of function y = sin((e^x-3a)/(a^2+b^2)) + 10/x^3\n" +
                "Just enter real numbers a, b separated by space (like this 3 5,77).\n");
            Console.Write("Your numbers: ");

            args = Console.ReadLine().Split();
            double.TryParse(args[0], out a);
            double.TryParse(args[1], out b);

            Console.Write("Also enter real xMin, xMax, dx separated by space: ");
            args = Console.ReadLine().Split();
            double.TryParse(args[0], out xMin);
            double.TryParse(args[1], out xMax);
            double.TryParse(args[2], out dx);

            while (dx <= 0)
            {
                Console.WriteLine("dx must be real number which greater than zero.");
                Console.Write("Enter dx again: ");
                double.TryParse(Console.ReadLine(), out dx);
            }
            while (xMin > xMax)
            {
                Console.WriteLine("xMin must be smaller or equal than xMax.");
                Console.Write("Enter xMin and xMax again: ");
                args = Console.ReadLine().Split();
                double.TryParse(args[0], out xMin);
                double.TryParse(args[1], out xMax);
            }

            PrintSolutionsTable(xMin, xMax, dx, a, b);

            Console.ReadKey();
        }

        /// <summary>
        /// Считает значение функции y
        /// </summary>
        /// <param name="a">Параметр а</param>
        /// <param name="b">Параметр b</param>
        /// <param name="x">Переменная x</param>
        /// <returns>Число типа double, значение функции в точке x</returns>
        static double GetFunctionValue(double a, double b, double x)
        {
            double result = 0.0;

            if (a == 0 && b == 0) return double.PositiveInfinity;
            if (x == 0) return double.PositiveInfinity;

            result = Math.Sin((Math.Pow(Math.E, x) - 3 * a) / (Math.Pow(a, 2) + Math.Pow(b, 2))) + 10.0 / Math.Pow(x, 3);

            return result;
        }

        /// <summary>
        /// Печатает в консоль таблицу со значениями функции
        /// </summary>
        /// <param name="xMin">Минимальное значение на отрезке [xMin, xMax]</param>
        /// <param name="xMax">Максимальное значение на отрезке [xMin, xMax]</param>
        /// <param name="dx">Приращение аргумента</param>
        /// <param name="a">Параметр функции а</param>
        /// <param name="b">Параметр функции b</param>
        static void PrintSolutionsTable(double xMin, double xMax, double dx, double a, double b)
        {
            Console.WriteLine();

            for (double i = xMin, j = 1; i <= xMax; i += dx, j++)
            {
                if (i == xMin) Console.Write("_\t");
                Console.Write($"x{j}\t");
            }
            Console.WriteLine();
            for (double i = xMin; i <= xMax; i += dx)
            {
                if (i == xMin) Console.Write("x\t");
                Console.Write($"{i}\t");
            }
            Console.WriteLine();
            for (double i = xMin; i <= xMax; i += dx)
            {
                if (i == xMin) Console.Write("y=f(x)\t");
                Console.Write($"{GetFunctionValue(a, b, i):f2}\t");
            }

            Console.WriteLine();
        }

    }
}
