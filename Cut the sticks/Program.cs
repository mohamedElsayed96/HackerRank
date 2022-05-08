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

class Result
{

    /*
     * Complete the 'cutTheSticks' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static List<int> cutTheSticks(List<int> arr)
    {
        var result = new List<int>();
        result.Add(arr.Count);
        arr.Sort();
        while (arr.Count > 0)
        {
            int shortestStick = arr[0];
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] == shortestStick)
                {
                    arr.RemoveAt(i);
                    --i;
                    continue;
                }

                arr[i] -= shortestStick;
            }
            if(arr.Count != 0)
                result.Add(arr.Count);
        }

        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.cutTheSticks(arr);

        Console.WriteLine(String.Join("\n", result));
    }
}