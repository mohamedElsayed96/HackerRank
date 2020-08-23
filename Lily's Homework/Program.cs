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

    // Complete the lilysHomework function below.
    static int lilysHomework(int[] arr)
    {
        Dictionary<int, int> inputs = new Dictionary<int, int>();
        Dictionary<int, int> inputDecs = new Dictionary<int, int>();


        for (int i = 0; i < arr.Length; i++)
        {
            inputs.Add(arr[i], i);
            inputDecs.Add(arr[i], i);
        }
        int[] arrAscCopy = new int[arr.Length];
        int[] arrDescCopy = new int[arr.Length];

        //int[] arrCopy = new int[arr.Length];
        Array.Copy(arr, arrAscCopy, arr.Length);
        Array.Copy(arr, arrDescCopy, arr.Length);

        Array.Sort(arr);

        var ascSwaps = 0;
        var descSwaps = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (inputs[arr[i]] != i) 
            {

                int x = arrAscCopy[i];
                arrAscCopy[i] = arr[i];
                arrAscCopy[inputs[arr[i]]] = x;
                inputs[x] = inputs[arr[i]];
                inputs[arrAscCopy[i]] = i;
                ascSwaps++;
            }

           
        }
        for (int i = arr.Length -1; i >= 0 ; i--)
        {
            if (inputDecs[arr[i]] != arr.Length - 1 - i)
            {
                var curIndex = arr.Length - 1 - i;
                int x = arrDescCopy[curIndex];
                arrDescCopy[curIndex] = arr[i];
                arrDescCopy[inputDecs[arr[i]]] = x;
                inputDecs[x] = inputDecs[arr[i]];
                inputDecs[arrDescCopy[curIndex]] = i;
                descSwaps++;
            }
        }

        return Math.Min(ascSwaps, descSwaps);

    }

    static void Main(string[] args)
    {

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int result = lilysHomework(arr);

        Console.WriteLine(result);


    }
}
