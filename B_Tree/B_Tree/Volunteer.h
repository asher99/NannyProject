#pragma once
#include <iostream>	// Asher Alexander 206195356 
#include <string>	// & ISrael Dreyfuss 4301288
using namespace std;

class Volunteer
{
private:
	int id;
	string name;
	string address;
	int phoneNumber;
	string city;
	int distance;

public:

	Volunteer() {}
	~Volunteer() {}
	Volunteer(const Volunteer& other) : id(other.id), name(other.name), address(other.address),
		phoneNumber(other.phoneNumber), city(other.city), distance(other.distance) {}

	void setDistance(int d) { distance = d; }
	int getDistance() { return distance; }

	//		operators
	bool operator==(Volunteer v) { return distance == v.distance; }
	bool operator!=(Volunteer v) { return distance != v.distance; }
	bool operator<(Volunteer v) { return distance < v.distance; }
	bool operator>(Volunteer v) { return distance > v.distance; }
	bool operator<=(Volunteer v) { return distance <= v.distance; }
	bool operator>=(Volunteer v) { return distance >= v.distance; }

	friend ostream& operator<<(ostream& os, Volunteer& v);
	friend istream& operator >> (istream &is, Volunteer & v);

	int getId() { return id; }
	string getName() { return name; }

};

istream& operator >> (istream &is, Volunteer & v)
{
	is >> v.id;
	is >> v.name;
	is >> v.address;
	is >> v.phoneNumber;
	is >> v.city;
	return is;
}
ostream& operator<<(ostream& os, Volunteer& v)
{
	os << "id= " << v.id << " name= " << v.name
		<< " address= " << v.address << " phone= "
		<< v.phoneNumber << " city= " << v.city << " distance=" << v.distance << "\n";
	return os;
}