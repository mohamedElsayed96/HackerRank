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
     * Complete the 'dayOfProgrammer' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER year as parameter.
     */

    public static string dayOfProgrammer(int year)
    {
        string leapYearDay = "12.09.{0}";
        string nonLeapYearDay = "13.09.{0}";


        if (year < 1918)
        {
            if (year % 4 == 0)
            {
                return string.Format(leapYearDay, year);
            }

            return string.Format(nonLeapYearDay, year);
        }

        if (year > 1918)
        {
            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            {
                return string.Format(leapYearDay, year);
            }

            return string.Format(nonLeapYearDay, year);
        }
        
        return $"26.09.{year}";

    }

}

class Solution
{
    public static void Main(string[] args)
    {

        int year = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.dayOfProgrammer(year);

        Console.WriteLine(result);
    }
}
