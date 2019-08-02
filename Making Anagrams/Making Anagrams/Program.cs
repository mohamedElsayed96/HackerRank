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

    // Complete the makeAnagram function below.
    static int makeAnagram(string a, string b)
    {
        int[] charCount = new int[26];
        int[] charCount2 = new int[26];
        for (int i = 0; i < a.Length; i++)
        {
            charCount[a[i] - 'a']++;
        }
        for (int i = 0; i < b.Length; i++)
        {
            
                charCount2[b[i] - 'a']++;
        }

        int sum = 0;
        for (int i = 0; i < charCount.Length; i++)
        {
            if (charCount[i] > 0 && charCount2[i] > 0)
                sum += Math.Abs(charCount[i] - charCount2[i]);
            else
                sum += charCount[i] + charCount2[i];
        }
        return sum;
    }

    static void Main(string[] args) 
    {


        string a = Console.ReadLine();

        string b = Console.ReadLine();

        int res = makeAnagram(a, b);

        Console.WriteLine(res);

        
    }
}
