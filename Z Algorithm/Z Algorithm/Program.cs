using System;
using System.IO;
using System.Linq;

namespace Z_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = File.ReadAllText(@"H:\testCase.txt");
            long[] zArr = getZArray(s);
            Console.WriteLine(zArr.Sum());

            
        }

        static long[] getZArray(string s)
        {
            
            long[] zArray = new long[s.Length];
            zArray[0] = s.Length;
            long right = 0;
            long left = 0;
            
            for (long i = 1; i < s.Length; i++)
            {
               

                if(left >= right && left < s.Length )
                {
                    long c = i;
                    for (long j = 0; j < s.Length && c < s.Length; j++)
                    {
                        if (s[(int)c] == s[(int)j])
                        {
                            zArray[i]++;
                            c++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (zArray[i] > 1)
                    {
                         left = i;
                         right = left + zArray[i] - 1;
                       
                        if (right > s.Length)
                            right = s.Length - 1;
                    }
                }

                if (right > left && left < s.Length)
                {
                    long range = right - left + 1;
                    left++;
                    for (long j = 1; j < range ; j++)
                    {
                        if (zArray[j] - 1 + left >= right)
                        {
                            zArray[left] = right - left + 1;
                            long c = zArray[left];
                            long zarr = zArray[left];
                            for (long n = right + 1; n < s.Length; n++)
                            {
                                if (s[(int)n] == s[(int)c])
                                {
                                    zArray[left]++;
                                    c++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            left++;
                            if (left > right)
                            {
                                left = right;
                                break;
                            }
                            if (zArray[left] > zarr)
                            {
                                right = left + zArray[left] - 1;
                                if (right > s.Length)
                                    right = s.Length - 1;
                                break;
                            }
                        }
                        else
                        {
                            zArray[left] = zArray[j];
                            left++;
                            if (left > right)
                            {
                                left = right;
                                break;
                            }

                        }

                    }
                    i = left;


                }

            }


            /*for (long i = 1; i < s.Length; i++)
            {
                for (long j = 0, k = i; k < s.Length && j < s.Length; k++, j++)
                {
                    if (s[j] == s[k])
                    {
                        zArray[i]++;
                    }
                    else
                        break;

                }
            }*/
            return zArray;
        }
    }
}
