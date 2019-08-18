#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the pairs function below.
def pairs(k, arr):
    result = 0
    i = 0
    arr.sort()
    
    dict = {}
    while i < len(arr):
        if arr[i] in dict:
            dict[arr[i]] += 1
        else:
            dict[arr[i]] = 1
        i+=1
    i = 0
    while i < len(arr):
        if arr[i] + k in dict:
            result += dict[arr[i] + k]
        i+=1
            
    return result

if __name__ == '__main__':

    nk = input().split()

    n = int(nk[0])

    k = int(nk[1])

    arr = list(map(int, input().rstrip().split()))

    result = pairs(k, arr)

    print(result)
    
