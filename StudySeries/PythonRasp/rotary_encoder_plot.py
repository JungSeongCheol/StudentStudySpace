import serial
from matplotlib import pyplot as plt
from matplotlib import animation
import numpy as np
import time

arduino = serial.Serial('/dev/ttyACM0', baudrate=9600, timeout=None)

fig = plt.figure()
ax = plt.axes(xlim=(0, 50), ylim=(0, 200))
line,= ax.plot([], [], lw=1, c='blue', marker='d', ms=2)

max_points = 210
line, = ax.plot(np.arange(max_points), np.ones(max_points, dtype=np.float)*np.nan, lw=1, c='blue', marker='d', ms=2)

def init():
    return line,

def animate(i):
    y = arduino.readline()
    print(y)
    
    if(y!='' and y!='\r' and y!='\n' and y!='\r\n'):
        y = y.decode('utf-8')
        y = int(y)
    else:
        y = 1
    old_y = line.get_ydata()
    new_y = np.r_[old_y[1:], y]
    line.set_ydata(new_y)
    return line,

# while(1):
#     time.sleep(1)
#     y = arduino.readline()
#     y = y.decode('utf-8')
#     print(y)
anim = animation.FuncAnimation(fig, animate, init_func=init, frames=100, interval=20, blit=False)

plt.show()