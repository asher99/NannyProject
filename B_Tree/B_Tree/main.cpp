#include "BTree.h"			// Asher Alexander 206195356 
#include "Volunteer.h"			// & ISrael Dreyfuss 4301288
#include<iostream>
using namespace std;

int main()
{
	list<Volunteer> volunteerList;
	BTree<Volunteer>BT;
	char ch;
	cout << "*" << " Welcome to Voluteers data (BTree) " << "*" << endl;
	cout << "\nChoose one of the following" << endl;
	cout << "n: New volunteer" << endl;
	cout << "c: new event, create a BTree according to distances" << endl;
	cout << "<: print all Volunteers according to order of distances" << endl;
	cout << "f: print N closest Volunteers" << endl;
	cout << "o: event over, delete the BTree" << endl;
	cout << "e: exit:" << endl;
	Volunteer *v;
	cin >> ch;
	while (ch != 'e')
	{
		switch (ch)
		{
		case 'n':v = new Volunteer;
			cout << "Enter volunteers id, name, address, phone number and city" << endl;
			cin >> *v;
			volunteerList.push_back(*v);
			break;
		case 'c':
		{
			list<Volunteer>::iterator it = volunteerList.begin();
			for (; it != volunteerList.end(); it++)
			{
				int d;
				cout << "enter distance for " << (*it).getName() << endl;
				cin >> d;
				(*it).setDistance(d);
				BT.insert(*it);
			}
			break;
		}
		case '<':cout << "BT:" << endl;
			BT.printTree();
			break;
		case 'f': {
			int n;
			cout << "please enter a number " << endl;
			cin >> n;
			BT.printTreeN(n);
			break; }
		case 'o':cout << "event over" << endl;
			BT.deleteTree();
			break;
		default: cout << "error " << endl;  break;
		}
		cout << "enter your choice:\n";
		cin >> ch;
	}
	return 0;
}




////Test BTree for int values
////=============================================================
//#include<iostream> 
////#include"BTree.h"
//using namespace std;
//int main()
//{
//	BTree<int> BT;
//	for (int i = 0; i<15; i++)
//	{
//		int val = rand() % 100;
//		cout << val << ": ";
//		BT.insert(val);
//		BT.printTree();
//		cout << endl;
//	}
//	cout << endl;
//
//	for (int i = 0; i<100; i += 10)
//	{
//		int val = i + 4;
//		if (BT.search(val))
//			cout << val << " exists on in the tree\n";
//		else
//			cout << val << " does not exists on in the tree\n";
//	}
//	cout << "remove 24: ";
//	BT.deleteVal(24);
//	BT.printTree();
//	cout << endl;
//	cout << "remove 62: ";
//	BT.deleteVal(62);
//	BT.printTree();
//	cout << endl;
//	cout << "remove 67: ";
//	BT.deleteVal(67);
//	BT.printTree();
//	cout << endl;
//
//	cout << "print first 5 values: ";
//	BT.printTreeN(5);
//	cout << endl;
//
//	return 0;
//}