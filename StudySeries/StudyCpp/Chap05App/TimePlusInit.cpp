#include <stdio.h>

class Time {
	friend const Time operator +(const Time& me, const Time& other);
	friend const Time operator *(const Time& me, const Time& other);
private:
	int hour, min, sec;

public:
	Time() { ; }
	Time(int h, int m, int s) { hour = h; min = m; sec = s; }

	void outTime() {
		printf("%d:%d:%d\n", hour, min, sec);
	}

	const Time operator +(const int s) const {
		Time t = *this;

		t.sec += s;

		t.min += t.sec / 60;
		t.sec %= 60;
		t.hour += t.min / 60;
		t.min %= 60;
		return t;
	}

	const Time operator *(const int s) const {
		Time t = *this;
		int tsec = t.hour * 3600 + t.min * 60 + t.sec;

		tsec *= s;

		t.hour = tsec / 3600;
		t.min = (tsec / 60) % 60;
		t.sec = tsec % 60;

		return t;

	}

	//const Time operator +(const Time& other) const{
	//Time t;

	//	t.min += t.sec / 60;
	//	t.sec %= 60;
	//	t.hour += t.min / 60;
	//	t.min %= 60;
	//	return t;
	//}
};

//const Time operator +(const int s, const Time& me) {
//	Time t = me;
//	
//	t.sec += s;
//
//	t.min += t.sec / 60;
//	t.sec %= 60;
//	t.hour += t.min / 60;
//	t.min %= 60;
//	return t;
//}

const Time operator +(const Time& me, const Time& other) {
	Time t;
	t.sec = me.sec + other.sec;
	t.min = me.min + other.min;
	t.hour = me.hour + other.hour;

	t.min += t.sec / 60;
	t.sec %= 60;
	t.hour += t.min / 60;
	t.min %= 60;
	return t;
}

const Time operator *(const Time& me, const Time& other) {
	Time t;
	t.sec = me.sec * other.sec;
	t.min = me.min * other.min;
	t.hour = me.hour * other.hour;

	t.min += t.sec / 60;
	t.sec %= 60;
	t.hour += t.min / 60;
	t.min %= 60;
	return t;
}

int main() {
	Time t1(1, 40, 32);
	t1.outTime();
	Time t2(2, 21, 33);
	t2.outTime();
	Time t3;

	t3 = t1 + t2; // +(t1, t2);
	t3.outTime();

	Time now(11,22,33);
	//now = 360 + now;
	//now.outTime();

	now.outTime();
	
	now = now + 1;
	now.outTime();

	printf("°ö¼À\n");
	now = now * 3;
	now.outTime();
	
	t3 = t1 * t2;
	t3.outTime();
	
};