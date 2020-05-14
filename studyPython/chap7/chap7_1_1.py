import sys
import os
import datetime
from urllib import request, response

# print(sys.argv)

# print(sys.getwindowsversion())
# print("")
# print(sys.copyright)
# print("")
# print(sys.version)
# print("")

print("OS : ", os.name)
print("폴더 : ", os.getcwd())
print("files : ", os.listdir())

# os.mkdir("hello")
# os.rmdir("hello")
# os.system("tree")
current = datetime.datetime.now()
print("{}년 {}월 {}일 {}시 {}분 {}초 {}ms".format(
    current.year,
    current.month,
    current.day,
    current.hour,
    current.minute,
    current.second,
    current.microsecond
))

target = request.urlopen("http://www.google.com")
# output = target.read()
# print(output)
# status = target.getheaders()
# for item in status:
#     print(item)
print(target.status)