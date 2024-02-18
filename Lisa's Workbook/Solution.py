#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'workbook' function below.
#
# The function is expected to return an INTEGER.
# The function accepts following parameters:
#  1. INTEGER n
#  2. INTEGER k
#  3. INTEGER_ARRAY arr
#

def workbook(n, k, arr):
    pa = 1
    answer = 0
    for chap in arr:
        pages_in_chapter = 1
        if chap > k:
            if chap % k == 0:
                pages_in_chapter = chap // k
            else:
                pages_in_chapter = chap // k + 1
        end_page = pa + pages_in_chapter - 1
        pr = 0
        while pa <= end_page:
            new_pr = 0
            if k <= chap:
                new_pr = pr + k
                chap = chap - k
            else:
               new_pr = pr + chap
               chap = 0
            if(pa > pr and pa <= new_pr ):
                answer = answer + 1
            pr = new_pr
            pa = pa + 1
    return answer




    # Write your code here

if __name__ == '__main__':
    first_multiple_input = input().rstrip().split()

    n = int(first_multiple_input[0])

    k = int(first_multiple_input[1])

    arr = list(map(int, input().rstrip().split()))

    result = workbook(n, k, arr)

    print(str(result) + '\n')

