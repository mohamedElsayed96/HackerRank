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
     * Complete the 'queensAttack' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER r_q
     *  4. INTEGER c_q
     *  5. 2D_INTEGER_ARRAY obstacles
     */

    public static int queensAttack(int n, int k,  int y, int x, List<List<int>> obstacles)
    {
        int h1,h2,v1,v2,d11,d12,d21,d22;

        h1 = x - 1;
        h2 = n - x;
        v1 = y - 1;
        v2 = n - y;

        d11 = Math.Min(x - 1, y - 1);
        d12 = Math.Min(n - x, n - y);
        d21 = Math.Min(n - x, y - 1);
        d22 = Math.Min(x - 1, n - y);

        foreach (var obstacle in obstacles)
        {
            if (y == obstacle[0] && x > obstacle[1])
            {
                h1 = Math.Min(h1, x - obstacle[1] - 1);
                continue;
            }

            if (y == obstacle[0] && x < obstacle[1])
            {
                h2 = Math.Min(h2,  obstacle[1] - x - 1);
                continue;
            }

            if (x == obstacle[1] && y > obstacle[0])
            {
                v1 = Math.Min(v1, y - obstacle[0] - 1);
                continue;
            }

            if (x == obstacle[1] && y < obstacle[0])
            {
                v2 = Math.Min(v2, obstacle[0] - y - 1);
                continue;
            }


            if(x > obstacle[1] && y > obstacle[0] && ((x - obstacle[1]) == (y- obstacle[0])))
            {
                d11 = Math.Min(d11, y - obstacle[0] - 1);
            }
            if(x < obstacle[1] && y < obstacle[0] && (( obstacle[1] - x) == (obstacle[0] - y)))
            {
                d12 = Math.Min(d12,  obstacle[0] - y - 1);
            }
            if(x < obstacle[1] && y > obstacle[0] && ((obstacle[1] - x) == (y- obstacle[0])))
            {
                d21 = Math.Min(d21, y - obstacle[0] - 1);
            }
            if(x > obstacle[1] && y < obstacle[0] && (( x - obstacle[1]) == (obstacle[0] - y)))
            {
                d22 = Math.Min(d22,  obstacle[0] - y - 1);
            }
        }


        return h1 + h2 + v1 + v2 + d11 + d12 + d21 + d22;
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r_q = Convert.ToInt32(secondMultipleInput[0]);

        int c_q = Convert.ToInt32(secondMultipleInput[1]);

        List<List<int>> obstacles = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            obstacles.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(obstaclesTemp => Convert.ToInt32(obstaclesTemp)).ToList());
        }

        int result = Result.queensAttack(n, k, r_q, c_q, obstacles);

        Console.WriteLine(result);

    }
}