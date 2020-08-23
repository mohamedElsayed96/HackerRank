// B. Effective Approach.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
using namespace std;
int main()
{
	long long y = 5000050001;
	cout << y;
	int n;
	int q;
	long  long Vasya = 0;
	long long Petya = 0;
	
	cin >> n;

	int arr[100001];
	
	int x;
	
	for (int i = 0; i < n; i++)
	{
		cin >> x;
		arr[x] = i;
	}
	
	cin >> q;
	int b;
	
	
	for (int i = 0; i < q; i++)
	{
		cin >> b;
		
		Vasya += arr[b] + 1;
	    Petya += (n - (arr[b] + 1) + 1);
	}
	
	cout << Vasya << " " << Petya;
    system("pause");
    return 0;
}
