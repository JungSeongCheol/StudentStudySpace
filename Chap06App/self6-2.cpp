#include <stdio.h>
#include <string.h>

class Date {
private:
	int year, month, day;
public:
	Date(int y, int m, int d) : year(y), month(m), day(d) { ; }

	void outDate() {
		printf("%d/%d/%d", year, month, day);
	}
};
class Human {
private:
	char name[12];
	int age;
	Date birth;
public:
	Human(const char* aname, int aage, 
		int y, int m, int d) : birth(y, m, d) {
		strcpy(name, aname);
		age = aage;
	}

	void intro() {
		printf("이름 = %s, 나이 %d\n", name, age);
		printf("생일 = ");
		birth.outDate();
		printf("\n");
	}

};


int main() {
	Human Jung = { "정성철", 26, 1995, 1, 16 };
	Jung.intro();
}