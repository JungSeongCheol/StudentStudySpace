/*
 * GccApplication1.c
 *
 * Created: 2020-06-17 오전 9:42:36
 * Author : JSC
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>

unsigned char FND_DATA_TBL[] = {0x3f, 0x06, 0x5b, 0x4f, 0x66, 0x6d, 0x7c,
								0x07, 0x7f, 0x67, 0x77, 0x7c, 0x39, 0x5e,
								0x79, 0x71, 0x08, 0x80};

volatile unsigned char time_s=0;
volatile unsigned char FND_flag = 0, edge_flag = 0;

int main(void)
{
	DDRA = 0xff;
	DDRE = 0x00;
	DDRC = 0xff;
	PORTC = 0x00; //GND길을 만들어줌!!! 따라서 0v여야됨(LED 1개는 자동 GND가 존재), 그러나 4개는 존재하지 않음. 따라서 만들어줄 필요가 존재

	TCCR3A = 0x00;

	TCCR3B = 0x45;
	ETIMSK = 0x20;
	ETIFR |=1 << ICF3;

	sei();
	PORTA = FND_DATA_TBL[0];
	while(1){
		if(FND_flag){
				if(time_s > 15){
					time_s = 15;
			}
			PORTA = FND_DATA_TBL[time_s];
			FND_flag = 0;
		}
	}
	return 0;
}

SIGNAL(TIMER3_CAPT_vect){
	cli();

	unsigned int count_check;

	if(edge_flag == 0){
		TCCR3B = 0x05;
		TCNT3 = 0;
		ICR3 = 0;
		edge_flag = 1;
	}

	else{
		TCCR3B = 0x45;
		count_check = ICR3;

		time_s = count_check/720;
		
		FND_flag = 1;
		edge_flag = 0;
	}
	sei();
}
