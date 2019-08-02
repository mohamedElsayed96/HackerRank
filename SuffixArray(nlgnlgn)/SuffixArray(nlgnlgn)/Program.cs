using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SuffixArray_nlgnlgn_
{
    class SuffixCompare : IComparer<int>
    {
        public int[] rank { get; set; }
        public int k { get; set; }
        public SuffixCompare(int[] rn, int k)
        {
            rank = rn;
            this.k = k;
        }
        public int Compare(int a, int b)
        {
            if (rank[a] != rank[b])
                return (rank[a] > rank[b]) ? 1 : -1;
            else
            {
                int var1 = 0;
                int var2 = 0;
                if (a + k >= rank.Length)
                    var1 = -1;
                else
                    var1 = rank[a + k];
                if (b + k >= rank.Length)
                    var2 = -1;
                else
                    var2 = rank[b + k];
                return var1 == var2 ? 0 : (var1 > var2) ? 1 : -1;
            }

        }
    }
    
    class Program
    {
        
        static void Main(string[] args)
        {
            //string s = File.ReadAllText(@"H:\testCase.txt");
            string s = Console.ReadLine();
            int[] suf = SuffixArray(s);
            int[] lcp = LcpArray(suf, s);
            Console.WriteLine("Suffix: ");
            foreach (var item in suf)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Lcp: ");
            foreach (var item in lcp)
            {
                Console.WriteLine(item);
            }
        }

        static int[] SuffixArray(string str)
        {
            int length = str.Length;
            int[] rank = new int[length];
            int[] suf = new int[length];
            SuffixCompare suffixCompare = new SuffixCompare(rank, 0);
            int[] rankTemp = new int[length];
            for (int i = 0; i < length; i++)
            {
                suf[i] = i;
                rank[i] = str[i] - 'a';
            }
            Array.Sort(suf, suffixCompare);

            rankTemp[0] = 0;
            for (int k = 1; rankTemp[length - 1] != length - 1; k *= 2)
            {
                suffixCompare.k = k;
                Array.Sort(suf, suffixCompare);
                for (int i = 1; i < length; i++)
                {
                    if (suffixCompare.Compare(suf[i - 1], suf[i]) == 0)
                        rankTemp[i] = rankTemp[i - 1];
                    else
                        rankTemp[i] = rankTemp[i - 1] + 1;
                }
                for (int i = 0; i < length; i++)
                {
                    rank[suf[i]] = rankTemp[i];
                }
               

            }

            

            return suf;
         
        }
        static int[] LcpArray(int[] suf, string s) 
        {
            int[] LcpArr = new int[s.Length];
            int[] rank = new int[s.Length]; 
            for (int i = 0; i < s.Length; i++)
            {
                rank[suf[i]] = i;
            }
            int c = 0;
            for (int i = 0; i < s.Length; i++)
            {
                
                if (rank[i] != 0)
                {
                    int j = suf[rank[i]-1];
                    while (j + c < s.Length && i + c < s.Length && s[i + c] == s[j + c])
                        c++;
                }
                LcpArr[rank[i]] = c;
                if (c > 0)
                    c--;
            }
            return LcpArr;
        }
    }
}
