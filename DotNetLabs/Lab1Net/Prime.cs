using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1Net
{
    public static class Prime
    {
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        public static int GetBiggestSmallerPrimeNumber(int number)
        {
            if (number<=2)
            {
                return 0;
            }
            while (true)
            {
                number--;
                if (IsPrime(number))
                {
                    return number;
                }
            }
            
        }

        public static int GetBiggestSmallerPrimeNumberLazy(int number)
        {
            var primesList= new List<int>();
            for (int i = 2; i < number; i++)
            {
                if (IsPrime(i))
                {
                    primesList.Add(i);
                }
            }

            return primesList.Last();
        }
    }
}
