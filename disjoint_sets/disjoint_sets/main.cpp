#include "disjoint.h"	// Asher Alexander 206195356
#include <iostream>
using namespace std;


int main()
{
	DisjointSets ds;
	Volunteer *v1;
	int id1, id2;
	char ch;
	cout << "\nDISJOINT SETS\n";
	cout << "Choose one of the following:" << endl;
	cout << "n: New volunteer" << endl;
	cout << "u: Union of two sets " << endl;
	cout << "d: Del a volunteer " << endl;
	cout << "p: Print all volunteers " << endl;
	cout << "r: Print all representatives " << endl;
	cout << "s: Print a specific set " << endl;

	cout << "e: exit:" << endl;
	cin >> ch;
	while (ch != 'e')
	{
		try {
			switch (ch)
			{
			case 'n':v1 = new Volunteer;
				cout << "Enter volunteers id, name, address, phone number and city" << endl;
				cin >> *v1;
				ds.makeSet(v1);
				break;
			case 'u':cout << "enter 2 ids ";
				cin >> id1 >> id2;
				ds.unionSets(id1, id2);
				break;
			case 'd':cout << "enter an id ";
				cin >> id1;
				ds.delVolunteer(id1); break;
			case 'p':ds.printAllVolunteers(); break;
			case 'r':ds.printRepresentatives(); break;
			case 's':cout << "enter an id ";
				cin >> id1; ds.printSet(id1);
				break;
			default: cout << "error \n";  break;
			}
		}
		catch (const char* msg)
		{
			cout << msg << endl;
		}
		cout << "enter your choice:\n";
		cin >> ch;
		system("pause");

	}
}
