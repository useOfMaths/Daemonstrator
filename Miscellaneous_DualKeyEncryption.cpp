#include "stdafx.h"
#include "BigInteger.h"
#include "LCM.h"
#include "DualKeyEncryption.h"

#include <iostream>

using namespace std;

int main() {
	/*
	* STEP I:
	*/
	unsigned p1 = 101; // 1st prime
	unsigned p2 = 401; // 2nd prime
					   /*
					   * STEP II:
					   */
	BigInteger semi_prime(p1 * p2);

	/*
	* STEP III:
	*/
	// get L.C.M. of p1-1 and p2-1
	LCM l_c_m({ p1 - 1, p2 - 1 });
	int lcm = l_c_m.getLCM();

	/*
	* STEP IV:
	*/
	// pick a random prime (public_key) that lies
	// between 1 and LCM but not a factor of LCM
	BigInteger public_key(313);

	// find 'public_key' complement - private_key - such that
	// (public_key * private_key) % LCM = 1
	//this involves some measure of trial and error
	int i = 1;
	while ((lcm * i + 1) % public_key.intValue() != 0) {
		i++;
	}
	/*
	* STEP V:
	*/
	BigInteger private_key;
	private_key = BigInteger::valueOf(i * lcm + 1).divide(public_key);

	char message[] = "merry xmas";
	i = 0;
	vector<char> msg = {};
	while (message[i] != '\0') {
		msg.push_back(message[i++]);
	}
	msg.shrink_to_fit();

	DualKeyEncryption go_secure(semi_prime);

	vector<string> encrypted = go_secure.encodeWord(msg, public_key);
	string disp = "";
	for (string s : encrypted) {
		disp += s + "; ";
	}
	cout << "Message is '" << string(message) << "';\nEncrypted version is " << disp << endl;

	string decrypted = go_secure.decodeWord(encrypted, private_key);
	cout << "\n\nDecrypted version is '" << decrypted << "'.";

	return 0;
}
