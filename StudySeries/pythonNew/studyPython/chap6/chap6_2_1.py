# import math as m # 전체 다쓸때 import만 
from math import sin, cos, tan #부분적으로 사용 - from

try:
    number = int(input("정수 입력 >"))

    if number > 0:
        raise NotImplementedError("0보다 큼 : 구현안됨")
    else:
        raise NotImplementedError("0보다 작음 : 구현안됨")
except NotImplementedError as ex:
    print("구현 하지 않음")
    print()
    pass
except Exception as ex:
    print(ex)
finally:
    print("무조건 실행")