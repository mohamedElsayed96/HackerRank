#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'breakingRecords' function below.
#
# The function is expected to return an INTEGER_ARRAY.
# The function accepts INTEGER_ARRAY scores as parameter.
#

def breakingRecords(scores):
    # Write your code here
    minmumScore = scores[0]
    maxmumScore = scores[0]
    nomOfMaxBreak = 0
    nomOfMinBreak = 0

    for i in range(1, len(scores)):
        if( scores[i] > maxmumScore):
            nomOfMaxBreak +=1
            maxmumScore = scores[i]
            continue
        if(scores[i] < minmumScore):
            nomOfMinBreak+=1
            minmumScore = scores[i]
    return [nomOfMaxBreak, nomOfMinBreak]


if __name__ == '__main__':
    n = int(input().strip())

    scores = list(map(int, input().rstrip().split()))

    result = breakingRecords(scores)

    print(' '.join(map(str, result)))

