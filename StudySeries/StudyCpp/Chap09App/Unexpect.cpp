#include <stdio.h>
#include <exception>
using namespace std;

void myunex() {
	puts("발생해서는 안 되는 에러 발생");
	exit(-2);
}

void calc() throw(int) {
	// ..
	throw "string";	//정수형을 받고 문자형을 보냄.
}

int main() {
	set_unexpected(myunex); //set_terminated만 가능하다. gcc에서는 unexpected도 가능하지만, visual은 unexpected를 지원하지않는다.
	try
	{
		calc();
	}
	catch (int)
	{
		puts("정수형 예외 발생");
	}
	puts("프로그램 종료");
}