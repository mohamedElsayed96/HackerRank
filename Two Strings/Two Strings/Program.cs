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

    // Complete the twoStrings function below.
    static string twoStrings(string s1, string s2)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        
        for (int j = 0; j <= s1.Length - 1; j++)
        {
            string str = s1.Substring(j, 1);
            if (dict.ContainsKey(str))
                dict[str]++;
            else
                dict.Add(str, 1);
        }
        

        
        for (int j = 0; j <= s2.Length - 1; j++)
        {
            string str = s2.Substring(j, 1);
            if (dict.ContainsKey(str))
            {
                return "YES";
            }

               
        }
        
        return "No";

    }

    static void Main(string[] args)
    {
        

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s1 = Console.ReadLine();

            string s2 = Console.ReadLine();

            string result = twoStrings(s1, s2);

            Console.WriteLine(result);
        }

       
    }
}
