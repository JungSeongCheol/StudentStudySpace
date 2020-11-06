# for i in range(0, 10):
#     print(i, "=반복변수")

# array = [11, 22, 33, 44, 55, 66]

# for i in range(len(array)):
#     print(i+1, "번째 arryay값", array[i])

# print()

# for i in range(10, 0 - 1, -1):
#     print(i)

# while True:
#     print(".", end="")

# i = 0
# while True:
#     print("{}번째 반복".format(i))
#     i += 1

#     # 반복 종료
#     input_text = input("> 종료합니까?(y)")
#     if input_text in ["y", "Y"]:
#         print("반복 종료")
#         break

# numbers = [5, 15, 6, 60, 7, 25]

# for num in numbers:
#     if num < 10:
#         continue

#     print(num)


# key_list = ["name", "hp", "mp", "level"]
# value_list = ["기사",  200, 30, 5]
# character = {}

# for key in key_list:
#     for i in [0,1,2,3]:
#         if(key_list[i] == key):
#             character[key] = value_list[i]
# print(character)


limit = 10000
i = 1
sum_value = 0
while sum_value < 10000:
    sum_value += i
    i = i+1
print("{}를 더할 때 {}을 넘으며 그때의 값은 {}입니다.".format(i, limit, sum_value))