#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'saveThePrisoner' function below.
#
# The function is expected to return an INTEGER.
# The function accepts following parameters:
#  1. INTEGER n
#  2. INTEGER m
#  3. INTEGER s
#

def saveThePrisoner(n, m, s):
    x = s + (m - 1)
    r = x % n
    if r == 0 :
        return n
    return r
    # Write your code here

if __name__ == '__main__':
    t = int(input().strip())
    result = []

    for t_itr in range(t):
        first_multiple_input = input().rstrip().split()

        n = int(first_multiple_input[0])

        m = int(first_multiple_input[1])

        s = int(first_multiple_input[2])

        result.append(saveThePrisoner(n, m, s))

       

print('\n'.join(map(str, result)))
    
