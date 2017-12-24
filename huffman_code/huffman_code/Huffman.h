#pragma once
#include <string>	// Asher Alexander 206195356
#include <vector>		// & ISrael Dreyfuss 4301288
#include <queue>
#include <iostream>
#include <sstream>
#include <fstream>
#include <queue>
#include <list>
#include <string>
#include <cmath>

using namespace std;

class HuffmanNode
{
public:
	string str;
	int frequency;
	HuffmanNode * left;
	HuffmanNode * right;
	// ctor
	HuffmanNode(string word, int freq, HuffmanNode * first, HuffmanNode * second) // CTOR
	{
		str = word;
		frequency = freq;
		left = first;
		right = second;
	}

	HuffmanNode() :str(""), frequency(0), left(NULL), right(NULL) {} // default ctor 

	friend class compareNode;

};
class compareNode
{
public:
	bool operator()(HuffmanNode* const & n1, HuffmanNode* const & n2)
	{
		return n1->frequency > n2->frequency;
	}
};
class treeHuffman
{
public:
	priority_queue<HuffmanNode*, vector<HuffmanNode*>, compareNode> pQueue;

	treeHuffman() {}

	void encode(string sourceFileName, string destFileName)
	{
		string stringOfFile = "", FrequencyStr = "", CodedTreeStr = "";
		char * letters = new char[256]{ "" };
		string * codedTable = new string[256]{ "" };	//coded letters
		int counter = 0, p = 0, codeLen = 0;
		double x;
		int BT2 = 0;
		string codedMessage;

		ifstream source(sourceFileName);
		source >> stringOfFile;
		source.close();

		int* frequency = buildTable(stringOfFile);

		buildTree(frequency, 256);	//tree is pqueue
		buildTableCode(codedTable);

		for (int i = 0, j = 0; i < 256; i++)
		{
			if (frequency[i] != 0)
			{
				letters[j++] = (char)i;
				counter++;
			}
		}

		cout << "Huffman code:\n";//  prints each word and  its freq
		for (int i = 0; i < 256; i++)
			if (codedTable[i] != "")
			{
				cout << (char)i << " : " << codedTable[i] << endl;
				BT2 += frequency[i] * codedTable[i].length();

			}

		x = log10(counter) / log10(2);
		codeLen = (x > (int)x) ? x + 1 : x;

		cout << "In the fixed - length code, the number of bits needed per character: " << codeLen << endl;
		cout << "Encoding in fixed - length code requires " << codeLen * stringOfFile.length() << " bits.\n";
		cout << "Encoding in Huffman code requires " << BT2 << " bits.\n";
		cout << "The encoded string is :\n";

		cout << counter << endl;

		FrequencyStr = PrintTreeInOrder(pQueue.top(), "");
		cout << FrequencyStr << endl;

		CodedTreeStr = PrintCodedTree(pQueue.top(), "");
		cout << CodedTreeStr << endl;

		for (int i = 0; i < stringOfFile.length(); i++)
		{
			codedMessage += codedTable[(stringOfFile[i])];
		}

		cout << codedMessage;
		cout << endl;
		cout << endl;

		ofstream f1(destFileName); // writes into file we got from user
		if (!f1)
		{
			cout << "Cannot open file to write.\n";
			return;
		}
		f1 << counter << "\n" << FrequencyStr << "\n"
			<< CodedTreeStr << "\n" << codedMessage << "\n";

		f1.close();

	}

	void decode(string sourceFileName, string destFileName)
	{
		string stringOfFile = "", Characters = "", CodedTree = "", CodedText = "";
		string decodedMessage;
		int NumberOfChars;

		ifstream source(sourceFileName);
		source >> NumberOfChars;
		source >> Characters;
		source >> CodedTree;
		source >> CodedText;

		source.close();
		HuffmanNode * QueueTree = new HuffmanNode();
		string * codedTable = new string[256]{ "" };	//coded letters

		RebuildFrequencyTable(QueueTree, CodedTree, Characters, codedTable, "");//In Queue Tree is the decoded tree 


																				// outputs
		cout << "Huffman code:" << endl;
		for (int i = 0; i < 256; i++)		// each letter and its code
		{
			if (codedTable[i] != "")
			{
				cout << (char)i << ": " << codedTable[i] << endl;
			}
		}

		for (int i = 0; i < CodedText.length(); i++) // decodes the coded message into letters
		{
			for (int j = 0; j < 256; j++) // array of ASCII
			{
				if (CodedText[i] == codedTable[j][0] && codedTable[j] != "") 
				{
					int tempIndex = i+1;
					bool flag = true;
					for (int k = 1; k < codedTable[j].length() && flag == true; k++)
					{
						if (CodedText[tempIndex] == codedTable[j][k]) // if the code of a letter matches the string
							tempIndex++;
						else
							flag = false;
					}
					if (flag) //if we found a intire letter code that matches our seqence of code
					{
						decodedMessage += (char)j;
						i = tempIndex;
						j = 0;
					}
				}
			}

		}
		cout << "The decoded string is: " << endl; // prints the decoded message
		cout << decodedMessage << endl;

		ofstream outfile;
		outfile.open(destFileName); // inserts the decoded message into file
		if (outfile.is_open())
		{
			outfile << decodedMessage << endl;
			outfile.close();
		}
		else
			cout << "Cannot open file to write.\n";
	}

