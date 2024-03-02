class StudentCollection:
    def __init__(self):
        self.students = []

    def add_student(self, student):
        self.students.append(student)

    def remove_student(self, student):
        self.students.remove(student)

    def update_student(self, old_student, new_student):
        index = self.students.index(old_student)
        self.students[index] = new_student

    def get_scores_by_subject(self, subject):
        scores = []
        for student in self.students:
            if subject in student.subjects:
                scores.extend(student.subjects[subject])
        return scores
