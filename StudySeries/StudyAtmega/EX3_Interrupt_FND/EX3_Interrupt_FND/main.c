/*
 * EX3_Interrupt_FND.c
 *
 * Created: 2020-06-15 오후 3:23:19
 * Author : JSC
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>

volatile unsigned char Time_STOP = 0;

int main(void){
	unsigned char FND_DATA_TBL [] = {0x3F, 0x06, 0X5B, 0x4F, 0X66, 0X6D, 
									 0X7C, 0X07, 0X7F, 0X67, 0X77, 0X7C,
									 0X39, 0X5E, 0x79, 0x71, 0x08, 0x80};
	unsigned char cnt = 0;
	DDRA = 0xFF;
	DDRE = 0x00;
	EICRB = 0xc0;
	EIMSK = 0x80;
	EIFR = 0x80;
	sei();

	while(1){
		PORTA = FND_DATA_TBL[cnt];
		if(Time_STOP == 0){
			cnt++;
			if(cnt>17) cnt = 0;
		}
		_delay_ms(200);
	}
}

SIGNAL(INT7_vect){
	cli();
	if(Time_STOP == 0){
		Time_STOP = 1;
	}
	else{
		Time_STOP = 0;
	}
	sei();
}