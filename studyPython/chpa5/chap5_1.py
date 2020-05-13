def print_3_times():
    print("Hello World")
    print("안녕하세요")
    print("구텐 타크")

# 가변매개변수와 충돌로 실행안됨(가변매개변수가 반드시 먼저이기 떄문에)  
# def print_n_times(value, n=3):
#     for i in range(n):
#         print(value, end=" ")

# def print_n_times(value):
#     for i in range(10):
#         print(value, end=" ")

def print_n_times(*values, n=3):
    for i in range(n):
        for value in values:
            print(value, end=" ")
        print()

def func(a, b=10, c=20):
    print(a + b + c)


# print_3_times()
# print_n_times("Hello", n=4)
# print_n_times(2, "안녕하세요", "즐거운", "파이썬", "프로그래밍")
# print_n_times("안녕하세요", n=1)
# print_n_times("안녕하세요", "즐거운", "파이썬", "프로그래밍", n=1)

func(10)
func(c = 100, a = 50, b = 50) #쓸 수는 있지만 별로 좋진않음.
