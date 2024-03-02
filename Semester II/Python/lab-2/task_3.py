from student import Student
from student_collection import StudentCollection
import matplotlib.pyplot as plt


def subject_score_distribution_visualization(collection, subjects):
    for subject in subjects:
        scores = collection.get_scores_by_subject(subject)
        plt.figure()
        plt.hist(scores, bins=range(0, 101, 5), color='skyblue', edgecolor='black')
        plt.title(f"Score Distribution for {subject}")
        plt.xlabel("Score")
        plt.ylabel("Frequency")
        plt.grid(True)
        plt.show()


def run():
    subjects = ['Math', 'Science', 'History', 'English', 'Art', 'Physics']

    students = StudentCollection()
    for _ in range(500):
        students.add_student(Student.generate_random_student())

    subject_score_distribution_visualization(students, subjects)
