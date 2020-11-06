/*
 * Ex1_External_Interrupt.c
 *
 * Created: 2020-06-15 오후 2:13:21
 * Author : JSC
 */ 

#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>

volatile unsigned char Time_STOP = 0;

int main(void){
	
	unsigned char LED_Data = 0x01;
	DDRA = 0xff;
	DDRE = 0x00;
	EICRB = 0x03; //상승엣지 (4번의 상성엣지)
	EIMSK = 0x10; // 인터럽트 4허용
	EIFR = 0x10; // 인터럽트 4 플래그 클리어
	sei();

	while(1){
		PORTA = LED_Data;
		if(Time_STOP == 0 )
		{
			if(LED_Data == 0x80)
				LED_Data = 0x01;
			else LED_Data <<= 1;
		}
		_delay_ms(100);
	}
	return 0;
}

SIGNAL(INT4_vect){
	cli();
	if(Time_STOP == 0){
		Time_STOP = 1;
	}
	else{
		Time_STOP = 0;
	}
	sei();
}

