#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'squares' function below.
#
# The function is expected to return an INTEGER.
# The function accepts following parameters:
#  1. INTEGER a
#  2. INTEGER b
#

def squares(a, b):
    result =  math.floor(math.sqrt(b)) - math.ceil(math.sqrt(a)) + 1
    return result
if __name__ == '__main__':
    
    q = int(input().strip())
    result = []
    for q_itr in range(q):
        first_multiple_input = input().rstrip().split()

        a = int(first_multiple_input[0])

        b = int(first_multiple_input[1])

        result.append(squares(a, b))

    print("\n".join(map(str, result)))

    
