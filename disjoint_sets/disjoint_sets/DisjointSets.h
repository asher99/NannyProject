#pragma once
#include <iostream> // Asher Alexander 206195356
#include <list>		// & ISrael Dreyfuss 4301288
#include "Volunteer.h"
#include <map>
using namespace std;
class DisjointSets
{
public:
	class DisNode
	{
	public:
		Volunteer * volunteer;
		DisNode* head;
		DisNode* next;


		DisNode(Volunteer * temp)
		{
			this->volunteer = temp;
			this->head = this;
			this->next = NULL;
		}

		virtual ~DisNode()
		{
			if (!volunteer)
				return;
			delete volunteer;
			delete next;
			delete head;
			volunteer = NULL;
			next = head = NULL;

		}
		DisNode * getHead() { return head; }
	};
	class Representor :public DisNode
	{
	public:
		DisNode* last;
		int length;

		Representor(Volunteer* team) :DisNode(team) { length = 0; }

		void operator+=(Representor& p)
		{
			DisNode * temp = p.head;
			this->last->next = p.head;
			this->last = p.last;
			temp->head = this->head;
			while (temp->next)
			{
				temp->head = this->head;
				temp = p.next;
			}
			temp->head = this->head;
			length += p.length;
		}
		
	};

public:
	list<Representor*> listOfRepr;
	map<int, DisNode*> idmap;
	DisjointSets()
	{
		//listOfRepr = new list<Representor*>;
		listOfRepr.clear();
	}
	~DisjointSets() {}
	void makeSet(Volunteer* t);
	Representor * findSet(int id);
	void unionSets(int, int);
	void printSet(int);
	void delVolunteer(int);
	void printRepresentatives();
	void printAllVolunteers();
};

void DisjointSets::makeSet(Volunteer* v)
{
	Representor* temp = new Representor(v);
	temp->head = temp;
	temp->length = 1;
	temp->last = temp;
	temp->next = NULL;

	listOfRepr.push_back(temp);
	idmap.insert(std::pair<int, DisNode*>(v->getId(), temp));
}
DisjointSets::Representor* DisjointSets::findSet(int id)
{
	DisNode* temp = idmap[id];
	if (!temp)
	{
		throw "no such volunteer";
	}

	return (Representor*)temp->head;
}

void DisjointSets::unionSets(int id1, int id2)
{
	Representor * v1 = findSet(id1);
	Representor * v2 = findSet(id2);

	if (v1->head == v2->head)
		return;
	if (v1->length > v2->length)
	{
		(*v1) += (*v2);

		listOfRepr.remove(v2);
	}
	else
	{
		(*v2) += (*v1);
		listOfRepr.remove(v1);
	}


}

void DisjointSets::delVolunteer(int id)
{
	DisNode * temp = idmap[id];
	if (!temp)
		throw "no such volunteer";
	Representor * v = findSet(id);
	Representor * vtemp = v;
	if ((Representor*)temp == v)
	{
		if (v->length == 1)
		{
			idmap.erase(id);
			listOfRepr.remove(v);
			return;
		}
		int tempLength = v->length;
		v->length = tempLength - 1;
		v = (Representor*)v->next;
		listOfRepr.pop_front();
		idmap.erase(id);
		return;
	}

	v->length--;
	while (v->next != temp)
	{
		v = (Representor*)v->next;
	}
	v->next = temp->next;

	if (vtemp->last == temp)
	{
		vtemp->last = v;
	}
	temp->head = NULL;
	temp->next = NULL;
	delete temp;
	idmap.erase(id);

}

void DisjointSets::printSet(int id) // prints the group that includes the id given
{
	Representor* temp = findSet(id);
	while (temp)
	{
		cout << *(temp->volunteer);
		temp = (Representor*)temp->next;
	}

}

void DisjointSets::printRepresentatives() // prints Representatives of all groups
{
	for (list<Representor*>::iterator it = listOfRepr.begin(); it != listOfRepr.end(); it++)
	{
		cout << *((*it)->volunteer);
	}
}

void DisjointSets::printAllVolunteers() // prints All Volunteers ...
{
	for (list<Representor*>::iterator it = listOfRepr.begin(); it != listOfRepr.end(); it++)
	{
		Representor* temp = (Representor*)(*it)->head;
		while (temp)
		{
			cout << *(temp->volunteer);
			temp = (Representor*)temp->next;
		}
		cout << "**********" << endl;
	}
}