	void RebuildFrequencyTable(HuffmanNode *tree, string &CodedTreeStr, string& CharStr, string *codedTable, string Code)
	{
		if (CodedTreeStr[0] == '1')
		{
			tree->left = NULL;
			tree->right = NULL;
			tree->str = CharStr[0];
			CharStr = (CharStr.substr(1));
			CodedTreeStr = (CodedTreeStr.substr(1));
			codedTable[(int)(tree->str[0])] = Code;
			return;
		}
		tree->left = new HuffmanNode();
		tree->right = new HuffmanNode();
		tree->str = "?";
		CodedTreeStr = (CodedTreeStr.substr(1));
		RebuildFrequencyTable(tree->left, CodedTreeStr, CharStr, codedTable, Code + "0");
		RebuildFrequencyTable(tree->right, CodedTreeStr, CharStr, codedTable, Code + "1");
		return;

	}

	string PrintCodedTree(HuffmanNode* tempnode, string tempStr)
	{
		if (tempnode == NULL)
			return "";
		if (tempnode->left == NULL&&tempnode->right == NULL)
			return "1";
		if (tempnode->left != NULL)
			tempStr += "0" + PrintCodedTree(tempnode->left, "");
		if (tempnode->right != NULL)
			tempStr += PrintCodedTree(tempnode->right, "");
		return tempStr;
	}

	string PrintTreeInOrder(HuffmanNode* node, string tempstr)
	{
		if (node == NULL)
			return "";
		if (node->left == NULL&&node->right == NULL)
			return node->str;
		if (node->left != NULL)
			tempstr += PrintTreeInOrder(node->left, "");
		if (node->right != NULL)
			tempstr += PrintTreeInOrder(node->right, "");
		return tempstr;
	}

	int* buildTable(string text) //build frequency table 
	{
		int * frequencyTableTemp = new int[256]{ 0 };
		for (int i = 0; i < text.length(); i++)
		{
			frequencyTableTemp[(int)(text[i])]++;
		}
		return frequencyTableTemp;
	}

	void buildTree(int* frequencyTable, int size)	//bulding the huffman tree using a priority queue
	{
		buildPriorityQueueHelp(frequencyTable, size);
		HuffmanNode* combined, *first, *second;
		while (pQueue.size() >= 2)
		{
			first = pQueue.top();
			pQueue.pop();
			second = pQueue.top();
			pQueue.pop();
			combined = new HuffmanNode("?", first->frequency + second->frequency, first, second);
			pQueue.push(combined);
		}
	}

	void buildPriorityQueueHelp(int* frequencyTable, int size)//build Priority Queue 
	{
		HuffmanNode * temp;
		for (int i = 0; i < size; i++)
		{
			if (frequencyTable[i] != 0)
			{
				string str(1, (char)(i));
				temp = new HuffmanNode(str, frequencyTable[i], NULL, NULL);
				pQueue.push(temp);
			}
		}
	}

	void buildTableCode(string *kidud)
	{
		buildTableCodehelp(kidud, pQueue.top(), "");
	}

	void buildTableCodehelp(string kidud[], HuffmanNode *temp, string tempStr)//function Help
	{
		if (temp->left == NULL&&temp->right == NULL)
			kidud[(int)((temp->str)[0])] = tempStr;

		if (temp->left != NULL)
			buildTableCodehelp(kidud, temp->left, tempStr + "0");

		if (temp->right != NULL)
			buildTableCodehelp(kidud, temp->right, tempStr + "1");
	}
};



