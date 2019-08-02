using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Threading.Tasks;

namespace Jumping_on_the_Clouds
{
    class Program
    {
        // Complete the jumpingOnClouds function below.
        static void jumpingOnClouds(int[] c, out int result)
        {
            List<Task> tasks = new List<Task>();

            int p1 = 0;
            int p2 = 0;
            tasks.Add(Task.Run(() =>
            {
                p1 = calculatePath(1, p1, c);
            }));
            if (c.Length > 2)
            {
                tasks.Add(Task.Run(() =>
                {
                    p2 = calculatePath(2, p1, c);
                }));
            }

             Task.WhenAll(tasks).Wait();
             result = Math.Min(p1, p2) == 0 ? Math.Max(p1, p2) : Math.Min(p1, p2);
          
        }

        static  int calculatePath(int n,  int path, int[] c)
        {
            int p1 = 0;
            int p2 = 0;
            if (n >= c.Length - 1)
                return ++path;
            if (c[n] == 0)
            {
                path++;
               
                p1 = calculatePath(n + 1, path, c);
                if(n < c.Length - 2)
                    p2 = calculatePath(n + 2, path, c);
            }
            int result = Math.Min(p1, p2) == 0? Math.Max(p1, p2) : Math.Min(p1, p2);
            return result;
        }


        static void Main(string[] args)
        {
            

            int result;
            int n = Convert.ToInt32(Console.ReadLine());

            int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp));
            jumpingOnClouds(c, out result);
            Console.WriteLine(result);
           
        }
    }
}
