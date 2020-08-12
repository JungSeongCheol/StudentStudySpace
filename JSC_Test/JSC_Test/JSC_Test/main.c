/*
 * JSC_Test.c
 *
 * Created: 2020-06-18 오전 10:17:42
 * Author : JSC
 */ 

#include <avr/io.h>
#include <util/delay.h>
#include <avr/interrupt.h>
#include <stdio.h>

unsigned char Stop_flag = 0;
unsigned int DoReMi[8] = { 523, 587, 659, 698, 783, 880, 987, 1046};
unsigned char Count = 0;

void putch(unsigned char data){
	while((UCSR0A & 0x20) == 0);
	UDR0 = data;
	UCSR0A |= 0x20;
}

unsigned char getch(){
	unsigned char data;
	while((UCSR0A & 0x80) == 0);
	data = UDR0;
	UCSR0A |= 0x80;
	return data;
}

void playLED(){
	unsigned char LED_Data = 0x01, l;
	unsigned char cnt1 = 0;
	DDRA = 0xff;

	while(1){
		while(cnt1 < 8){
			if((Stop_flag != 1) && (cnt1 == 7)){
				PORTA = LED_Data;
			}
			else if(Stop_flag != 1){
				PORTA = LED_Data;
				LED_Data <<= 1;
			}
			
			cnt1++;
			if(Stop_flag == 1){
				Count = 1;
				Stop_flag = 1;
				DDRA = 0x00;
				break;
			}
			_delay_ms(500);
		}

		if(Count == 1){
			Count = 0;
			Stop_flag = 0;
			DDRA = 0x00;
			break;
		}

		while(cnt1 > 0){
			if((Stop_flag != 1) &&cnt1 == 1){
				PORTA = LED_Data;
			}
			else if(Stop_flag != 1){
				PORTA = LED_Data;
				LED_Data >>= 1;
			}

			cnt1--;

			if(Stop_flag == 1){
				Count = 1;
				Stop_flag = 1;
				PORTA =0x00;
				break;
			}
			_delay_ms(500);
		}
		
		if(Count == 1){
			Count = 0;
			Stop_flag = 0;
			PORTA =0x00;
			break;
		}
	}
}

void playCDS(){
	unsigned int AdData = 0;
	unsigned char cd1 = 0;
	char s1[20];
	Count = 0;
	DDRF = 0x00;
	DDRC = 0xff;
	ADMUX = 0x00;
	ADCSRA = 0x86;
	PORTC = 0xff;
	Stop_flag = 0;

	while(1){
		ADCSRA |= 0x40;
		while((ADCSRA & 0x10) == 0x00);
		AdData = ADC;
		sprintf(s1, "%d%d%d%d\n", (AdData/1000)%10,(AdData/100)%10,(AdData/10)%10,AdData%10);

		while(s1[cd1]!='\0'){
			putch(s1[cd1++]);
			if(Stop_flag == 1){
				Count = 1;
				break;
			}
		}
		if(Stop_flag == 1){
			Count = 1;
			break;
		}
		if(Count == 1){
			Count = 0;
			Stop_flag = 0;
			break;
		}
		cd1 = 0;
		_delay_ms(300);
	}
	main();
}

