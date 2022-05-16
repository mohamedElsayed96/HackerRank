#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'almostSorted' function below.
#
# The function accepts INTEGER_ARRAY arr as parameter.
#

def almostSorted(arr):

    if checkIfArrayIsSorted(arr):
        print("yes")
        return
    # try swap
    arrCp = arr.copy()
    swapStartIndex = - 1
    swapEndIndex = 0
    for i in range(1, len(arr)):
        if(swapStartIndex < 0 and arr[i - 1] > arr[i]):
            swapStartIndex = i - 1
        checkIndex = arr[i + 1] > arr[swapStartIndex] if i + 1 < len(arr) else True
        if(swapStartIndex >= 0 and arr[i] < arr[swapStartIndex] and checkIndex):
            swapEndIndex = i
            arrCp[swapStartIndex] = arr[swapEndIndex]
            arrCp[swapEndIndex] = arr[swapStartIndex]   
            break

    if checkIfArrayIsSorted(arrCp):
        print("yes")
        print(f"swap {swapStartIndex + 1} {swapEndIndex + 1}")
        return
        
    # reverse swap
    arrCp[swapStartIndex] = arr[swapStartIndex]
    arrCp[swapEndIndex] = arr[swapEndIndex]   

    reverseStartIndex = swapStartIndex
    reverseEndIndex = 0

    for i in range(swapStartIndex + 1, len(arr)):
        if arr[i] > arr[i - 1]:
            if arr[i] < arr[reverseStartIndex]:
                print("no")
                return
            reverseEndIndex = i - 1
            break

    for i in range(reverseStartIndex, reverseEndIndex + 1):
        index = reverseEndIndex - (i - reverseStartIndex)
        arrCp[i] = arr[index]


    if checkIfArrayIsSorted(arrCp):
        print("yes")
        print(f"reverse {reverseStartIndex + 1} {reverseEndIndex + 1}")
        return

    print("no")
    return
    # Write your code here


def checkIfArrayIsSorted(arr):
    isSorted = True
    for i in range(1, len(arr)):
        if(arr[i - 1] > arr[i]):
            isSorted = False
            break
    return isSorted
if __name__ == '__main__':

    n = int(input().strip())

    arr = list(map(int, input().rstrip().split()))
    almostSorted(arr)

