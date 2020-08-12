/*
 * GccApplication1.c
 *
 * Created: 2020-06-16 오전 9:21:22
 * Author : JSC
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>

volatile unsigned char LED_Data = 0x00;
unsigned int timer0Cnt=0;

SIGNAL(TIMER0_OVF_vect); //Signal 대신 ISR로 사용도 가능

int main(void){
	DDRC = 0xff;

	TCCR0 = 0x06;

	TCNT0 = 256-100;
	TIMSK = 0x01;
	TIFR |=1 << TOV0;

	sei();

	while(1){
		PORTC = LED_Data;
	}
	return 0;

}

SIGNAL(TIMER0_OVF_vect){
	cli();

	TCNT0 = 256-100;
	timer0Cnt++;

	if(timer0Cnt == 288){
		LED_Data++;
		if(LED_Data == 0xff) LED_Data = 0;
		timer0Cnt = 0;
	}
	sei();
}

