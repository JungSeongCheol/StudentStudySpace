/*
 * PortTest.c
 *
 * Created: 2020-06-12 오후 2:10:29
 * Author : JSC
 */

#include <avr/io.h>

int main(void){
	
	DDRA = 0xFF; // 포트A를 출력으로 설정
	 
	while(1)
	{
		PORTA = 0xFF;	
	}
	return 0;
}
