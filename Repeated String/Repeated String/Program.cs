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
namespace Repeated_String
{
    class Program
    { // Complete the repeatedString function below.
        static long repeatedString(string s, long n)
        {
            long length = s.Length;
            if  (length >= n)
            {
                string str = s.Substring(0, (int)n);
                return str.Count(ch => ch == 'a');
            }
            else
            {
                long count = s.Count(ch => ch == 'a');
                long numOfconcStr = n / length;
                count *= numOfconcStr;
                long rem = n % length;
                string str = s.Substring(0, (int)rem);
                count += str.Count(ch => ch == 'a');
              
                return  count;
            }

        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = Console.ReadLine();

            long n = Convert.ToInt64(Console.ReadLine());

            long result = repeatedString(s, n);

            Console.WriteLine(result);
            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
