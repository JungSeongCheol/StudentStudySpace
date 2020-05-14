# def test():
#     print("A 지점 통과")
#     yield 1 # 리턴과 yield의 차이 : return 은 함수가 끝나는데 yield는 끝나지 않음
#     # 그리고 이지점에 return 1이 yield대신있다면, next함수 또한 사용할수 없다.
#     print("B 지점 통과")
#     yield 2
#     print("C 지점 통과")

# output = test()

# print("D 지점 통과")
# a = next(output)
# print(a)

# print("E 지점 통과")
# b = next(output)
# print(b)

# print("F 지점 통과")
# c = next(output)
# print(c)

# def num_gen():
#     yield 1
#     yield 2
#     yield 3
#     yield 4

# print(list(num_gen())

numbers = [1, 2, 3, 4, 5, 6]

print("::".join(str(numbers)))