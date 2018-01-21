#include "stdafx.h"
#include "DualKeyEncryption.h"


DualKeyEncryption::DualKeyEncryption(BigInteger semi_p)
{
	semi_prime = semi_p;
}

/*
* STEP VI:
*/
vector<string> DualKeyEncryption::encodeWord(vector<char> msg, BigInteger key) {
	vector<string> encryption = {};
	int x;
	for (int i = 0; i < msg.size(); i++) {
		// get unicode of this character as x
		x = (int)msg[i];
		// use RSA to encrypt & save in base 16
		encryption.push_back(BigInteger::valueOf(x).pow(key.intValue()).mod(semi_prime).toString(16));
	}

	return encryption;
}

/*
* STEP VII:
*/
string DualKeyEncryption::decodeWord(vector<string> code, BigInteger key) {
	string decryption = "";
	string char_string;
	int c;
	for (int i = 0; i < code.size(); i++) {
		char_string = "";
		// use RSA to decrypt
		c = BigInteger(code[i], 16).pow(key.intValue()).mod(semi_prime).intValue();
		char_string += (char)c;
		decryption += char_string;
	}

	return decryption;
}


DualKeyEncryption::~DualKeyEncryption()
{
}
