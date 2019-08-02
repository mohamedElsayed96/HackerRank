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
            long n = Convert.ToInt64(Console.ReadLine());
            long sum = 0;
            
            long last_value = 0;
            long i = 1;
            while (i < n)
            {
                long temp = i;
                if (i % 2 == 0)
                    sum += i;
                i = i + last_value;
                last_value = temp;
                //Console.WriteLine(temp);
            }
                
            
            Console.WriteLine(sum);
           
        }
        
    }
    /*static long FibonacciEven(long x, long [] fibHis)
    {
        long result = 0;
        if (x < 2)
            result = x;
        else if (x <  fibHis.Length && fibHis[x] > 0)
            result = fibHis[x];
        else
        {
            //if ((x - 1) % 2 == 0)
                result = FibonacciEven(x - 1, fibHis) + FibonacciEven(x - 2, fibHis);
            
        }
        if(x< fibHis.Length)
            fibHis[x] = result;
        return result;
    }*/
}

