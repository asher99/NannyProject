# include "DisjointSets.h"	// Asher Alexander 206195356
# include "Volunteer.h"		// & ISrael Dreyfuss 4301288
int main()
{
	DisjointSets ds;
	Volunteer * v1;
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
		
	}
	system("pause");
}

/*
DISJOINT SETS
Choose one of the following:
n: New volunteer
u: Union of two sets
d: Del a volunteer
p: Print all volunteers
r: Print all representatives
s: Print a specific set
e: exit:
n
Enter volunteers id, name, address, phone number and city
123 Avraham Yaffo 654321 Jerusalem
enter your choice:
n
Enter volunteers id, name, address, phone number and city
456 Yitzchak Aza 987654 TelAviv
enter your choice:
n
Enter volunteers id, name, address, phone number and city
789 Yaakov Elbaz 246873 Hayfa
enter your choice:
n
Enter volunteers id, name, address, phone number and city
147 Sara Shula 352341 Beer7
enter your choice:
p
id = 147 name = Sara address = Shula phone = 352341 city = Beer7
**********
id = 789 name = Yaakov address = Elbaz phone = 246873 city = Hayfa
**********
id = 456 name = Yitzchak address = Aza phone = 987654 city = TelAviv
**********
id = 123 name = Avraham address = Yaffo phone = 654321 city = Jerusalem
**********
enter your choice:
e
Press any key to continue . . .
*/
