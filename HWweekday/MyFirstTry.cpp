#include <iostream>
using namespace std;
/*
* The requestion:
* enumeration type weekday(7)
* declare a variable of the weekday type and assign it a value.
* declare an int-type variable.
* see if we can assign it with the value of the weekday-type variable.
*/
int main() {
	//declare the weekday type and a variable of this type:
	enum weekday{sunday,monday,tuesday,wednesday = 2,thursday,friday,saturday} m,w,f;
	//assign the variables:
	m = monday;
	w = wednesday;
	f = friday;
	//declare an int-type variable:
	int i;
	//assign it:
	i = w;
	//see the value:
	cout << "The value of m is:" << m << endl;
	cout << "The value of w is:" << w << endl;
	cout << "The value of i is:" << i << endl;
	cout << "The value of f is:" << f << endl;
	return 0;
}