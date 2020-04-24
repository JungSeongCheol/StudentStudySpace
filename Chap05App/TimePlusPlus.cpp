#include <stdio.h>

class Time {
private:
	int hour, min, sec;

public:
	Time() { ; }
	Time(int h, int m, int s) { hour = h; min = m; sec = s; }

	void outTime() {
		printf("%d:%d:%d\n", hour, min, sec);
	}
	const Time operator ++() {
		*this;
		sec++;
		min += sec / 60;
		sec %= 60;
		hour += min / 60;
		min %= 60;
		return *this;
	}

	const Time operator ++(int dummy) { //Const를 사용하면 값이 바뀌지 않음 -> +를 수행하고 값을 바꿀수 없다.
		Time t = *this;
		++*this;
		return t;
	}
};

int main() {
	Time t1(1, 1, 1);
	Time t2;

	t2 = ++t1; //(++t1).SetTime은 불가능함. const떄문에 값을 변경 불가능해서, 다만 (++t1).OutTime으로는 가능하다. 
	t1.outTime();
	t2.outTime();

	t2 = t1++;
	t1.outTime();
	t2.outTime();
}