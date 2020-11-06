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
		printf("%s 객체의 생성자가 호출되었습니다.\n", aname);
		age = aage;
	}

	~Human() {
		printf("%s 객체가 파괴되었습니다.\n", aname);
		delete[] aname;
	}

	void intro() {
		printf("이름 = %s, 나이 = %d\n", aname, this->age);
	}
};

int main() 
{
	Human boy("정성철", 26);
	boy.intro();

	return 0;
}