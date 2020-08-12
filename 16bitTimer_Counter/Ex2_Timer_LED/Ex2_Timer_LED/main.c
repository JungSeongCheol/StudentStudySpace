/*
 * Ex2_Timer_LED.c
 *
 * Created: 2020-06-16 오후 12:17:09
 * Author : JSC
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>

volatile unsigned char LED_Data = 0x00;

int main(void)
{
	DDRC = 0xff;

	TCCR3A = (0<<COM3A1) | (0<<COM3A0); //NORMAL mode
	TCCR3B = (1<<CS02) | (1 <<CS00); //Prescaler 1024 

	TCNT3 = 63356 - (7372800/1024); // 1초마다 한번씩 인터럽트 발생
	ETIMSK = (1<<TOIE3); //타이머3의 오버플로우 인터럽트를 개별적으로 enable
	ETIFR |=1 << TOV3; // TOV3 인터럽트 발생시 1로 세트되면서 오버플로우 인터럽트 발생

	sei();
	while(1){
		PORTC = LED_Data;
	}
	return 0;
}

SIGNAL(TIMER3_OVF_vect){
	cli();

	TCNT3 = 63356 - (7372800/1024);
	LED_Data++;

	if(LED_Data >= 0xff)
		LED_Data = 0;
	sei();
}

