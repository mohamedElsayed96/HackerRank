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

    // Complete the toys function below.
    static int toys(int[] w)
    {
        var result = 1;
        Array.Sort(w);
        var lowestElment = w[0];
        foreach (var el in w) 
        {
            if (lowestElment + 4 < el) 
            {
                result++;
                lowestElment = el;
            }
           
        }

        return result;
    }

    static void Main(string[] args)
    {

        int n = Convert.ToInt32(Console.ReadLine());

        int[] w = Array.ConvertAll(Console.ReadLine().Split(' '), wTemp => Convert.ToInt32(wTemp));
        int result = toys(w);

        Console.WriteLine(result);

        
    }
}
