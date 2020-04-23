#include <stdio.h>

class Time {
private:
	int hour, min, sec;

public:
	Time(int h, int m, int s) {
		SetTime(h, m, s);
	}

	void SetTime(int h, int m, int s){
		hour = h; min = m; sec = s;
	}

	void OutTime() const {
		printf("현재 시간은 %d:%d:%d 입니다.\n", hour, min, sec);
	}
};

int main()
{
	Time now(10, 45, 57);
	now.OutTime();
	now.SetTime(11, 13, 10);
	now.OutTime();

	const Time meeting(16, 00, 00);
	//meeting.SetTime(17,00,00);
	meeting.OutTime();
}

