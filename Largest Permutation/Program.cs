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

    // Complete the largestPermutation function below.
    static int[] largestPermutation(int k, int[] arr)
    {
        int[] indexes = new int[arr.Length + 1];
        for (int i = 0; i < arr.Length; i++)
        {
            indexes[arr[i]] =  i;
        }
        //int[] result = new int[arr.Length];
        //Array.Copy(arr, result, arr.Length);
        //Array.Sort(arr, new Comparison<int>((a1, a2) => a2.CompareTo(a1)));
        int n = arr.Length;
        for (int i = 0; i < arr.Length && k > 0 ; i++)
        {
            if (n - i > arr[i]) 
            {
                int x = arr[i];
                arr[i] = n - i;
                arr[indexes[arr[i]]] = x;
                indexes[x] = indexes[arr[i]];
                indexes[n - i] = i;
                k--;
            }
           
        }
        return arr;
    }

    static void Main(string[] args)
    {

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int[] result = largestPermutation(k, arr);

        Console.WriteLine(string.Join(" ", result));


    }
}
