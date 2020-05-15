def create_student(name, korean, math, english, science):
    return {
        "name" : name,
        "korean" : korean,
        "math" : math,
        "english" : english,
        "science" : science
    }

def student_to_String(student):
    return "{}\t{}\t{}".format(
        student["name"],
        student_get_sum(student),
        student_get_average(student)
    )

def student_get_sum(student):
    return student["korean"] + student["math"] +\
        student["english"] + student["science"]

def student_get_average(student):
    return student_get_sum(student) / 4

students = [
    create_student("윤인성", 87, 98, 88, 85),
    create_student("연하진", 92, 96, 35, 66),
    create_student("구지연", 76, 16, 37, 75),
    create_student("나선주", 98, 76, 79, 85),
    create_student("윤아린", 95, 43, 90, 56),
    create_student("윤명월", 66, 67, 15, 85)
]

print("이름", "총점", "평균", sep='\t')
for student in students:
    # print("이름 : {}, 한국어: {}".format(item.get("이름"), item.get("korean")))

    print(student_to_String(student))
