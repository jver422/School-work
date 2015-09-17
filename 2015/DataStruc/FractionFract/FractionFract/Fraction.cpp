
#include "Fraction.h"

void FractionType::Initialize(int n, int d)
{
	numerator = n;
	denominator = d;

}

int FractionType::GetNumerator()
{
	return numerator;
}

int FractionType::GetDenominator()
{
	return denominator;
}

bool FractionType::IsZero()
{
	if (GetNumerator() == 0)
		return true;
	else
		return false;
}

bool FractionType::IsNotPropper()
{
	if (GetNumerator() >= GetDenominator())
		return true;
	else
		return false;
}

int FractionType::ConvertToPropper()
{

}

