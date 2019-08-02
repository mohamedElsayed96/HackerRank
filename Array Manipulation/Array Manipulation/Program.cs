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

class program
{

    // Complete the arrayManipulation function below.
    static long arrayManipulation(int n, int[][] queries)
    {
        long[] arrZero = new long[n + 1];
        long Max = 0;
        foreach (var item in queries)
        {
            
            long mx = doOperation(arrZero, item);
            if (mx > Max)
                Max = mx;
        }
        return Max;// arrZero.Max();
    }

    static long doOperation(long[] arr, int[] query)
    {
        long max = arr.Skip(query[0]).Take(query[1] - query[0] + 2).Max();
        max += query[2];
        return max;
        /*for (int i = query[0] - 1; i < query[1]; i++)
        {
            arr[i] += query[2];
        }*/
    }
    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[][] queries = new int[m][];
        long[] arrZero = new long[n];
        for (int i = 0; i < m; i++)
        {
            queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
            //doOperation(arrZero, queries[i]);
        }

        long result = arrayManipulation(n, queries);

        Console.WriteLine(result);
        //textWriter.WriteLine(arrZero.Max());

        //textWriter.Flush();
        //textWriter.Close();
    }
}
