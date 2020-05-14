# try except 연습

# lists = [52, 273, 32, 72, 100]
# try :
#     inputs = int(input("정수 입력 > "))

#     print("{}번째 요소 : 값 {}".format(inputs, lists[inputs]))
#     예외.발생해주세요()
# except ValueError as ex:
#     print(ex)
#     print("정수를 입력해주세요.")
# except IndexError as ex:
#     print("인덱스 에러가 났어요")
#     print(ex)
# except NameError as ex:
#     print("NameError가 발생했어요")
#     print(ex)
# except Exception as ex:
#     print("?????? 에러가 발생했어요")
#     print(ex)


# else :
#     print("에러가 발생하지 않았습니다.")
# finally:
#     print("프로그램 종료")

# lists = ['11', '22', '33', '44', '하이', '55']
# outputs = []

# for item in lists:
#     try:
#         float(item)
#         outputs.append(item)
#     except:
#         print("뭔가 잘못 되었습니다.")

# print(outputs)

# f = open("./studyPython/data/basic.txt", "r")
# try:
#     f.write("TEST!!")
# except Exception as e:
#     print(e)
# finally:
#     f.close()

# print("파일 클로즈?", f.closed)

# def test():
#     print("test() start")
#     try:
#         print("test() try")
#         return
#         print("test() after return")
#     except:
#         print("test() except")
#     else:
#         print("test() else")
#     finally:
#         print("test() finally")

#     print("test() end")

# test()

# numbers = [52, 273, 32, 103, 90, 10, 275]

# print("#(1) 요소 내부에 있는 값 찾기")
# print("- {} 는 {} 위치에 있습니다.".format(52, numbers.index(52)))
# print()

# print("# (2) 요소 내부에 없는 값 찾기")
# numbers = 10000
# try:
#     print("- {}는 {} 위치에 있습니다".format(52, numbers.index(52)))
# except:
#     print("- 리스트 내부에 없는 값입니다.")
# print()

# print("---- 정상적으로 종료되었습니다. ----")

numbers = [52, 273, 32, 103, 90, 10, 275]

print("#(1) 요소 내부에 있는 값 찾기")
print("- {} 는 {} 위치에 있습니다.".format(52, numbers.index(52)))
print()

print("# (2) 요소 내부에 없는 값 찾기")
number = 10000
if number in numbers:
    print("- {}는 {} 위치에 있습니다".format(52, numbers.index(52)))
else:
    print("- 리스트 내부에 없는 값입니다.")
print()

print("---- 정상적으로 종료되었습니다. ----")