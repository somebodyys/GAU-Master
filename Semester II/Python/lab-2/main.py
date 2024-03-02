from student import Student
from task_2 import read_file, count_words, count_sentences, get_top_10_words
from task_3 import run

if __name__ == '__main__':
    student = Student.generate_random_student()
    student.plot_score_distribution()
