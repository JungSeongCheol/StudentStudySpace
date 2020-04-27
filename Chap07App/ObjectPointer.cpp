#include <stdio.h>
#include <string.h>

class Human
{
protected:
	char name[12];
	int age;

public:
	Human(const char* aname, int aage) {
		strcpy(name, aname);
		age = aage;
	}
	virtual void intro() {
		printf("이름 = %s, 나이 = %d\n", name, age);
	}
};

class Student : public Human
{
protected:
	int stunum;

public:
	Student(const char* aname, int aage, int astunum) : Human(aname, aage) {
		stunum = astunum;
	}
	void intro() {
		printf("%d학번 %s입니다.\n", stunum, name);
	}
	virtual void study() {
		printf("이이는 사, 이삼은 육, 이사 팔\n");
	}
};

void IntroSomeBody(Human* pH) {
	pH->intro();
}

int main()
{
	Human h("김사람", 10);
	Student s("이학생", 15, 1234567);
	Human* pH;
	Student* pS;

	pH = &h;		// name(김사람), age(10) <= name (김사람), age(10)
	pH->intro();
	pS = &s;		// name(이학생), age(15) <= name (김사람), age(10)
	pS->intro();
	pH = &s;		// name(이학생), age(15) <= name(이학생), age(15), stunum(1234567)
	pH->intro();
	/*pS = &h;*/		// name(김사람), age(10), stunum(???????) <= name(김사람), age(10)

	IntroSomeBody(&h);
	IntroSomeBody(&s);

	pS = (Student*)&h; // stunum쓰레기값이 존재(부모 클래스에는 stnum이 존재 하지 않기 때문에
	//다만, 본인이 원하는 동적 타입을 사용하기위해 virtual을 사용했다면 정상적으로 작동된다.
	pS->intro();

}

