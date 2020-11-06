/*
 * Ap2_UART_PIEZO.c
 *
 * Created: 2020-06-17 오후 4:08:09
 * Author : JSC
 */ 

#include <avr/io.h>
#include <util/delay.h>

unsigned int DoReMi[8] = { 523, 587, 659, 698, 783, 880, 987, 1046};

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


int main(void)
{
	unsigned char piano = 0;
	unsigned char text[] = "\r\nPlease Play Piano.(1~8)\r\n";

	unsigned char echo[] = "ECHO >> ";
	unsigned char i = 0;

	DDRE = 0xfe;
	DDRB = 0x80;

	UCSR0A = 0x00;
	UCSR0B = 0x18;
	UCSR0C = 0x06;

	UBRR0H = 0x00;
	UBRR0L = 0x03;

	while(text[i]!='\0'){
		putch(text[i++]);
	}

	i = 0;

	while(echo[i]!='\0'){
		putch(echo[i++]);
	}

	TCCR1A |= 0x00;
	TCCR1B |= 0x19;
	TCCR1C = 0x00;
	TCNT1 = 0x0000;

    /* Replace with your application code */
    while (1) 
    {
		if(getch()=='1'){
			TCCR1A |= 0x0A;
			ICR1 = 7372800/DoReMi[0];
			OCR1C = ICR1/10;
			_delay_ms(1000);
			TCCR1A |= 0x00;
			ICR1 = 10;
			OCR1C = ICR1/10;
		}

		else if(getch()=='2'){
			TCCR1A |= 0x0A;
			ICR1 = 7372800/DoReMi[1];
			OCR1C = ICR1/10;
			_delay_ms(1000);
			TCCR1A |= 0x00;
			ICR1 = 10;
			OCR1C = ICR1/10;
		}

		else if(getch()=='3'){
			TCCR1A |= 0x0A;
			ICR1 = 7372800/DoReMi[2];
			OCR1C = ICR1/10;
			_delay_ms(1000);
			TCCR1A |= 0x00;
			ICR1 = 10;
			OCR1C = ICR1/10;
		}

		else if(getch()=='4'){
			TCCR1A |= 0x0A;
			ICR1 = 7372800/DoReMi[3];
			OCR1C = ICR1/10;
			_delay_ms(1000);
			TCCR1A |= 0x00;
			ICR1 = 10;
			OCR1C = ICR1/10;
		}

		else if(getch()=='5'){
			TCCR1A |= 0x0A;
			ICR1 = 7372800/DoReMi[4];
			OCR1C = ICR1/10;
			_delay_ms(1000);
			TCCR1A |= 0x00;
			ICR1 = 10;
			OCR1C = ICR1/10;
		}

		else if(getch()=='6'){
			TCCR1A |= 0x0A;
			ICR1 = 7372800/DoReMi[5];
			OCR1C = ICR1/10;
			_delay_ms(1000);
			TCCR1A |= 0x00;
			ICR1 = 10;
			OCR1C = ICR1/10;
		}

		else if(getch()=='7'){
			TCCR1A |= 0x0A;
			ICR1 = 7372800/DoReMi[6];
			OCR1C = ICR1/10;
			_delay_ms(1000);
			TCCR1A |= 0x00;
			ICR1 = 10;
			OCR1C = ICR1/10;
		}

		else if(getch()=='8'){
			TCCR1A |= 0x0A;
			ICR1 = 7372800/DoReMi[7];
			OCR1C = ICR1/10;
			_delay_ms(1000);
			TCCR1A |= 0x00;
			ICR1 = 10;
			OCR1C = ICR1/10;
		}
	}
}

