#pragma once

#include "BigInteger.h"
#include <string>
#include <vector>

using namespace std;

class DualKeyEncryption
{
public:
	DualKeyEncryption(BigInteger);
	virtual ~DualKeyEncryption();

	vector<string> encodeWord(vector<char>, BigInteger);
	string decodeWord(vector<string>, BigInteger key);

private:
	BigInteger semi_prime;
};

