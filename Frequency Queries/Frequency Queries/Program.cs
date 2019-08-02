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

    // Complete the freqQuery function below.
    static List<int> freqQuery(List<List<int>> queries)
    {
        Dictionary<long, long> dict = new Dictionary<long, long>();
        Dictionary<long, long> dict2 = new Dictionary<long, long>();
        List<int> res = new List<int>();
        for (int i = 0; i < queries.Count; i++)
        {
            long data = queries[i][1];
            long query = queries[i][0];
            if (query == 1)
            { 
                long val;
              
                if (dict.TryGetValue(data, out val))
                {
                    if(dict2[dict[data]] != 0)
                        dict2[dict[data]]--;
                    dict[data]++;
                    if (dict2.ContainsKey(dict[data]))
                        dict2[dict[data]]++;
                    else
                        dict2.Add(dict[data], 1);



                }
                else
                {
                    dict.Add(data, 1);
                    if (dict2.ContainsKey(dict[data]))
                        dict2[dict[data]]++;
                    else
                        dict2.Add(dict[data], 1);

                }
            }
            if (query == 2)
            { 
                long val;
               
                if (dict.TryGetValue(data, out val))
                {
                    if (dict2.ContainsKey(dict[data]) && dict2[dict[data]] != 0)
                        dict2[dict[data]]--;                   
                    if (dict[data] != 0)
                        dict[data]--;
                    if (dict2.ContainsKey(dict[data]))
                        dict2[dict[data]]++;
                    else
                        dict2.Add(dict[data], 1);
                }
            }
            if (query == 3)
            {
                
                //long cont =  dict.Values.Where(el => el == data).Count();
                if (dict2.ContainsKey(data) && dict2[data] > 0)
                {
                    res.Add(1);
                }
                else
                    res.Add(0);
            }
        }
       return res;
    }

    static void Main(string[] args)
    {
      

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++)
        {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> ans = freqQuery(queries);

        Console.WriteLine(String.Join("\n", ans));

    
    }
}
