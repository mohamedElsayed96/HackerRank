#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'utopianTree' function below.
#
# The function is expected to return an INTEGER.
# The function accepts INTEGER n as parameter.
#

def utopianTree(n):
    # Write your code here
    height = 1
    for j in range(1, n + 1):
        if(j % 2 != 0):
            height *= 2
            continue
        height += 1
    return height

if __name__ == '__main__':
    t = int(input().strip())

    answer = []
    for t_itr in range(t):
        n = int(input().strip())

        result = utopianTree(n)

        answer.append(str(result))
    print("\n".join(answer))
   
