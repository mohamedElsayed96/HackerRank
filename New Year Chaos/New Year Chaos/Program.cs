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

class Solution
{

    // Complete the minimumBribes function below.
    static object minimumBribes(int[] q)
    {
        ArrayList arrayList = new ArrayList();
        int prip = 0;
        for (int i = q.Length - 1; i >=0 ; --i)
        {
            if (q[i] > i + 1)
            {
                int el = q[i];
                int pr = q[i] - (i + 1);
                if (pr < 3)
                {
                    prip += pr;
                    for (int j = i; j < pr + i; j++)
                    {
                        q[j] = q[j + 1];
                        q[j + 1] = el;
                    }
                    i = el - 1;
                   
                }
                else
                {
                  
                    return "Too chaotic";
                }
            }
            else
            {
                continue;
            }
        }
        return prip;

    }

    static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        ArrayList arrayList = new ArrayList();

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp));
            arrayList.Add(minimumBribes(q));
        }

        foreach (var item in arrayList)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
