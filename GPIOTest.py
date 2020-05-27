import RPi.GPIO as GPIO
import time

GPIO.setmode(GPIO.BCM)
GPIO.setup(21, GPIO.OUT) # green
GPIO.setup(20, GPIO.OUT) # red

while True: #loop
    GPIO.output(20, True) # red on
    GPIO.output(21, False) # green off
    time.sleep(1)
    
    GPIO.output(20, False) # red off
    GPIO.output(21, True) # green off
    time.sleep(1)