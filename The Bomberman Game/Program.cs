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
     * Complete the 'bomberMan' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. STRING_ARRAY grid
     */
    const char emptyCell = '.';
    const char bombCell = 'O';
    public static List<string> bomberMan(int n, List<string> grid)
    {

        List<List<char>> gridChars = grid.Select(g => g.ToCharArray().ToList()).ToList();
        if(n == 1)
            return gridChars.Select(g => new string(g.ToArray())).ToList();

        if (n % 2 == 0)
        {
            return GetAllBombCells(gridChars.Count, gridChars[0].Count).Select(g => new string(g.ToArray())).ToList();
        }

        if ((n + 1) % 4 == 0)
        {
            return Explode(gridChars).Select(g => new string(g.ToArray())).ToList();
        }
        if ((n - 1) % 4 == 0)
        {
            var initialExplode = Explode(gridChars);
            // Console.WriteLine("------------------");
            // Console.WriteLine(String.Join("\n", initialExplode.Select(g => new string(g.ToArray())).ToList()));
            return Explode(initialExplode).Select(g => new string(g.ToArray())).ToList();
        }

        return gridChars.Select(g => new string(g.ToArray())).ToList();
    }

    private static List<List<char>> GetAllBombCells(int rows, int column)
    {
       
        List<List<char>> allBombChars =  new List<List<char>>(rows);
        for (int k = 0; k < rows; k++)
        {
            allBombChars.Add(new List<char>()); 
            for (int m = 0; m < column; m++)
            {
                allBombChars[k].Add(bombCell);

            }
        }

        return allBombChars;
    }

    private static List<List<char>> Explode(List<List<char>> gridChars)
    {
        var allBombChars = GetAllBombCells(gridChars.Count, gridChars[0].Count);
        for (int k = 0; k < allBombChars.Count; k++)
        {
            for (int m = 0; m < allBombChars[k].Count; m++)
            {
                if (allBombChars[k][m] == bombCell)
                {

                    if (allBombChars[k][m] == gridChars[k][m])
                    {
                        allBombChars[k][m] = emptyCell;
                        if (k + 1 < allBombChars.Count)
                        {
                            if (allBombChars[k + 1][m] == bombCell
                                && allBombChars[k + 1][m] != gridChars[k + 1][m])
                            {
                                allBombChars[k + 1][m] = emptyCell;

                            }

                        }
                        if (k - 1 >= 0)
                        {
                            if (allBombChars[k - 1][m] == bombCell
                                && allBombChars[k - 1][m] != gridChars[k - 1][m])
                            {
                                allBombChars[k - 1][m] = emptyCell;

                            }

                        }
                        if (m + 1 < allBombChars[k].Count)
                        {
                            if (allBombChars[k][m + 1] == bombCell
                                && allBombChars[k][m + 1] != gridChars[k][m + 1])
                            {
                                allBombChars[k][m + 1] = emptyCell;

                            }
                        }
                        if (m - 1 >= 0)
                        {
                            if (allBombChars[k][m - 1] == bombCell
                                && allBombChars[k][m - 1] != gridChars[k][m - 1])
                            {
                                allBombChars[k][m - 1] = emptyCell;

                            }

                        }
                    }
                }

            }
        }

        return allBombChars;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r = Convert.ToInt32(firstMultipleInput[0]);

        int c = Convert.ToInt32(firstMultipleInput[1]);

        int n = Convert.ToInt32(firstMultipleInput[2]);

        List<string> grid = new List<string>();

        for (int i = 0; i < r; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        List<string> result = Result.bomberMan(n, grid);
        // Console.WriteLine("------------------");
        Console.WriteLine(String.Join("\n", result));

    }
}