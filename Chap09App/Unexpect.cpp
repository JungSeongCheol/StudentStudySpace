#include <stdio.h>
#include <exception>
using namespace std;

void myunex() {
	puts("�߻��ؼ��� �� �Ǵ� ���� �߻�");
	exit(-2);
}

void calc() throw(int) {
	// ..
	throw "string";	//�������� �ް� �������� ����.
}

int main() {
	set_unexpected(myunex); //set_terminated�� �����ϴ�. gcc������ unexpected�� ����������, visual�� unexpected�� ���������ʴ´�.
	try
	{
		calc();
	}
	catch (int)
	{
		puts("������ ���� �߻�");
	}
	puts("���α׷� ����");
}