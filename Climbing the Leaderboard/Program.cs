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
     * Complete the 'climbingLeaderboard' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY ranked
     *  2. INTEGER_ARRAY player
     */

    public static List<int> ClimbingLeaderBoard(List<int> ranked, List<int> player)
    {
        var result = new List<int>();
        var rankedDict = new Dictionary<int, int>();

        var rank = 0;
        foreach (var t in ranked)
        {
            if (rankedDict.ContainsKey(t))
            {
                continue;
            }
            rankedDict.Add(t, ++rank);
        }

        foreach (var game in player)
        {
            if (rankedDict.ContainsKey(game))
            {
                result.Add(rankedDict[game]);
                continue;
            }

            if (game > ranked[0])
            {
                result.Add(1);
                continue;
            }
            if (game < ranked[ranked.Count - 1])
            {
                result.Add(rankedDict[ranked[ranked.Count - 1]] + 1);
                continue;
            }

            var nearestIndex = BinarySearch(ranked, game);
            var nearestRank = rankedDict[ranked[nearestIndex]];
            result.Add(game > ranked[nearestIndex] ? nearestRank : nearestRank + 1);
        }

        return result;
    }

    private static int BinarySearch(List<int> a, int item)
    {
        int first = 0;
        int last = a.Count - 1;
        int mid = 0;
        do
        {
            mid = first + (last - first) / 2;
            if (item < a[mid])
                first = mid + 1;
            else
                last = mid - 1;
            if (a[mid] == item)
                return mid;
        } while (first <= last);
        return mid;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
       

        int rankedCount = Convert.ToInt32(Console.ReadLine()?.Trim());

        List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

        int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

        List<int> result = Result.ClimbingLeaderBoard(ranked, player);

        Console.WriteLine(String.Join("\n", result));

    }
}