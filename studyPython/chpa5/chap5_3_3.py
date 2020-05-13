# 파일을 열고
f = open("./studyPython/data/basic.txt", "w")
# 파일 쓰고
f.write("Hello Python Programming...!!!")
# 파일 닫기
f.close()

f1 = open("./studyPython/data/basic.txt", "a")
f1.write("\nAdded documents")
f1.close()

with open("./studyPython/data/test.txt", "a") as f3:
    f3.write("\nWith sentence document")

with open("./studyPython/data/test.txt", "r") as f4:
    content = f4.read()

print(content)