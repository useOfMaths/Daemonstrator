#pragma once

#include "BigInteger.h"
#include <algorithm>
#include <string>
#include <vector>

using namespace std;

class Hashes
{
public:
	Hashes();
	virtual ~Hashes();

	string hashWord(vector<char>);
};

