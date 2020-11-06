class Student:
    def __init__(self, name, korean, math, english, science):
        self.name = name
        self.korean = korean
        self.math = math
        self.english = english
        self.science = science
    
    def get_sum(self):
        return self.korean + self.math +\
            self.english + self.science

    def get_average(self):
        return self.get_sum() / 4
    
    def to_string(self):
        return "{}\t{}\t{}".format(\
            self.name,\
            self.get_sum(),\
            self.get_average()
        )

# student = Student()

students = [
    Student("윤인성", 87, 98, 88, 85),
    Student("구지연", 76, 16, 37, 75),
    Student("나선주", 98, 76, 79, 85),
    Student("윤아린", 95, 43, 90, 56),
    Student("연하진", 92, 96, 35, 66),
    Student("윤명월", 66, 67, 15, 85)
]

print("이름", "총점", "평균", sep='\t')
for student in students:
    print(student.to_string())