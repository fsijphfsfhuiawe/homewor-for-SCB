using System;

namespace ConsoleAppCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Please inpute the first number you want to calculate,");
            Console.WriteLine("and then the operator ( +, -, *, or /),");
            Console.WriteLine("and then the second number.");
            double n1 = double.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            double n2 = double.Parse(Console.ReadLine());
            p.Calculate(n1, n2, s);

        }

        public void Calculate(double num1, double num2, string operators)
        {
            double anws;
            switch (operators)
            {
                case "+":
                    anws = num1 + num2;
                    Console.WriteLine("The anws is {0}", anws);
                    break;
                case "-":
                    anws = num1 - num2;
                    Console.WriteLine("The anws is {0}", anws);
                    break;
                case "*":
                    anws = num1 * num2;
                    Console.WriteLine("The anws is {0}",anws);
                    break;
                case "/":
                    if(num2 == 0)
                    {
                        Console.WriteLine("Wrong Input: " +
                            "The divisor can't be 0");
                        break;
                    }
                    else
                    {
                        anws = num1 / num2;
                        Console.WriteLine("The anws is {0}", anws);
                        break;
                    }
                default:
                    Console.WriteLine("Please input the right " +
                        "operator in elementary arithmetic.");
                    break;
            }

        }
    }
}
