/*
 * Test_LED2.c
 *
 * Created: 2020-06-12 오후 3:52:08
 *  Author: JSC
 */ 

#include <avr/io.h>
#include <util/delay.h>

int main(){
	unsigned char LED_Data = 0x00;
	DDRC = 0x0F;
	while(1){
		PORTC = LED_Data;
		LED_Data++; //1씩 증가 (0x01 0x02 0x03 (0b00000001, 0b00000010 ...))

		//LED_Data값이 0x0F보다 크면 초기화
		if(LED_Data > 0x0F)
			LED_Data = 0;
		_delay_ms(1000);
	}
	return 0;
}