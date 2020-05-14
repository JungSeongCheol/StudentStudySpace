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

numbers= [1,2,6,8,4,3,2,1,9,5,4,9,7,2,1,3,5,4,8,9,7,2,3]
counter = {}
for number in numbers:
    if(counter == {}):
        for i in numbers:
            counter[i] = 0

    for i in [1,2,3,4,5,6,7,8,9]:
        if(number == i):
            counter[i] += 1

print(counter)


# character = {
#     "name" : "기사",
#     "level" : 12,
#     "items" : {
#         "sword": "불꽃의 검",
#         "armor": "풀플레이트"
#     },
#     "skill" : ["베기", "세게 베기", "아주 세게 베기"]
# }

# for key in character:
#     if(type(character[key]) is str):
#         print(key, ":", character[key])
#     if(type(character[key]) is int):
#         print(key, ":", character[key])
#     if(type(character[key]) is dict):
#         for key1 in character[key]:
#             print(key1, ":", character[key][key1])
#     if(type(character[key]) is list):
#         for i in [0,1,2]:
#             print(key, ":", character[key][i])
