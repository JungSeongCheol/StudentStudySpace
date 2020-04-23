#include <stdio.h>

class Date;
class Time {
	friend void OutToday(Date &, Time &);
private:
	int hour, min, sec;
public:
	Time(int h, int m, int s) : hour(h), min(m), sec(s) {
		if (h >= 0 && h < 24) { hour = h; }
		else { hour = 0; };
		if (m >= 0 && m < 60) { min = m; }
		else { min = 0; };
		if (s >= 0 && s < 60) { sec = s; }
		else { sec = 0; };
	}
};

class Date {
	friend void OutToday(Date&, Time &);
private:
	int year, month, day;
public :
	Date(int y, int m, int d) {
		year = y;
		if (m >= 0 && m <= 12) { month = m; }
		else { month = 0; };
		if (d >= 0 && d <= 31) { day = d; }
		else { month = 0; };
	}
};

void OutToday(Date& d, Time& t) {
	printf("%d년 %d월 %d일 / %d시 %d분 %d초 입니다.\n",
		d.year, d.month, d.day, t.hour, t.min, t.sec);
}

int main()
{
	Date d(2020, 04, 22);
	Time t(15, 37, 40);
	OutToday(d, t);
}