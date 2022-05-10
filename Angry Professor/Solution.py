#!/bin/python3

from ast import If
import math
import os
import random
import re
import sys

#
# Complete the 'angryProfessor' function below.
#
# The function is expected to return a STRING.
# The function accepts following parameters:
#  1. INTEGER k
#  2. INTEGER_ARRAY a
#

def angryProfessor(k, a):
    absentStudents = 0
    attendedStudents = 0
    students = len(a)
    for i in a:
        if i <= 0:
            attendedStudents +=1
            if attendedStudents >= k:
                return "NO"
            continue
        absentStudents += 1
        if students - absentStudents < k :
            return "YES"
    return "YES"

if __name__ == '__main__': 
    

    t = int(input().strip())
    result = []

    for t_itr in range(t):
        first_multiple_input = input().rstrip().split()

        n = int(first_multiple_input[0])

        k = int(first_multiple_input[1])

        a = list(map(int, input().rstrip().split()))

        answer = angryProfessor(k, a)

        result.append(answer)
    for res in result:
        print(res)

    
