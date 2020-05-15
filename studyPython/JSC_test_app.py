# 마지막 테스트 파이썬
import json

dic_mcu = []

# print(dic_mcu)
# with open("./data/mcu_movies.json", "w", encoding="UTF-8") as mcu_list:
#   json.dump(dic_mcu, mcu_list, ensure_ascii=False)

with open("./studyPython/mcu_movies.json", "r", encoding="UTF-8") as mcu_list:
  dic_mcu = json.load(mcu_list)


# 문제 1번
# 페이즈가 1인 마블 시네마틱 유니버스 영화면 뽑기

# print(dic_mcu)

for item in dic_mcu:
  for key in item:
    if(item[key] == "페이즈2"):
      print(item["영화명"], "(", item["개봉일"], ")")
print()
# 문제 2번
# 박스오피스가 450000000 이상인 영화들의 감독이름 리스트와 전체 합계금액, 평균 박스오피스 구하기

name = []
count = 0
sum1 = 0
avg1 = 0
for item in dic_mcu:
  for key in item:
    if(key == "박스오피스"):
      if(item[key] >= 450000000):
        name.append(item["감독"])
        count = count + 1
        sum1 = sum1 + item[key]

ex_list = list(set(name))
print("감독 리스트 :")
print(ex_list)
print("총 박스오피스 합계 ","$", format(sum1, ',d'))
avg1 = int(sum1 / count)
print("평균 박스오피스 ","$", format(avg1, ',d'))