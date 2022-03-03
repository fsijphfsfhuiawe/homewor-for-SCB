using System;

namespace EratoMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100;

            bool[] sieve = new bool[n + 1];
            for (int i = 2; i < sieve.Length; i++) { sieve[i] = true; }

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (sieve[i])
                {
                    for (int j = i + i; j <= n; j += i)
                    { sieve[j] = false; }
                }
            }

            // Count it.
            int count = 0;
            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i]) { count++; }
            }

            // Generate the result.
            int[] primes = new int[count];
            int index = 0;
            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i]) { primes[index++] = i; }
            }
            for(int i = 0; i < primes.Length; i++)
            {
                Console.Write(primes[i] + "  ");
            }

        }
    }
}




//first try

/*using System;
using System.Collections.Generic;

namespace EratoMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> primeList = new List<int>();
            primeList.Add(2);
            for (int i = 2; i <= 100; i++)
            {
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        break;
                    }
                }
            }
        }

        //public static void makeList()
        {
            List<int> primeList = new List<int>();
            primeList.Add(2);
            for(int i = 2; i <= 100; i++)
            {
                for(int j = 2; j < i; j++)
                {
                    if(i % j == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}*/

