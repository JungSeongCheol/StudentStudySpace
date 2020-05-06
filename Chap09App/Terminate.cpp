#include <stdio.h>
#include <exception>
#include <stdlib.h>

void myterm() {
	puts("예외 발생");
	exit(-1);
}

int main() {
	set_terminate(myterm);	//try문에는 정수형인 1, catch에는 m으로 에러가 뜬다. 그로 인해 미처리 예외가 존재해 set_terminate를 실행하고, 그 함수인 myterm을 실행시킨다.
	//set_terminate 함수는 미처리 예외시 안의 함수를 호출하는 기능을 한다.
	try
	{
		throw 1;
	}
	catch (char* m)
	{

	}
}