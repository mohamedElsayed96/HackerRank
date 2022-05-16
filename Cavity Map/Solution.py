#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'cavityMap' function below.
#
# The function is expected to return a STRING_ARRAY.
# The function accepts STRING_ARRAY grid as parameter.
#

def cavityMap(grid):
    data = []
    for row in grid:
        data.append(list(row))
    
    for i in range(1, len(grid) - 1):
        for j in range(1, len(data[i]) - 1):
            if grid[i][j] > grid [i - 1][j] and grid[i][j] > grid[i + 1][j] and grid[i][j] > grid [i][j - 1] and grid[i][j] > grid[i][j + 1]:
                data[i][j] = 'X'
                j+=1
    for i in range(1, len(grid) - 1):
        grid[i] = "".join(data[i])         
    return grid

if __name__ == '__main__':
    n = int(input().strip())

    grid = []

    for _ in range(n):
        grid_item = input()
        grid.append(grid_item)

    result = cavityMap(grid)

    print('\n'.join(result))
   