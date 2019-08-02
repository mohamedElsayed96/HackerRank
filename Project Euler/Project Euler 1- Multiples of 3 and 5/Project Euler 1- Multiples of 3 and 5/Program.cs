using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            long a = n / 5;
            long b = n / 3;
            long c = n / 15;
            long sum = (calSum(n, a, 5) + calSum(n, b, 3)- calSum(n, c, 15))>>1;
            Console.WriteLine(sum);
            
        }
    }
    static long calSum(long n, long num, long diff)
    {
        if (n % diff != 0)
            return  num * (2 * diff + diff * (num - 1));
        else if (n % diff == 0)
        {
            num -= 1;
            return num * (2 * diff + diff * (num - 1));
        }
        else
            return 0;

    }
}

