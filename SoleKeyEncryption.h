#pragma once

#include "BigInteger.h"
#include <string>
#include <vector>

using namespace std;

class SoleKeyEncryption
{
public:
	SoleKeyEncryption();
	virtual ~SoleKeyEncryption();

	vector<string> encodeWord(vector<char>, vector<char>);
	string decodeWord(vector<string>, vector<char>);
};

