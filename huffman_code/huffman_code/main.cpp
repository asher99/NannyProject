#include <iostream>
#include <sstream>	// Asher Alexander 206195356
#include <fstream>		// & ISrael Dreyfuss 4301288
#include <queue>
#include <list>
#include <string>
#include <cmath>
#include "Huffman.h"
using namespace std;

int main()
{
	int choice;
	int size = 0;
	string text = "", temptext = "";
	string inputname, outputname;
	int * table = new int[256];		//frequencyTable 
	string kidud[256] = { "" };		//codedTable 
	string binaryCode;
	ifstream inFile;
	ofstream outfile;

	treeHuffman* tree = new treeHuffman();
	//system("color 9f");
	do
	{
		cout << "Please enter 1 to encode a text file\n";
		cout << "Please enter 2 to decode a text file\n";
		cout << "Please enter 3 to exit\n";

		cin >> choice;
		switch (choice)
		{
		case 1:					// encode
			cout << "Enter a text file" << endl;
			cin >> inputname;
			cout << "Enter a name for output file" << endl;
			cin >> outputname;

			//inFile.open(inputname + ".txt");	//open the input file
			if (!inFile.good())
			{
				cout << "Cannot open file\n";
				break;
			}
			tree->encode(inputname + ".txt", outputname + ".txt");
			//
			break;

		case 2:							// decode
			cout << "Enter an encoded file" << endl;
			cin >> inputname;
			cout << "Enter a name for decoded file" << endl;
			cin >> outputname;

			//inFile.open(inputname + ".txt");		//open the input file
			if (!inFile.good())
			{
				cout << "Cannot open file\n";
				break;
			}
			tree->decode(inputname + ".txt", outputname + ".txt");
			break;

		default:
			cout << "no such command!" << endl;
			choice = 3;
			break;

		}
	} while (choice != 3);
}
/*
Please enter 1 to encode a text file
Please enter 2 to decode a text file
Please enter 3 to exit
2
Enter an encoded file
asher
Enter a name for decoded file
sruli
Huffman code:
a: 11
b: 0
c: 100
d: 101
The decoded string is:
adbaabdcbb
Please enter 1 to encode a text file
Please enter 2 to decode a text file
Please enter 3 to exit
3
*/
