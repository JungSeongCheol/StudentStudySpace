/*
 * EX4_Interrupt_FND_LED.c
 *
 * Created: 2020-06-15 오후 3:44:51
 * Author : JSC
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>

volatile unsigned char Time_STOP = 0; //volatile - 임시저장소가 아닌, 램에 저장되서 불러옴
volatile unsigned char cnt = 0;

int main(void){
	unsigned char FND_DATA_TBL []={0x3F, 0x06, 0x5b, 0x4F, 0x66, 0x6d,
								   0x7c, 0x07, 0x7f, 0x67, 0x77, 0x7c,
								   0x39, 0x5e, 0x79, 0x71, 0x08, 0x80};
	DDRA = 0xff;
	DDRD = 0x00;

	EICRA = 0xC2;
	EIMSK = 0x09;
	EIFR = 0x09;
	sei();

	while(1){
		PORTA = FND_DATA_TBL[cnt];
		if(Time_STOP == 0){
			cnt++;
			if(cnt>17) cnt = 0;
		}
		_delay_ms(500);
	}
}

SIGNAL(INT0_vect){
	cli();

	Time_STOP = 1;
	cnt = 0;

	sei();
}

SIGNAL(INT4_vect){
	cli();

	Time_STOP = 0;

	sei();
}