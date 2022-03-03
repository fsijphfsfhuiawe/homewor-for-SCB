﻿using System;

namespace Matrix
{
    class Program
    {
        static void Main()
        {
            int[,] matrix = null;

            matrix = new int[,] {
                { 1, 2, 3, 4},
                { 5, 1, 2, 3},
                { 9, 5, 1, 2}
            };

            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i, j] != matrix[i - 1, j - 1])
                    {
                        Console.WriteLine("False");
                    }
                }
            }
            Console.WriteLine("True");
        }
        
    }
}
