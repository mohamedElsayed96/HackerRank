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
    

    // Complete the commonChild function below.
    static int commonChild(string s1, string s2)
    {
        int[,] x = new int[s1.Length + 1, s2.Length + 1];
        int result = lcs(s1, s2, s1.Length, s2.Length, x);
        return result;
        
    }


    static int lcs(string s1, string s2, int n, int m, int [,] lcsHistory)
    {

        int lh = lcsHistory[n,m];
        int result = 0;
        if (lh != 0)
            return lh - 1;
        if (n <= 0 || m <= 0)
            result = 0;
        else if (s1[n - 1] == s2[m - 1])
            result = 1 + lcs(s1, s2, n - 1, m - 1, lcsHistory);
        else
        {
            result = Math.Max(lcs(s1, s2, n - 1, m, lcsHistory), lcs(s1, s2, n, m - 1, lcsHistory));
        }
        lcsHistory[n,m] = result + 1;
        return result;
    }

    static void Main(string[] args)
    {

        string s1 = Console.ReadLine();

        string s2 = Console.ReadLine();

        int result = commonChild(s1, s2);

        Console.WriteLine(result);

       
    }
}
