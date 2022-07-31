#!/bin/python3

import math
import os
import random
import re
import sys



def kaprekarNumbers(p, q):
    # Write your code here
    result = []
    for i in range(p, q + 1):
        power = str(i * i)
        if(len(power) % 2 != 0):
            power = '0'+ power
        p1 = power[:int(len(power) / 2)]
        p2 = power[int(len(power) / 2):]
        if(int(p1) + int(p2) == i):
            result.append(i)
    if len(result) == 0:
        print("INVALID RANGE") 
    else:
        result.sort()
        print(" ".join(map(str, result)))
        

if __name__ == '__main__':
    p = int(input().strip())

    q = int(input().strip())

    kaprekarNumbers(p, q)
