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

    // Complete the anagram function below.
    static int anagram(string s)
    {

        int result = 0;
        int[] charCount = new int[26];
        if (s.Length % 2 != 0)
        {
            result = -1;
        }
        else
        {
            string s1 = s.Substring(0, s.Length / 2);
            string s2 = s.Substring((s.Length / 2), s.Length / 2);


            Console.WriteLine(s1 + " " + s2);

            for (int i = 0; i < s1.Length; i++)
            {
                charCount[s1[i] - 'a']++;
            }
           
            for (int i = 0; i < s2.Length; i++)
            {
                if (charCount[s2[i] - 'a']-- <= 0)
                    result++;
            }
            

        }
        return result;
    }

    static void Main(string[] args)
    {
        

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = anagram(s);

            Console.WriteLine(result);
        }

       
    }
}
