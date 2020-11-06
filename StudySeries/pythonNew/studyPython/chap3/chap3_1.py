number = input("수 입력 : ")

last_ch = number[-1]

if last_ch in "02468":
    print("짝수입니다")

if last_ch in "13579":
    print("홀수입니다")
