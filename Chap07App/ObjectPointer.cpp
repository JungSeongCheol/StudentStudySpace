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
		printf("�̸� = %s, ���� = %d\n", name, age);
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
		printf("%d�й� %s�Դϴ�.\n", stunum, name);
	}
	virtual void study() {
		printf("���̴� ��, �̻��� ��, �̻� ��\n");
	}
};

void IntroSomeBody(Human* pH) {
	pH->intro();
}

int main()
{
	Human h("����", 10);
	Student s("���л�", 15, 1234567);
	Human* pH;
	Student* pS;

	pH = &h;		// name(����), age(10) <= name (����), age(10)
	pH->intro();
	pS = &s;		// name(���л�), age(15) <= name (����), age(10)
	pS->intro();
	pH = &s;		// name(���л�), age(15) <= name(���л�), age(15), stunum(1234567)
	pH->intro();
	/*pS = &h;*/		// name(����), age(10), stunum(???????) <= name(����), age(10)

	IntroSomeBody(&h);
	IntroSomeBody(&s);

	pS = (Student*)&h; // stunum�����Ⱚ�� ����(�θ� Ŭ�������� stnum�� ���� ���� �ʱ� ������
	//�ٸ�, ������ ���ϴ� ���� Ÿ���� ����ϱ����� virtual�� ����ߴٸ� ���������� �۵��ȴ�.
	pS->intro();

}

