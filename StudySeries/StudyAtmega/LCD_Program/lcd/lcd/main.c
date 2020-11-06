/*
 * lcd.c
 *
 * Created: 2020-06-16 오후 2:13:12
 * Author : JSC
 */ 
#include <stdio.h>
#include <avr/io.h>
#include <util/delay.h>
#include "Lcd.h"
#include <avr/interrupt.h>

char i, j;

int main(void)
{
	DDRA = 0xff;
	DDRD = 0x00;
	DDRE = 0x00;

	EICRB = 0xff;
	EICRA = 0xff;

	EIMSK = 0xff;
	EIFR = 0xff;

	sei();
	
	char s1[20];
	char s2[20];

	LcdInit_4bit(); //LCD 초기화

	while(1){
		Lcd_Pos(0, 0);
		Lcd_STR("Press button");

		if(i == 0)
			continue;
		else{
			for(j = 1; j <= 9; j++){
				char k = i;
				LcdInit_4bit();
				if(j > 1){
					strcpy(s2, s1);
					Lcd_Pos(1,0);
					Lcd_STR(s2);
				}
				sprintf(s1, "%d * %d = %d", i, j, j*i);
				Lcd_Pos(0, 0);
				Lcd_STR(s1);
				_delay_ms(500);
				if((i != k) && (i != 1)){
					j = 0;
				}
				if(j == 9){
					Lcd_Pos(1,0);
					LcdInit_4bit();
				}
			}
		}
		i = 0;
	}
}

SIGNAL(INT0_vect){
	cli();
	i=2;
	sei();
}
SIGNAL(INT1_vect){
	cli();
	i=3;
	sei();
}
SIGNAL(INT2_vect){
	cli();
	i=4;
	sei();
}
SIGNAL(INT3_vect){
	cli();
	i=5;
	sei();
}
SIGNAL(INT4_vect){
	cli();
	i=6;
	sei();
}
SIGNAL(INT5_vect){
	cli();
	i=7;
	sei();
}
SIGNAL(INT6_vect){
	cli();
	i=8;
	sei();
}
SIGNAL(INT7_vect){
	cli();
	i=9;
	sei();
}