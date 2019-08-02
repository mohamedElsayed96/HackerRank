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

    // Complete the checkMagazine function below.
    static void checkMagazine(string[] magazine, string[] note)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();

        foreach (var item in magazine)
        {
            if (dict.ContainsKey(item))
                dict[item]++;
            else
                dict.Add(item, 1);
        }
        bool result = true;
        foreach (var item in note)
        {
            if (!dict.ContainsKey(item) || dict[item] <= 0)
                result = false;
            else
                dict[item]--;

        }
        if (result)
            Console.WriteLine("Yes");
        else
            Console.WriteLine("No");
                

    }

    static void Main(string[] args)
    {
        string[] mn = Console.ReadLine().Split(' ');

        int m = Convert.ToInt32(mn[0]);

        int n = Convert.ToInt32(mn[1]);

        string[] magazine = Console.ReadLine().Split(' ');

        string[] note = Console.ReadLine().Split(' ');

        checkMagazine(magazine, note);
    }
}
