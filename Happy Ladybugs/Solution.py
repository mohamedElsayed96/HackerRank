#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'happyLadybugs' function below.
#
# The function is expected to return a STRING.
# The function accepts STRING b as parameter.
#

def happyLadybugs(b):
    map = dict()
    for i in range(len(b)):
        if b[i] in map:
            map[b[i]] += 1
        else: 
            map[b[i]] = 1
            
    # Write your code here
    if "_" in map :
        for key, value in map.items():
            if key != "_" and value == 1:
                return "NO"
        return "YES"
    for i in range(0, len(b)):
        if (i - 1 < 0 or b[i] != b [i - 1]) and ( i + 1 >= len(b) or b[i] != b [i + 1]):
            return "NO"
    return "YES"
if __name__ == '__main__':
    g = int(input().strip())
    result = []
    for g_itr in range(g):
        n = int(input().strip())

        b = input()

        result.append(happyLadybugs(b))

    print("\n".join(result))
