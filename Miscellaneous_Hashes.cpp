#include "stdafx.h"
#include "Hashes.h"

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

	Hashes one_way;
	string hashed = one_way.hashWord(msg);

	cout << "Message is '" << string(message) << "';\nMessage hash is " << hashed << endl;

	return 0;
}
