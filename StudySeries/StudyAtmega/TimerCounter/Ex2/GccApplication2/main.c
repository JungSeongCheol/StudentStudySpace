/*
 * GccApplication2.c
 *
 * Created: 2020-06-15 오후 5:09:41
 * Author : JSC
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>

volatile unsigned char LED_Data = 0x01;
unsigned char timer2Cnt=0, Shift_Flag = 0;

SIGNAL(TIMER2_OVF_vect);

int main(void){
	DDRC = 0xff;

	TCCR2 = 0x05;

	TCNT2 = 256-72;
	TIMSK = 0x40;
	sei();
	TIFR |= 1 << TOV2;
	while(1){
		PORTC = LED_Data;
	}
	return 0;
}

SIGNAL(TIMER2_OVF_vect){
	cli();
	TCNT2 = 256 - 72;
	timer2Cnt++;
	if(timer2Cnt == 50){
		if(Shift_Flag == 0){
			LED_Data <<= 1;
			if(LED_Data == 0x80){
				Shift_Flag = 1;
			}
		}
		else{
			LED_Data >>= 1;
			if(LED_Data == 0x01){
				Shift_Flag = 0;
			}
		}
		timer2Cnt=0;
	}
	sei();
}

