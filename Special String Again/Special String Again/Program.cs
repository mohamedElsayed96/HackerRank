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

class Point 
{
    public char Character { get; set; }
    public int Count { get; set; }
}
class Solution
{
    static long SpecialSubStrings = 0;

    static List<KeyValuePair<char, int>> characterCount = new List<KeyValuePair<char, int>>();
    static long substrCount(int n, string s)
    {
        char cur = s[0];
        int count = 1;
       
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == cur)
            {
                count++;
            }
            else
            {
                characterCount.Add(new KeyValuePair<char, int>(cur, count));
                cur = s[i];
                count = 1;
            }

        }
        characterCount.Add(new KeyValuePair<char, int>(cur, count));
        foreach (var el in characterCount)
        {
            SpecialSubStrings += (el.Value * (el.Value + 1)) / 2;
        }
        for (int i = 1; i < characterCount.Count; i++)
        {
            var curEl = characterCount[i];
            if (i < characterCount.Count - 1 && characterCount[i - 1].Key == characterCount[i + 1].Key && curEl.Value == 1)
            {
                SpecialSubStrings += Math.Min(characterCount[i - 1].Value , characterCount[i + 1].Value);

            }
        }

        //for (int i = 0; i < n; i++)
        //{
        //    for (int j = 1; j <= n - i; j++)
        //    {
        //        Dictionary<string, bool> chars = new Dictionary<string, bool>();
        //        string subString = s.Substring(i, j);

        //        if (chars.ContainsKey(subString))
        //        {
        //            SpecialSubStrings++;
        //            continue;
        //        }
        //        else if (subString.Length == 1)
        //        {

        //            chars.Add(subString, true);
        //            SpecialSubStrings++;
        //            continue;
        //        }
        //        else if (IsSpecialString(subString))
        //        {
        //            chars.Add(subString, true);
        //            SpecialSubStrings++;

        //        }

        //    }
        //}
        return SpecialSubStrings;

    }

    //static bool IsSpecialString(string s) 
    //{
    //    Dictionary<char, bool> chars = new Dictionary<char, bool>();
    //    if (s.Length % 2 != 0)
    //    {
    //        s = s.Remove((s.Length - 1) / 2, 1);
    //    }
    //    chars.Add(s[0], true);
    //    for (int i = 1; i < s.Length; ++i)
    //    {
    //        if (!chars.ContainsKey(s[1]))
    //            return false;
            
    //    }

    //    return true;
    //}

    static void Main(string[] args)
    {

        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        long result = substrCount(n, s);

        Console.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}