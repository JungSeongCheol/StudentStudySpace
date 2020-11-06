# format_a = "{}".format(10000);
# format_b = "{} {}".format(10, 20);

# format_c = "파이썬 열공하여 첫 연봉 {}만 원 만들기".format(5000)
# print(format_a)
# print(format_b)
# print(type(format_b))

output_a = "{:10d}".format(-30)
output_b = "{:+010.4f}".format(3.141592)
Pi = 3.141592

output_c = "{:g}".format(52.00000000)

input_s = "Hello Python Programming!!"
input_t = """
--- 안녕하세요
테스트입니다.
"""
# print(output_a)
# print(output_b)

print(input_s.upper())
print(input_s.lower())
print(input_t.strip())

# a = input("> 1번째 숫자 : ")
# b = input("> 2번째 문자 : ")
# print()

numbers = [273, 103, 5, 32, 65, 9, 72, 800, 99]

for number in numbers:
    if number> 100:
        print("- 100 이상의 수:", number)

