#include "stdafx.h"
#include "SoleKeyEncryption.h"


SoleKeyEncryption::SoleKeyEncryption()
{
}

vector<string> SoleKeyEncryption::encodeWord(vector<char> msg, vector<char> key) {
	// encoding eqn { Tn = 3^n-1(2t1 + 1) - 1 } - please use your own eqn
	//                        2
	vector<string> encryption = {};
	int n;
	int t1;
	string h;
	stringstream x;
	BigInteger Tn;
	for (int i = 0; i < msg.size(); i++) {
		// get unicode of this character as t1
		t1 = (int) msg[i];
		// get next key digit as n
		h = "";
		h += key[i % (key.size() - 1)];
		x << hex << h;
		x >> n;
		x.clear();
		// use recurrence series equation to encrypt & save in base 16
		Tn = BigInteger::valueOf(3).pow(n - 1).multiply(BigInteger::valueOf(2 * t1 + 1)).subtract(BigInteger::valueOf(1)).divide(BigInteger::valueOf(2));
		encryption.push_back(Tn.toString(16));
	}

	return encryption;
}

string SoleKeyEncryption::decodeWord(vector<string> code, vector<char> key) {
	// encoding eqn { t1 = 3^1-n(2Tn + 1) - 1 } - please use your own eqn
	//                        2
	string decryption = "";
	int n;
	string h;
	stringstream x;
	BigInteger t1;
	BigInteger Tn;
	for (int i = 0; i < code.size(); i++) {
		Tn = BigInteger(code[i], 16);
		// get next key digit as n
		h = "";
		h += key[i % (key.size() - 1)];
		x << hex << h;
		x >> n;
		x.clear();
		// use recurrence series equation to decrypt
		t1 = BigInteger::valueOf(2 * Tn.intValue() + 1).divide(BigInteger::valueOf(3).pow(n - 1)).subtract(BigInteger::valueOf(1)).divide(BigInteger::valueOf(2));
		decryption += (char)t1.intValue();
	}

	return decryption;
}



SoleKeyEncryption::~SoleKeyEncryption()
{
}
