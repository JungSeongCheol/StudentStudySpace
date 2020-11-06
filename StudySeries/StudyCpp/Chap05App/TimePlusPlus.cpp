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

	const Time operator ++(int dummy) { //Const�� ����ϸ� ���� �ٲ��� ���� -> +�� �����ϰ� ���� �ٲܼ� ����.
		Time t = *this;
		++*this;
		return t;
	}
};

int main() {
	Time t1(1, 1, 1);
	Time t2;

	t2 = ++t1; //(++t1).SetTime�� �Ұ�����. const������ ���� ���� �Ұ����ؼ�, �ٸ� (++t1).OutTime���δ� �����ϴ�. 
	t1.outTime();
	t2.outTime();

	t2 = t1++;
	t1.outTime();
	t2.outTime();
}