/*
 * Ex1_ADConverter_Right.c
 *
 * Created: 2020-06-16 오후 4:57:36
 * Author : JSC
 */ 

#include <avr/io.h>
#include <util/delay.h>
#include "Lcd.h"

int main(void)
{
	unsigned int AdData = 0;
	char s1[20] = " CDS: ";
	char s2[20];
	LcdInit_4bit();
	DDRA = 0xff;
	DDRC = 0xff;
	DDRF = 0x00; //or 0x02  //PORTF0 == ADC0와 같다. 그러므로 입력으로 사용되어야한다. 
	//출력으로 5v를 조도센서에 입력(CDS_IN)하고 , 조도센서에서 출력(CDS_OUT)해서 나온것을 입력으로 받는다.
	PORTC = 0xFF; //or 0x02 //PORTF

	ADMUX = 0x00; //ADC0 사용한다는것이다.

	ADCSRA = 0x86; //컨버터 프리스케일 사용 64분주비
    while (1) 
    {
		LcdInit_4bit(); //초기화
		ADCSRA |= 0x40; //ADC Start Coversion 을 시작한다.
		while((ADCSRA & 0x10) == 0x00); //ADC Start Coversion 이 끝나면 비트6 즉(0x40이 0x00으로 바뀐다).
		// 또한 ADC Start Coversion이 끝났을때 비트 4가(ADIF가 1로 세트되었다가 다시 0으로 변환됨)	2
		AdData = ADC;
		Lcd_Pos(0,0);
	
		Lcd_STR(" CDS: ");
		Lcd_Pos(0, 7);
		sprintf(s2, "%d%d%d%d\n", (AdData/1000)%10,(AdData/100)%10,(AdData/10)%10,AdData%10);
		Lcd_STR(s2);
		_delay_ms(300);

    }
}