void PlayStepMotor(){
	unsigned char StepMotorMenu[] = "\nF = Forward, R = Reverse";
	unsigned char sg = 0;
	unsigned char input1;
	//PORTB = 0x20;
	DDRD = 0xF0;
	PORTD = 0x00;
	//PORTB &= 0x20;
	while(StepMotorMenu[sg]!='\0'){
		putch(StepMotorMenu[sg++]);
	}
	Stop_flag = 0;
	while(1){
		input1 = getch();
		if(input1 == 'F'){
			while(1){
				PORTD = 0x80;
				_delay_ms(10);
				PORTD = 0x40;
				_delay_ms(10);
				PORTD = 0x20;
				_delay_ms(10);
				PORTD = 0x10;
				_delay_ms(10);
				if(Stop_flag == 1){
					Count = 1;
					Stop_flag = 1;
					break;
				}
				
			}
		}
		if(Count == 1){
			Count = 0;
			Stop_flag = 0;
			break;
		}

		if(input1 == 'R'){
			while(1){
				PORTD = 0x10;
				_delay_ms(10);
				PORTD = 0x20;
				_delay_ms(10);
				PORTD = 0x40;
				_delay_ms(10);
				PORTD = 0x80;
				_delay_ms(10);
				if(Stop_flag == 1){
					Count = 1;
					Stop_flag = 1;
					break;
				}
				
			}
		}
		
		if(Count == 1){
			Count = 0;
			Stop_flag = 0;
			break;
		}
	}
	main();
}
int main(void)
{
	unsigned char textMenu[] = "\n ++++ Menu +++\n";
	unsigned char textLed[] = " L : LED\n";
	unsigned char textCDS[] = " C : CDS\n";
	unsigned char textPiano[] = " 0 ~ 7 : PIANO \n";
	unsigned char textStepMotor[] = " S : Step Motor \n";
	unsigned char textStop[] = " push Button : Stop";
	unsigned char input;
	
	unsigned char i = 0;

	DDRE = 0xfe;
	DDRB = 0x80;

	UCSR0A = 0x00;
	UCSR0B = 0x18;
	UCSR0C = 0x06;

	UBRR0H = 0x00;
	UBRR0L = 0x03;

	EICRA = 0x01;
	EIMSK = 0x01;
	EIFR = 0x01;

	TCCR1A |= 0x00;
	TCCR1B |= 0x19;
	TCCR1C = 0x00;
	TCNT1 = 0x0000;

	sei();

	while(textMenu[i]!='\0'){
		putch(textMenu[i++]);
	}

	i = 0;

	while(textLed[i]!='\0'){
		putch(textLed[i++]);
	}

	i = 0;

	while(textCDS[i]!='\0'){
		putch(textCDS[i++]);
	}

	i = 0;

	while(textPiano[i]!='\0'){
		putch(textPiano[i++]);
	}

	i = 0;

	while(textStepMotor[i]!='\0'){
		putch(textStepMotor[i++]);
	}

	i = 0;

	while(textStop[i]!='\0'){
		putch(textStop[i++]);
	}

    /* Replace with your application code */
    while (1) 
    {
		input = getch();
		if(input == 'L'){
			playLED();
		}
		else if(input == 'C'){
			playCDS();
		}

		else if(input=='0'){
			TCCR1A |= 0x0A;
			ICR1 = 7372800/DoReMi[0];
			OCR1C = ICR1/10;
			_delay_ms(1000);
			TCCR1A |= 0x00;
			ICR1 = 10;
			OCR1C = ICR1/10;
		}

		else if(input=='1'){
			TCCR1A |= 0x0A;
			ICR1 = 7372800/DoReMi[1];
			OCR1C = ICR1/10;
			_delay_ms(1000);
			TCCR1A |= 0x00;
			ICR1 = 10;
			OCR1C = ICR1/10;
		}

		else if(input == '2'){
			TCCR1A |= 0x0A;
			ICR1 = 7372800/DoReMi[2];
			OCR1C = ICR1/10;
			_delay_ms(1000);
			TCCR1A |= 0x00;
			ICR1 = 10;
			OCR1C = ICR1/10;
		}

		else if(input =='3'){
			TCCR1A |= 0x0A;
			ICR1 = 7372800/DoReMi[3];
			OCR1C = ICR1/10;
			_delay_ms(1000);
			TCCR1A |= 0x00;
			ICR1 = 10;
			OCR1C = ICR1/10;
		}

		else if(input =='4'){
			TCCR1A |= 0x0A;
			ICR1 = 7372800/DoReMi[4];
			OCR1C = ICR1/10;
			_delay_ms(1000);
			TCCR1A |= 0x00;
			ICR1 = 10;
			OCR1C = ICR1/10;
		}

		else if(input =='5'){
			TCCR1A |= 0x0A;
			ICR1 = 7372800/DoReMi[5];
			OCR1C = ICR1/10;
			_delay_ms(1000);
			TCCR1A |= 0x00;
			ICR1 = 10;
			OCR1C = ICR1/10;
		}

		else if(input =='6'){
			TCCR1A |= 0x0A;
			ICR1 = 7372800/DoReMi[6];
			OCR1C = ICR1/10;
			_delay_ms(1000);
			TCCR1A |= 0x00;
			ICR1 = 10;
			OCR1C = ICR1/10;
		}

		else if(input =='7'){
			TCCR1A |= 0x0A;
			ICR1 = 7372800/DoReMi[7];
			OCR1C = ICR1/10;
			_delay_ms(1000);
			TCCR1A |= 0x00;
			ICR1 = 10;
			OCR1C = ICR1/10;
		}

		else if(input =='S'){
			PlayStepMotor();
		}
    }
}

SIGNAL(INT0_vect){
	cli();
	Stop_flag = 1;
	PORTA = 0X00;
	sei();
}

