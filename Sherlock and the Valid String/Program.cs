using System;
using System.Collections.Generic;
using System.Linq;

namespace Sherlock_and_the_Valid_String
{
    class Solution
    {

        // Complete the isValid function below.
        static string isValid(string s)
        {
            Dictionary<int, int> charactersCount = new Dictionary<int, int>();
            List<int> counts = new List<int>();        
            foreach (var car in s) 
            {
                if (charactersCount.ContainsKey(car))
                    charactersCount[car]++;
                else
                    charactersCount.Add(car, 1);

            }
            foreach(var el in charactersCount) 
            {
                counts.Add(el.Value);
            }
            counts.Sort();

            var curCount = counts[0];
            charactersCount = new Dictionary<int, int>();
            charactersCount.Add(curCount, 1);
            for (int i = 1; i < counts.Count; i++)
            {
                if (counts[i] == curCount)
                {
                    charactersCount[counts[i]]++;
                }
                else 
                {
                    charactersCount.Add(counts[i], 1);
                    curCount = counts[i];


                }
            }
           
            if (charactersCount.Count == 1)
                return "YES";
            if (charactersCount.Count == 2)
            {
               
                if ((charactersCount.ElementAt(0).Key == 1 || charactersCount.ElementAt(0).Key - charactersCount.ElementAt(1).Key == 1) && charactersCount.ElementAt(0).Value == 1)
                    return "YES";
                if ((charactersCount.ElementAt(1).Key == 1 || charactersCount.ElementAt(0).Key - charactersCount.ElementAt(1).Key == -1) && charactersCount.ElementAt(1).Value == 1)
                    return "YES";            
            }
           
            return "NO";
            

        }

        static void Main(string[] args)
        {

            string s = Console.ReadLine();

            string result = isValid(s);
            Console.WriteLine(result);
          
        }
    }
}
