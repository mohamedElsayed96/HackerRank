#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'chocolateFeast' function below.
#
# The function is expected to return an INTEGER.
# The function accepts following parameters:
#  1. INTEGER n
#  2. INTEGER c
#  3. INTEGER m
#

def chocolateFeast(n, c, m):
    result = n // c
    if result < m : 
        return result
    wrappers = result
    while(wrappers >= m):
        newChocolate = wrappers//m
        result += newChocolate
        wrappers = (wrappers + newChocolate) - (newChocolate * m)
    return result
    


if __name__ == '__main__':
    

    t = int(input().strip())
    result = []

    for t_itr in range(t):
        first_multiple_input = input().rstrip().split()

        n = int(first_multiple_input[0])

        c = int(first_multiple_input[1])

        m = int(first_multiple_input[2])

        result.append(chocolateFeast(n, c, m))

    print("\n".join(map(str, result)))
