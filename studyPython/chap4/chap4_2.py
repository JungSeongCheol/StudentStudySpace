dict_a = {
    "name" : "어벤저스 엔드게임",
    "type" : "히어로 무비",
    "cast" : ["아이언맨", "타노스", "토르", "닥터스트레인지", "헐크"],
    "release" : 2018,
    "director" : ["안소니 루소", "조 루소"]
}

print(dict_a)

dict_a["type"] = "로맨스"
dict_a["cameo"] = "스탠 리"

print(dict_a)

del dict_a["release"]
print(dict_a)

# print(dict_a["release"]) #relase의 키값이 사라져서, 작동하지 않는다.

print("")
print("")
key = "cast"
if key in dict_a:
    print("cast", dict_a["cast"])
else:
    print("cast 없음")