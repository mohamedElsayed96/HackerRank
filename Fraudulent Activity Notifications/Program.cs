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

    // Complete the activityNotifications function below.
    static int activityNotifications(int[] expenditure, int d)
    {
        int result = 0;
        int[] valuesCount = new int[201];
        for (int i = 0; i < d; i++)
        {
            valuesCount[expenditure[i]]++;
        }

        for (int i = d; i < expenditure.Length; i++)
        {
            //Array.ConstrainedCopy(expenditure, i - d, arr ,0, d);
            int index = i - d;


            if (expenditure[i] >= calculateMedian(expenditure, valuesCount, d))
                result++;

            valuesCount[expenditure[i - d]]--;
            valuesCount[expenditure[i]]++;



        }
        return result;
    }
    static int calculateMedian(int[] arr, int[] count, int d)
    {


        int midIndex1 = 0;
        int midIndex2 = 0;
        int c = 0;
        if (d % 2 == 0)
        {
            for (int i = 0; i < count.Length; i++)
            {
                c += count[i];
                if (midIndex1 == 0 && c >= d / 2)
                    midIndex1 = i;
                if (midIndex2 == 0 && c >= (d / 2) + 1)
                {
                    midIndex2 = i;
                    break;
                }

            }

            return midIndex1 + midIndex2;
        }
        else
        {
            for (int i = 0; i < count.Length; i++)
            {
                c += count[i];
                if (c >= (d / 2) + 1)
                {
                    midIndex1 = i;
                    break;
                }


            }
            return 2 * midIndex1;
        }

    }

    static void Main(string[] args)
    {
        string[] nd = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nd[0]);

        int d = Convert.ToInt32(nd[1]);

        int[] expenditure = Array.ConvertAll(Console.ReadLine().Split(' '), expenditureTemp => Convert.ToInt32(expenditureTemp))
        ;
        int result = activityNotifications(expenditure, d);

        Console.WriteLine(result);
    }
}
