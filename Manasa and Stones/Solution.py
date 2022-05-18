#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'stones' function below.
#
# The function is expected to return an INTEGER_ARRAY.
# The function accepts following parameters:
#  1. INTEGER n
#  2. INTEGER a
#  3. INTEGER b
#

def stones(n, a, b):
    prefArrayA = [0] * n
    result = set()
    for i in range(1, n):
        prefArrayA[i] = a + prefArrayA[i - 1]
    
    i = 0
    while i < n:
        result.add(prefArrayA[i] + ((n - 1) - i) * b)
        i+=1
    result.add((n - 1) * b)
    return sorted(result)
    # Write your code here

if __name__ == '__main__':
    T = int(input().strip())
    result = list()
    for T_itr in range(T):
        n = int(input().strip())

        a = int(input().strip())

        b = int(input().strip())

        result.append(stones(n, a, b)) 
    for res in result:  
        print(' '.join(map(str, res)))
    
