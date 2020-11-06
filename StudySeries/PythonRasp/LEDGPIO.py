import RPi.GPIO as GPIO
import time

RED = 17
GREEN = 22
BLUE = 27

GPIO.setmode(GPIO.BCM)
GPIO.setup(RED, GPIO.OUT)
GPIO.setup(GREEN, GPIO.OUT)
GPIO.setup(BLUE, GPIO.OUT)

try:
    while(1):
        GPIO.output(RED, GPIO.HIGH)
        GPIO.output(GREEN, GPIO.LOW)
        GPIO.output(BLUE, GPIO.LOW)

        time.sleep(1)

        GPIO.output(RED, GPIO.LOW)
        GPIO.output(GREEN, GPIO.HIGH)
        GPIO.output(BLUE, GPIO.LOW)

        time.sleep(1)

        GPIO.output(RED, GPIO.LOW)
        GPIO.output(GREEN, GPIO.LOW)
        GPIO.output(BLUE, GPIO.HIGH)

        time.sleep(1)
except KeyboardInterrupt:
    GPIO.output(RED, GPIO.LOW)
    GPIO.output(GREEN, GPIO.LOW)
    GPIO.output(BLUE, GPIO.LOW)
    print("Terminated by Keyboard")
finally:
    print("End of program")

GPIO.output(RED, GPIO.HIGH)
GPIO.output(RED, GPIO.HIGH)
GPIO.output(RED, GPIO.HIGH)

time.sleep(1)

GPIO.setup(17, GPIO.OUT)
GPIO.output(17, GPIO.HIGH)

