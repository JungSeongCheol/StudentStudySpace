#include <stdio.h>
#include <iostream>
using namespace std;

class Time {
	friend ostream& operator << (ostream& c, const Time& T);
	friend ostream& operator << (ostream& c, const Time* pT);
private:
	int hour, min, sec;

public:
	Time(int h, int m, int s) {
		hour = h; min = m; sec = s;
	}

	void outTime() const {
		printf("%d:%d:%d", hour, min, sec);
	}
};

ostream& operator << (ostream& c, const Time& T) {
	c << T.hour << ":" << T.min << ":" << T.sec;
	return c;
}

ostream& operator << (ostream& c, const Time* pT) {
	c << *pT;
	return c;
}

int main() {
	Time now(10, 22, 5);
	Time* pLunchTime = new Time(12, 30, 0);

	cout << "���� �ð��� " << now << endl;
	cout << "���� �ð��� " << pLunchTime << endl;

	delete pLunchTime;
}