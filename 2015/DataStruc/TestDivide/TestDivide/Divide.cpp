/*
Joshua Verner 
9/8/15
divide test plan
*/

#include <iostream>
using namespace std;

void Divide(int a, int b, bool& error, float& result)
{
	if (b == 0){
		error = true;
		result = 0.0f;
	}
	else
	{
		error = false;
		result = a / b;
	}

}

void Print(int a, int b, bool error, float result)
{


}

int main()
{
	bool error;
	float result;
	int dividend = 8;
	int divisor = 0;

	Divide(dividend, divisor, error, result);
	cout << "test 1: " << endl;
	Print(dividend, divisor, error, result);
	divisor = 2;
	Divide(dividend, divisor, error, result);
	cout << "test 2: " << endl;
	Print(dividend, divisor, error, result);
	return 0;
}