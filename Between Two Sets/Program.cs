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
     * Complete the 'getTotalX' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY b
     */

    public static int getTotalX(List<int> a, List<int> b)
    {

        List<int> array1Factors = new List<int>();
        List<int> commonFactors = new List<int>();
        int array1MaxElement = a.Max();
        //find min element in b
        int maxPossibleFactor = b.Min();
        for (int i = array1MaxElement; i <= maxPossibleFactor; ++i) {
            bool factor = true;
            for (int j = 0; j < a.Count; ++j) {
                if (i % a.ElementAt(j) != 0) {
                    factor = false;
                    break;
                }
                
            }
            if (factor)
            {
                array1Factors.Add(i);
            }
        }

        for (int i = 0; i < array1Factors.Count; ++i) {
            bool factor = true;
            for (int j = 0; j < b.Count; ++j) {
                if (b.ElementAt(j) % array1Factors.ElementAt(i) != 0) {
                    factor = false;
                    break;
                }

            }
            if (factor)
            {
                commonFactors.Add(array1Factors.ElementAt(i));
            }
        }

        return commonFactors.Count;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        int total = Result.getTotalX(arr, brr);

        Console.WriteLine(total);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
