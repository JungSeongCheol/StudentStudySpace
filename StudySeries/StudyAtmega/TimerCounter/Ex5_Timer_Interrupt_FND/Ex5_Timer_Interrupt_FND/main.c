/*
 * Ex5_Timer_Interrupt_FND.c
 *
 * Created: 2020-06-16 오전 10:17:20
 * Author : JSC
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>

unsigned char FND_DATA_TBL[] = {0x3F, 0x06, 0x5b, 0x4f, 0x66, 0x6d, 0x7c,
								0x07, 0x7f, 0x67, 0x77, 0x7c, 0x39, 0x5e,
								0x79, 0x71, 0x08, 0x80};

volatile unsigned char time_s = 0;
volatile unsigned char Time_STOP = 0;

unsigned char timer0Cnt = 0;

int main(void)
{
	DDRA = 0xff;
	DDRE = 0x00;

	TCCR2 = (1<<CS22) | (1<<CS20); //프리스케일러 1024, 일반모드
	OCR2 = 72;
	TIMSK = (1<<OCIE2);
	TIFR |=1 << OCF2;

	EICRB = (1<<ISC41) | (1<<ISC40);
	EIMSK = (1<<INT4);
	EIFR |= (1 << INTF4);

	sei();

	while(1){
		PORTA = FND_DATA_TBL[time_s];
	}
    return 0;
}

SIGNAL(TIMER2_COMP_vect){
	cli();
	OCR2 += 72;
	timer0Cnt++;
	if(timer0Cnt == 50){
		if(Time_STOP == 0){
			if(time_s >= 16)
				time_s = 0;
			else
				time_s++;
		}
		timer0Cnt = 0;
	}
	sei();
}

SIGNAL(INT4_vect){
	cli();
	if(Time_STOP == 0)
		Time_STOP = 1;
	else
		Time_STOP = 0;

	sei();
}
