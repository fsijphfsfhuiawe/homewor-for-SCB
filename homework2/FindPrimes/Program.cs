using System;

//third try: without iteration
class Program
{
    static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());
        while(num != 1)
        {
            for (int i = 2; i <= num; i++){
                if(num % i == 0)
                {
                    num = num / i;
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}


//second

/*using System;

namespace FindPrimes
{
    class Program
    {

        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            Program p = new Program();
            if (p.NewIteration(x) != 0)
            {
                Console.WriteLine(p.NewIteration(x));
            }
            else p.NewIteration(x);
        }




        //迭代：改进

        public int NewIteration(int inputNum)
        {
            int divisor = 2;
            while (inputNum != 1 && inputNum >= (divisor * divisor))
            {
                if (inputNum % divisor == 0)
                {
                    inputNum = inputNum / divisor;
                    Console.WriteLine(divisor);
                    NewIteration(inputNum);
                }
                divisor++;
                continue;
                if (inputNum % divisor == 0)
                {
                    return divisor;
                }
                else return NewIteration(inputNum);
            }*/

//first try

/*if (inputNum == 1)
    Console.WriteLine("The number doesn't have a prime more than 1.");

int divisor = 2;
while (inputNum != 1 && inputNum >= (divisor * divisor))
//出循环条件：商为1或除数大于被除数的开方
{
    if (inputNum % divisor == 0)
    {
        inputNum = inputNum / divisor;
        Console.WriteLine(divisor);
        NewIteration(inputNum);
    }
    divisor++;
    continue;
}

if (inputNum % divisor == 0)
{
    return divisor;
}
else return 0;
}
}
}
*/

/*
        //迭代：连锁法
        
        public static void IterationWay(int inputNum)
        {
            bool flag2 = false;
            bool flag3 = false;
            bool flag5 = false;
            bool flag7 = false;
            while (inputNum >= 2)
            {
                if (inputNum % 2 == 0)
                {
                    flag2 = true;
                    IterationWay(inputNum / 2);
                }
                else if (inputNum % 3 == 0)
                {
                    flag3 = true;
                    IterationWay(inputNum / 3);
                }
                else if (inputNum % 5 == 0)
                {
                    flag5 = true;
                    IterationWay(inputNum / 5);
                }
                else if (inputNum % 7 == 0)
                {
                    flag7 = true;
                    IterationWay(inputNum / 7);
                }

            }
            if (flag2 == true)
                Console.WriteLine("2");
            if (flag3 == true)
                Console.WriteLine("3");
            if (flag5 == true)
                Console.WriteLine("2");
            if (flag7 == true)
                Console.WriteLine("3");

        }








        public static void FindMyPrime(int x) {
            //2,3,5,7,11,
            bool flag2 = false;
            while ( x >= 2)
            {
                if (x % 2 == 0)
                {
                    x = x / 2;
                    flag2 = true;
                    continue;
                }

                else if(x % 3 == 0)
                {
                    if (flag2 == true)
                        Console.WriteLine("2");
                    x = x / 3;
                    Console.WriteLine("3");
                    continue;
                }
                if (x % 5 == 0)
                {
                    x = x / 5;
                    Console.WriteLine("5");
                    continue;
                }
                if (x % 7 == 0)
                {
                    x = x / 7;
                    Console.WriteLine("7");
                    continue;
                }
                if (x % 11 == 0)
                {
                    x = x / 11;
                    Console.WriteLine("11");
                    continue;
                }
            }
        }
    }
}*/
