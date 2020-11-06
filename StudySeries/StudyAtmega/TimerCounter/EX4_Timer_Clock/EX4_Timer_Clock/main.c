/*
 * EX4_Timer_Clock.c
 *
 * Created: 2020-06-16 오전 9:41:53
 * Author : JSC
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>

unsigned char FND_Data_TBL [] = {0x3f, 0x06, 0x5b, 0x4f, 0x66, 0x6d, 0x7c,
								 0x07, 0x7f, 0x67, 0x77, 0x7c, 0x39, 0x5e,
								 0x79, 0x71, 0x08, 0x80};

volatile unsigned char time_s=0;
unsigned char timer0cnt = 0;

SIGNAL(TIMER0_COMP_vect);
int main(void){
	DDRA = 0xff;

	TCCR0 = 0x07;
	OCR0 = 72;
	TIMSK = 0x02;
	TIFR |=1 << OCF0;

	sei();

	while(1){
		PORTA = FND_Data_TBL[time_s];
	}
	return 0;
}

SIGNAL(TIMER0_COMP_vect){
	cli();
	OCR0 += 72;
	timer0cnt++;

	if(timer0cnt == 100){
		if(time_s >= 16)
			time_s = 0;
		else time_s++;
			timer0cnt=0;
	}
	sei();

}
