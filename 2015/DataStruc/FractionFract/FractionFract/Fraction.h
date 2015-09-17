/*
	cs217
	Josh Verner
	9/10/15

	EXTEND CLASS TO TAKE NEGATIVE NUMBERS
*/

#include <iostream>

class FractionType
{
public:
	void Initialize(int n, int d);
	//intializes the fraction
	//pre: numerator and denominator are in reduced form
	//post: fraction is initialized

	int GetDenominator();
	//returns the values of the Denominator
	//pre: fraction has been initilized
	//post: numerator is Denominator

	int GetNumerator();
	//returns the values of the numerator
	//pre: fraction has been initilized
	//post: numerator is returned

	bool IsZero();
	//determines if fractionn is zero
	//pre: fraction is initialized
	//post: returns true if numerator is zero, false otherwise

	bool IsNotPropper();
	//
	//pre: fraction is initialized
	//post: returns true if the numerator is >= to the denominator
	int ConvertToPropper();
	//
	//pre: fraction is initialized
	//post: outputs whole number along with reduced fraction

private:
	int numerator;
	int denominator;
};