#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'encryption' function below.
#
# The function is expected to return a STRING.
# The function accepts STRING s as parameter.
#

def encryption(s):
    result=[]
    s = str(s)
    s = s.replace(" ","")
    sqr = math.sqrt(len(s))
    row = math.floor(sqr)
    column = math.ceil(sqr)
    for i in range(0, column):
        result.append(s[i::column])
    return " ".join(result)
    

    # Write your code here

if __name__ == '__main__':
    s = input()

    result = encryption(s)

    print(result)
