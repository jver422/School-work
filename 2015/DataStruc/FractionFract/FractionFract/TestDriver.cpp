#include "fraction.h"
#include <iostream>
using namespace std;
int option;
int n;
void PrintMenu();

int main()
{

	FractionType myfraction;
	PrintMenu();
	cin >> option;


	return 0;
}

void PrintMenu()
{
	cout << "Here are options: " << endl;
	cout << "1. Initialize " << endl;
	cout << "2. Get Numerator: " << endl;
	cout << "3. Get Denominator " << endl;
	cout << "4. is Zero? " << endl;
	cout << "5. is not propper? " << endl;
	cout << "6. convert to propper " << endl;
}
