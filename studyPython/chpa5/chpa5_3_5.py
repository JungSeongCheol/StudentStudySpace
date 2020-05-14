lists = []

with open("./studyPython/data/result.txt", "r") as f:
    for line in f :
        (name, weight, height) = line.strip().split(",")

        if (not name) or (not weight) or (not height):
            continue

        bmi = int(weight) / (int(height) * int(height)) * 10000
        result = ""
        if 25 <= bmi:
            result = "과체중"
        elif 18.5 <= bmi:
            result = "정상"
        else:
            result = "저체중"
        
        lists.append({name, weight, height, bmi, result})
        print('\n'.join([
            "이름 : {}",
            "몸무게 : {}",
            "키 : {}",
            "BMI : {}",
            "결과 : {}"
        ]).format(name, weight, height, bmi, result))
        print()

with open("./studyPython/data/output.txt", "w"):
    f.write("{}, {}, {}, {}\n", lists[name], lists[weight], lists[height], lists[bmi])