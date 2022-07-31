#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'appendAndDelete' function below.
#
# The function is expected to return a STRING.
# The function accepts following parameters:
#  1. STRING s
#  2. STRING t
#  3. INTEGER k
#

def appendAndDelete(s, t, k):
    if s == t and k >= len(s) * 2 :
        return "Yes"
    sarr = list(s)
    c = k
    while c > 0:
        if len(sarr) == 0:
            if c >= len(t):
                return "Yes"
            else:
                return "No"

        if t.startswith("".join(sarr)) and c == len(t) - len(sarr):
                return "Yes"
        sarr.pop()
        c -= 1
    
    if("".join(sarr) == t):
        return "Yes"
    return "No"

if __name__ == '__main__':
    s = input()

    t = input()

    k = int(input().strip())

    result = appendAndDelete(s, t, k)

    print(result)

    
