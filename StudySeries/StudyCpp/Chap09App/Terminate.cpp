#include <stdio.h>
#include <exception>
#include <stdlib.h>

void myterm() {
	puts("���� �߻�");
	exit(-1);
}

int main() {
	set_terminate(myterm);	//try������ �������� 1, catch���� m���� ������ ���. �׷� ���� ��ó�� ���ܰ� ������ set_terminate�� �����ϰ�, �� �Լ��� myterm�� �����Ų��.
	//set_terminate �Լ��� ��ó�� ���ܽ� ���� �Լ��� ȣ���ϴ� ����� �Ѵ�.
	try
	{
		throw 1;
	}
	catch (char* m)
	{

	}
}