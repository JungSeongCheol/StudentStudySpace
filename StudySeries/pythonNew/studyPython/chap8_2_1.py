class Student:
    count = 0
    __radius = 5

    def __init__(self, name, korean, math, english, science):
        self.name = name
        self.korean = korean
        self.math = math
        self.english = english
        self.science = science

        Student.count += 1

    def __del__(self):
        pass

    @property
    def get_radius(self):
        return self.__radius

    def set_radius(self, value):
        self.__radius = value
    
    def get_sum(self):
        return self.korean + self.math +\
            self.english + self.science

    def get_average(self):
        return self.get_sum() / 4

    def __str__(self):
        return "{}\t{}\t{}".format(\
            self.name,\
            self.get_sum(),\
            self.get_average()
        )
    
    # def __get__(self, value):
    #     return self.get_sum() > value.get_sum()

    # def __It__(self, value):
    #     return self.sum() < value.get_sum()
    
students = [
    Student("윤인성", 87, 98, 88, 85),
    Student("구지연", 76, 16, 37, 75),
    Student("나선주", 98, 76, 79, 85),
    Student("윤아린", 95, 43, 90, 56),
    Student("연하진", 92, 96, 35, 66),
    Student("윤명월", 66, 67, 15, 85)
]

std = Student("홍길동", 100, 100, 100, 100)
std.set_radius(5.5)
print(std.get_radius)

print("생성한 학생수", Student.count)

# print(std_a == std_b)
# print("std의 클래스의 인스턴스여부: ", isinstance(std, Student))
