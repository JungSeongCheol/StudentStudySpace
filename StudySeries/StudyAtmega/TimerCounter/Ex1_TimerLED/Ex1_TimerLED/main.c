/*
 * Ex1_TimerLED.c
 *
 * Created: 2020-06-15 오후 4:52:50
 * Author : JSC
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>

volatile unsigned char LED_Data = 0x00;
unsigned char timer0Cnt = 0;
SIGNAL(TIMER0_OVF_vect);

int main(void){
	DDRC = 0xFF;
	TCCR0 = 0x07;
	TCNT0 = 0xFF - 40;

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
	TCNT0 = 0xFF - 40;
	timer0Cnt++;
	if(timer0Cnt == 100){
		LED_Data++;
		if(LED_Data > 0xFF)
			timer0Cnt = 0;
	}
	sei();
}