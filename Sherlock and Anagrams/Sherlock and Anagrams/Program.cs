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
using System.Collections.Concurrent;

class Solution
{

    // Complete the sherlockAndAnagrams function below.
    static int sherlockAndAnagrams(string s)
    {
        int nOfPairs = 0;
        List<string> substrings = new List<string>();
        List<Task> tasks = new List<Task>();

        ConcurrentDictionary<string, int> dict = new ConcurrentDictionary<string, int>();

        for (int i = 1; i < s.Length; i++)
        {
            for (int start = 0; start <= s.Length - i; start++)
            {
                //tasks.Add(new TaskFactory().StartNew(new Action<object>((ob) =>
                //{

                    //int[] arr = (int[])ob;
                    string subArr = s.Substring(start, i);
                    if (subArr != null)
                    {
                        char[] charArr = subArr.ToArray();
                        Array.Sort(charArr);
                        string str = new string(charArr);
                        if (dict.ContainsKey(str))
                        {
                            dict[str]++;
                        }
                        else
                        {
                            dict.TryAdd(str, 1);
                        }
                    }
                //}), new int[] {start, i}));
               
            }
        }
    
        //Task.WhenAll(tasks).Wait();
        foreach (var item in dict)
        {
            nOfPairs += (item.Value * (item.Value - 1)) / 2;
        }
        return nOfPairs;
    }

    

    static void Main(string[] args)
    {
        

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = sherlockAndAnagrams(s);

            Console.WriteLine(result);
        }

        
    }
}
