// Beautiful Matrix.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <math.h>
using namespace std;
int main()
{
	int index_i = 0;
	int index_j = 0;
	for (int i = 1; i <= 5; ++i) 
	{
		for (int j = 1; j <= 5; ++j) 
		{
			int x = 0;
			cin >> x;
			if (x == 1) 
			{
				index_i = i;
				index_j = j;
			}
		}
	}
	int moves = abs(3 - index_i) + abs(3 - index_j);
	cout << moves;
	system("pause");
    return 0;
}

