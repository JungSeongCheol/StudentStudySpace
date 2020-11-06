/*
 * EX3_Timer_Clock2.c
 *
 * Created: 2020-06-17 오전 9:16:52
 * Author : JSC
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>

unsigned char FND_DATA_TBL[] = {0x3f, 0x06, 0x5b, 0x4f, 0x66, 0x6d, 0x7c,
								0x07, 0x7f, 0x67, 0x77, 0x7c, 0x39, 0x5e,
								0x79, 0x71, 0x08, 0x80};

volatile unsigned char time_s=0;

int main(void){
	DDRA = 0xff;

	TCCR1A = 0x00;//타이머/카운터 레지스터 1번 and 출력모드 normal포트 동작 /ocna/OCNB/OCNC 분리
	TCCR1B = 0x05;//(1 << CS12) | (0 <<  CS11) |  (1 << CS10)  1024분주(프리스케일) 

	OCR1A = 7372800/1024; //F_CPU / 1024;
	TIMSK = 0x10; //OCIE1A ON - 타이머1의 출력비교 인터럽트 A를 개별적으로 Enable
	TIFR |=1 << OCF1A; //OCF1A 에 1을 넣어둠(

	sei();
	while(1){
		PORTA = FND_DATA_TBL[time_s];
	}
	return 0;
}

SIGNAL(TIMER1_COMPA_vect){
	cli();

	OCR1A += 7372800/1024;
	if(time_s >= 17)
		time_s = 0;
	else
		time_s++;

	sei();
}