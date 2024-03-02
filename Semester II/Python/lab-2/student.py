import random
import string
import matplotlib.pyplot as plt

class Student:
    def __init__(self, first_name, last_name):
        self.first_name = first_name
        self.last_name = last_name
        self.subjects = {}

    def add_score(self, subject, score):
        if subject in self.subjects:
            self.subjects[subject].append(score)
        else:
            self.subjects[subject] = [score]

    @staticmethod
    def generate_random_student():
        first_name = ''.join(random.choices(string.ascii_uppercase, k=random.randint(4, 10)))
        last_name = ''.join(random.choices(string.ascii_uppercase, k=random.randint(4, 10)))
        student = Student(first_name, last_name)

        num_subjects = random.randint(1, 5)
        subjects = ['Math', 'Science', 'History', 'English', 'Art', 'Physics']
        for _ in range(num_subjects):
            subject = random.choice(subjects)
            num_scores = random.randint(5, 15)
            for _ in range(num_scores):
                score = random.randint(0, 100)
                student.add_score(subject, score)

        return student

    def plot_score_distribution(self):
        plt.figure()
        for subject, scores in self.subjects.items():
            plt.plot(scores, label=subject)
        plt.title(f"Score Distribution for {self.first_name} {self.last_name}")
        plt.xlabel("Week (Index of Score in list)")
        plt.ylabel("Score")
        plt.legend()
        plt.grid(True)
        plt.show()
