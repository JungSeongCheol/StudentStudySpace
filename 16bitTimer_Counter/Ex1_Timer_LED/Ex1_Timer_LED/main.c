/*
 * Ex1_Timer_LED.c
 *
 * Created: 2020-06-16 오전 11:34:20
 * Author : JSC
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>

volatile unsigned char LED_Data = 0x00;
unsigned char timer1Cnt = 0;

int main()
{
	DDRC = 0xfF;

	TCCR1A = 0x00;
	TCCR1B = (1<<CS10); // CS 프리스케일링x (1)

	TCNT1 = 0;
	TIMSK = (1<<TOIE1);
	TIFR |=1 << TOV1;

	sei();
    while (1) 
    {
		PORTC = LED_Data;
    }
	return 0;
}

SIGNAL(TIMER1_OVF_vect){
	cli();

	timer1Cnt++;

	if(timer1Cnt == 112){// 1/(65536/7378200) = 7372800 / 65536 = 112.5
		LED_Data++;

		if(LED_Data >= 0xff)
			LED_Data = 0;

		timer1Cnt=0;
	}
	sei();
}

