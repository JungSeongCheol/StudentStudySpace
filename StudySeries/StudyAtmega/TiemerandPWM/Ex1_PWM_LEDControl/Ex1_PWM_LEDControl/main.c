/*
 * Ex1_PWM_LEDControl.c
 *
 * Created: 2020-06-17 오전 11:21:59
 * Author : JSC
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>

int main(void)
{
	unsigned char Light = 0;

	DDRB = 0x10; //4번핀 사용

	TCCR0 = 0x77; //ComnA FOCn = 1 (출력 비교 실시1) 사용 111 (1024분주비)
	TCNT0 = 0x00; //타이머0 카운터를 초기화
	while (1) 
    {
		for(Light =0 ; Light < 255; Light++){
			OCR0 = Light;

			_delay_ms(10);
		}

		for (Light = 255; Light > 0; Light--)
		{
			OCR0 = Light;
			_delay_ms(10);
		}
	}
	return 0;
}

