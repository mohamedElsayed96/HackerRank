#!/bin/python3

import math
import os
from pickle import TRUE
import random
import re
import sys

# Complete the flatlandSpaceStations function below.
def flatlandSpaceStations(n, c):
    distances = [sys.maxsize] * n
    stations = [None] * n 
    c.sort()
    lowestLeftStation = c[0]
    lowestRightStation = c[len(c) - 1]

    for i in c:
        stations[i] = True

    l = 0
    r = n - 1
    if l == r:
        distances[0] = 0
    else:
        while(l < n and r >= 0 ):
            leftFound = False
            rightFound = False
            if(stations[l] == True):
                distances[l] = 0
                lowestLeftStation = l
                leftFound = True
            if(stations[r] == True):
                distances[r] = 0
                lowestRightStation = r
                rightFound = True
            if leftFound == False:
                distances[l] = (min(distances[l], abs(lowestLeftStation - l), abs(lowestRightStation - l)) )
            if rightFound == False:
                distances[r] = (min(distances[r], abs(lowestLeftStation - r), abs(lowestRightStation - r)) )
            l+=1
            r-=1
    return max(distances)
if __name__ == '__main__':
    nm = input().split()

    n = int(nm[0])

    m = int(nm[1])

    c = list(map(int, input().rstrip().split()))

    result = flatlandSpaceStations(n, c)

    print(str(result))