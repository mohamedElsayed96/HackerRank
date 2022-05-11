#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'strangeCounter' function below.
#
# The function is expected to return a LONG_INTEGER.
# The function accepts LONG_INTEGER t as parameter.
#

def strangeCounter(t):
    i = 3
    while(i < t):
        t = t - i
        i *= 2  
    return i - t + 1
    
if __name__ == '__main__':
    t = int(input().strip())

    result = strangeCounter(t)

    print(str(result))
