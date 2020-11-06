#include <stdio.h>
#include <string.h>

class Human {
private:
	char* aname;
	int age;

public:
	Human(const char* name, int aage) {
		aname = new char[strlen(name) + 1];
		strcpy(aname, name);
		printf("%s ��ü�� �����ڰ� ȣ��Ǿ����ϴ�.\n", aname);
		age = aage;
	}

	~Human() {
		printf("%s ��ü�� �ı��Ǿ����ϴ�.\n", aname);
		delete[] aname;
	}

	void intro() {
		printf("�̸� = %s, ���� = %d\n", aname, this->age);
	}
};

int main() 
{
	Human boy("����ö", 26);
	boy.intro();

	return 0;
}