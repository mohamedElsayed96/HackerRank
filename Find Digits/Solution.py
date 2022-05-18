#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'findDigits' function below.
#
# The function is expected to return an INTEGER.
# The function accepts INTEGER n as parameter.
#

def findDigits(n):
    result = 0
    for digit in n:
        if int(digit) > 0 and int(n) % int(digit) == 0:
            result += 1
    # Write your code here
    return result

if __name__ == '__main__':
    t = int(input().strip())
    result = list()
    for t_itr in range(t):
        n = str(input().strip())

        result.append(findDigits(n))

    print("\n".join(map(str, result)))
