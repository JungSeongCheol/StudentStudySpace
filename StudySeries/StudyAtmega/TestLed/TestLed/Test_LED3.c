/*
 * Test_LED3.c
 *
 * Created: 2020-06-12 오후 4:43:24
 *  Author: JSC
 */ 

#include <avr/io.h>
#include <util/delay.h>

int main(){
	unsigned char LED_Data = 0x01, i;
	DDRC = 0xFF;
	while(1){
		LED_Data = 0x01;
		for (i = 0; i < 8; i++)
		{
			PORTC = LED_Data;
			if(LED_Data == 0x80)
				LED_Data = 0x80;
			else
				LED_Data <<= 1;
			_delay_ms(1000);
		}

		for (i = 0; i < 8; i++)
		{
			PORTC = LED_Data;
			LED_Data >>= 1;
			_delay_ms(1000);
		}
	}
	return 0;
}
