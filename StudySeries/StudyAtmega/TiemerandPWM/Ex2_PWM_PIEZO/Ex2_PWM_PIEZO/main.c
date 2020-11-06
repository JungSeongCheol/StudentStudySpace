/*
 * Ex2_PWM_PIEZO.c
 *
 * Created: 2020-06-17 오후 12:19:18
 * Author : JSC
 */ 

#include <avr/io.h>
#include <util/delay.h>

unsigned int DoReMi[8] = {523, 587, 659, 698, 783, 880, 987, 1046};

int main(void)
{
    unsigned char piano = 0;

	DDRB = 0x80; // PB7(OCR1C) 

	TCCR1A |= 0x0A; // 0b00001010 // 1 << COMnC1 (COMnC1 ==1 , COMnC0 == 0) ==> 비교 매치후 Clear(==0)(Low Level에서 출력)
					// WGM11 =  1, WGM10 = 0 / WGM13 , WGM 12는 TCCR1B에 존재
	TCCR1B |= 0x19; // 0b00011001 ==> WGM13 == 1 (5번째 bit) WGM12 == 1(6번째 bit) ==> 1110 ==> Fast PWM 사용(14번)	
					// (CS12 == 0), (CS11 == 0), (CS10 == 1) --> 0 프리스캐일링 존재 하지않음 ==> 프리스케일 1
	
	TCCR1C = 0x00; //non-PWM모드가 아니므로 사용하지않는다.

	TCNT1 = 0x0000; //16비트 카운터값 0저장 자동증가(클럭을) ==> 타이머1 카운터 초기화

    while (1) 
    {
		ICR1 = 7372800/DoReMi[piano]; //입력캡처 레지스터 ICR1 ICx에서 들어오는 신호변화 검출 ==> 캡쳐시 TCNT의 카운터값 저장
		//도, 레, 미 ... 등의 주파수를 프리스케일처럼 묶어서 사용함.

		OCR1C = ICR1/10; //OCR1C 출력비교(16비트) 레지스터 일치시, 출력 or 출력비교 인터럽트 발생 (COMnC1 == 1, COMnC2 == 0)
		// TOP값은 FastPWM 14모드므로 ICR1이 사용됨
		// Duty의 크기(100/10 = 10%)를 가진다.
		// COM1이 1 , COM0가 0 ==> ICRn이나 OCRnA와 같아지면 0으로 클리어, TOP값 까지 증가후 0으로되면 OCnA는 1로 세트됨
		piano++;
		if(8<piano)
			piano = 0;
		_delay_ms(1000);
    }
}

