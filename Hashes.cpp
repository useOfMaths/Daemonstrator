#include "stdafx.h"
#include "Hashes.h"


Hashes::Hashes()
{
}

string Hashes::hashWord(vector<char> msg) {
	// encoding eqn { Tn = (n-2)t1 + 2^n } - please use your own eqn
	string hash = "";
	BigInteger n;
	BigInteger t1;
	BigInteger x;
	for (int i = 0; i < msg.size(); i++) {
		// get unicode of this character as n
		n = BigInteger::valueOf((int)msg[i]);
		t1 = BigInteger::valueOf(i + 1);
		// use recurrence series equation to hash
		x = n.subtract(BigInteger::valueOf(2)).multiply(t1).add(BigInteger::valueOf(2).pow(n.intValue()));
		if (i == 0) {
			hash = x.toString();
			continue;
		}
		// bitwise rotate left with the modulo of x
		string binary = BigInteger::valueOf(hash).toString(2);
		x = x.mod(BigInteger::valueOf(binary.length()));

		string slice_1 = binary.substr(x.intValue());
		// keep as '1' to preserve hash size
		slice_1[0] = '1';

		string slice_2 = binary.substr(0, x.intValue());

		hash = slice_1 + slice_2;
		hash = BigInteger(hash, 2).toString();
	}
	hash = BigInteger::valueOf(hash).toString(16);
	transform(hash.begin(), hash.end(), hash.begin(), ::toupper);

	return hash;
}


Hashes::~Hashes()
{
}
