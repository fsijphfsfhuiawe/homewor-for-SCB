using System;
//using System.Collections.Generic;
//using System.Text;

namespace IntArray
{
    class Program
    {
        public static int calculate(int[] s)
        {
            int maxNum = s[0];
            int minNum = s[0];
            int sum = 0;

            Console.WriteLine("The array for test is:");
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i] + "  ");

                if (maxNum <= s[i])
                {
                    maxNum = s[i];
                }
                if (minNum >= s[i])
                {
                    minNum = s[i];
                }
                sum += s[i];
            }
            Console.WriteLine(" ");
            Console.WriteLine("The max value in the array is :{0}", maxNum);
            Console.WriteLine("The min value in the array is :{0}", minNum);
            Console.WriteLine("The sum of the numbers in the array is :{0}", sum);

            return sum / s.Length;
        }
        static void Main(string[] args)
        {
            int[] s = { 1, 5, 34, 122, 98, 12, 44, 4 };
      
            Console.WriteLine("The average value is : {0}", calculate(s));
            Console.ReadKey();
        }
    }
}