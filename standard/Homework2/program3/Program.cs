using System;
using System.Collections.Generic;


namespace Homework2 {

  class PrimeApp {
    const int N = 100;

    static void Main(string[] args) {
      bool[] primes = new bool[N+1]; 
      for (int i = 2; i < N+1; i++) {
        primes[i] = true; 
      }
      Filter(primes);
      for (int num = 2; num < N+1; num++) {
        if (primes[num]) {
          Console.Write($"\t{num}");
        }
      }
    }

    // 在数组中过滤出素数
    private static void Filter(bool[] primes) {
      if (primes == null || primes.Length == 0) return;
      for (int num = 2; num * num < primes.Length; num++) {
        if (!primes[num]) continue; //非素数的倍数不用再次过滤
        //筛掉num的num倍、num+1倍、num+2倍...
        for (int nonprime = num * num; nonprime < primes.Length; nonprime += num) {
          primes[nonprime] = false;
        }
      }
    }
  }
}
