// A. Young Physicist.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
using namespace std;


int main()
{
	int vectors;
	cin >> vectors;
	int* resultant = new int[3];
	resultant[0] = 0;
	resultant[1] = 0;
	resultant[2] = 0;
	int i = 1;
	while (i <= vectors) {
		int Rx = 0;
		int Ry = 0;
		int RZ = 0;

		cin >> Rx >> Ry >> RZ;

		resultant[0] += Rx;
		resultant[1] += Ry;
		resultant[2] += RZ; 

		++i;
	}
	
	if (resultant[0] == 0 && resultant[1] == 0 && resultant[2] ==0)
	{
		cout << "YES";
	}
	
	else
		cout << "NO";

	system("pause");
	return 0;
}

