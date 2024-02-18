#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'taumBday' function below.
#
# The function is expected to return a LONG_INTEGER.
# The function accepts following parameters:
#  1. INTEGER b
#  2. INTEGER w
#  3. INTEGER bc
#  4. INTEGER wc
#  5. INTEGER z
#

def taumBday(b, w, bc, wc, z):
    # Write your code here
    if bc > wc + z:
        return b * (wc + z) + w * wc
    if wc > bc + z:
        return b * bc + w * (bc + z)
    return b* bc + w * wc

if __name__ == '__main__':
    t = int(input().strip())
    result = []

    for t_itr in range(t):
        first_multiple_input = input().rstrip().split()

        b = int(first_multiple_input[0])

        w = int(first_multiple_input[1])

        second_multiple_input = input().rstrip().split()

        bc = int(second_multiple_input[0])

        wc = int(second_multiple_input[1])

        z = int(second_multiple_input[2])

        result.append(taumBday(b, w, bc, wc, z))

    print('\n'.join(map(str, result)))

    

   
