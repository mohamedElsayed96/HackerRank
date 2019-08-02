using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SuffixArray_nlgnlgn_
{
    class SuffixCompare : IComparer<long>
    {
        public long[] rank { get; set; }
        public long k { get; set; }
        public SuffixCompare(long[] rn, long k)
        {
            rank = rn;
            this.k = k;
        }
        public int Compare(long a, long b)
        {
            if (rank[a] != rank[b])
                return (rank[a] > rank[b]) ? 1 : -1;
            else
            {
                long var1 = 0;
                long var2 = 0;
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
    class Solution
    {
        static long[] SuffixArray(string str)
        {
            long length = str.Length;
            long[] rank = new long[length];
            long[] suf = new long[length];
            SuffixCompare suffixCompare = new SuffixCompare(rank, 0);
            long[] rankTemp = new long[length];
            for (long i = 0; i < length; i++)
            {
                suf[i] = i;
                rank[i] = str[(int)i] - 'a';
            }
            Array.Sort(suf, suffixCompare);

            rankTemp[0] = 0;
            for (long k = 1; rankTemp[length - 1] != length - 1; k *= 2)
            {
                suffixCompare.k = k;
                Array.Sort(suf, suffixCompare);
                for (long i = 1; i < length; i++)
                {
                    if (suffixCompare.Compare(suf[i - 1], suf[i]) == 0)
                        rankTemp[i] = rankTemp[i - 1];
                    else
                        rankTemp[i] = rankTemp[i - 1] + 1;
                }
                for (long i = 0; i < length; i++)
                {
                    rank[suf[i]] = rankTemp[i];
                }


            }



            return suf;

        }
        static long[] LcpArray(long[] suf, string s)
        {
            long[] LcpArr = new long[s.Length];
            long[] rank = new long[s.Length];
            for (long i = 0; i < s.Length; i++)
            {
                rank[suf[i]] = i;
            }
            long c = 0;
            for (long i = 0; i < s.Length; i++)
            {

                if (rank[i] != 0)
                {
                    long j = suf[rank[i] - 1];
                    while (j + c < s.Length && i + c < s.Length && s[(int)(i + c)] == s[(int)(j + c)])
                        c++;
                }
                LcpArr[rank[i]] = c;
                if (c > 0)
                    c--;
            }
            return LcpArr;
        }

        static char ashtonString(string s, long k)
        {
            long[] suf = SuffixArray(s);
            long[] lcp = LcpArray(suf, s);
            long length = s.Length;
            char result = '0';
            long count = k;
            long initialLength = length - (suf[0]);
            count -= sum(initialLength);
            if (count <= 0)
            {
                for (long i = 1; i <= initialLength; i++)
                {
                    string str = s.Substring((int)suf[0], (int)i);
                    long len = str.Length;

                    if (k <= len)
                    {
                        result = str[(int)k - 1];
                        break;
                    }
                    else
                        k -= len;
                }
            }
            else
            {
                k = count;
                for (long i = 1; i < s.Length; i++)
                {
                    long curSub = s.Length - suf[i];

                    count -= sum(curSub)  - sum(lcp[i]);

                    if (count <= 0)
                    {

                        for (long j = lcp[i] + 1; j <= curSub; j++)
                        {
                            string str = s.Substring((int)suf[i], (int)j);
                            long len = str.Length;

                            if (k <= len)
                            {
                                long index = (long)k - 1;
                                return str[(int)index];
                            }
                            else
                                k -= len;
                        }
                    }
                    else
                        k = count;
                }
            }
            return result;
        }

        static long sum(long n)
        {
            long sum = 0;
            for (long i = 1; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }

        static void Main(string[] args)
        {

            long t = Convert.ToInt32(Console.ReadLine());

            for (long tItr = 0; tItr < t; tItr++)
            {
                //string s = File.ReadAllText(@"H:\testCase.txt");
                string s = Console.ReadLine();

                long k = Convert.ToInt32(Console.ReadLine());

                char res = ashtonString(s, k);

                Console.WriteLine(res);
            }


        }
    }
}