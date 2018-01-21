#include "stdafx.h"
#include "SoleKeyEncryption.h"

#include <iostream>

using namespace std;

int main()
{
	char message[] = "merry xmas";
	unsigned i = 0;
	vector<char> msg = {};
	while (message[i] != '\0') {
		msg.push_back(message[i++]);
	}
	msg.shrink_to_fit();

	char key[] = "A5FB17C4D8"; // you might want to avoid zeroes
	i = 0;
	vector<char> k = {};
	while (key[i] != '\0') {
		k.push_back(key[i++]);
	}
	k.shrink_to_fit();

	SoleKeyEncryption go_secure;

	vector<string> encrypted = go_secure.encodeWord(msg, k);
	string disp = "";
	for (string s : encrypted) {
		disp += s + "; ";
	}
	cout << "Message is '" << string(message) << "';\nEncrypted version is " << disp << endl;

	string decrypted = go_secure.decodeWord(encrypted, k);
	cout << "\n\nDecrypted version is '" << decrypted << "'.";

	return 0;
}
