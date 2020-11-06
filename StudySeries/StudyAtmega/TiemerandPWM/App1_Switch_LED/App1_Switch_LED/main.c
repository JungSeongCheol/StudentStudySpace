/*
 * App1_Switch_LED.c
 *
 * Created: 2020-06-17 오전 11:35:18
 * Author : JSC
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>

volatile int Light = 0;
volatile unsigned char Light_flag = 1;

int main(void)
{
	DDRB = 0x80;

	DDRE = 0x00;
	DDRD = 0x00;

	TCCR2 = 0x62; // PWM 모드(WGmn1 1, WGMn0, 1) = fast PWM, 010 8분주
	TCNT2 = 0x00; // 카운터 레지스터 2사용, 그것을 0으로

	EICRA = 0xff; // 0~3 INT 11 (상승엣지)
	EICRB = 0xff; // 4~7 INT 11 (상승엣지)

	EIMSK = 0xff; // 0~7 개별 사용
	EIFR = 0xff; // 0~7 플래그

	sei();

    while (1) 
    {
		if (Light_flag)
		{
			OCR2 = Light;
			Light_flag = 0;
			_delay_ms(100);
		}
    }
}

SIGNAL(INT0_vect){
	cli();
	Light = 0;
	Light_flag = 1;
	sei();
}

SIGNAL(INT1_vect){
	cli();
	Light -= 61;
	Light_flag = 1;
	if(Light < 0){
		Light = 0;
		Light_flag = 1;
	}
	sei();
}

SIGNAL(INT2_vect){
	cli();
	Light -= 111;
	Light_flag = 1;
	if(Light < 0){
		Light = 0;
		Light_flag = 1;
	}
	sei();
}
SIGNAL(INT3_vect){
	cli();
	Light -= 161;
	Light_flag = 1;
	if(Light < 0){
		Light = 0;
		Light_flag = 1;
	}
	sei();
}

SIGNAL(INT4_vect){
	cli();
	Light += 61;
	Light_flag = 1;
	if(Light > 255){
		Light = 255;
		Light_flag = 1;
	}
	sei();
}

SIGNAL(INT5_vect){
	cli();
	Light += 111;
	Light_flag = 1;
	if(Light > 255){
		Light = 255;
		Light_flag = 1;
	}
	sei();
}

SIGNAL(INT6_vect){
	cli();
	Light += 161;
	Light_flag = 1;
	if(Light > 255){
		Light = 255;
		Light_flag = 1;
	}
	sei();
}

SIGNAL(INT7_vect){
	cli();
	Light = 255;
	Light_flag = 1;
	sei();
}

