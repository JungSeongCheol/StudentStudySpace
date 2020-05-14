# def factorial(n):
#     output = 1

#     for i in range(1, n + 1):
#         output *= i

#     return output

# def factorial(n):
#     if n == 0:
#         return 1
#     else:
#         return n*factorial(n-1)
    
# def fibonacci(n):
#     if n == 1:
#         return 1
#     if n == 2:
#         return 1
#     else:
#         return fibonacci(n - 1) + fibonacci(n - 2)

counter = 0
import time

# def fibonacci(n):
    # print("fibonacci({})를 구합니다.".format(n))
    # global counter
    # counter += 1

    # if n == 1:
    #     return 1
    # if n == 2:
    #     return 2
    # else:
    #     return fibonacci(n-1) + fibonacci(n-2)

dictionary = {
    1: 1,
    2: 2
}

def fibonacci(n):
    if n in dictionary:
        # 메모되어 있으면 메모된 값을 리턴
        return dictionary[n]
    else:
        # 메모되어 있지 않으면 값을 구함
        output = fibonacci(n-1) + fibonacci(n-2)
        dictionary[n] = output
        return output

# print("1!: {}".format(factorial(1)))
# print("2!: {}".format(factorial(2)))
# print("3!: {}".format(factorial(3)))
# print("4!: {}".format(factorial(4)))
# print("5!: {}".format(factorial(5)))
# print("10! : {}".format(format(factorial(10), ',d')))

# print("fibonacci(1):", fibonacci(1))
# print("fibonacci(2):", fibonacci(2))
# print("fibonacci(3):", fibonacci(3))
# print("fibonacci(4):", fibonacci(4))
# print("fibonacci(5):", fibonacci(5))

# print("fibonnaci(1)", fibonacci(1))
# start = time.time()
# print("fibonnaci(1000)", fibonacci(1000) )
# print("실행시간 : ", time.time() - start, "sec")
# print("dict size {}".format(len(dictionary)))

def flatten(data):
    output = []
    for item in data:
        if(type(item)==list):
            output += flatten(item)
        else:
            output.append(item)
    return output


example = [[1, 2, 3,], [4, [5, 6]], 7 ,[8 ,9]]
print("원본:", example)
print("변환:", flatten(example))
