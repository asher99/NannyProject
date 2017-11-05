#pragma once

class Volunteer
{
public:
	int id;
	string name;
	string address;
	int phoneNum;
	string town;
	Volunteer();
	Volunteer(const Volunteer &);


};
class DisjointSets
{

};
class DisNode
{
	Volunteer * volunteer;
};
class Representor :public DisNode
{

};
