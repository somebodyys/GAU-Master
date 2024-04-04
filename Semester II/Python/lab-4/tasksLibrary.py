import numpy as np


def task_one():
    static_vector1 = np.array([2, 3, 4])
    static_vector2 = np.array([1, 2, 3])
    static_result = np.multiply(static_vector1, static_vector2)
    print("Example 1 - Static numbers:")
    print("Vector 1:", static_vector1)
    print("Vector 2:", static_vector2)
    print("Result:", static_result)

    random_vector1 = np.random.randint(1, 10, size=5)
    random_vector2 = np.random.randint(1, 10, size=5)
    random_result = np.multiply(random_vector1, random_vector2)
    print("\nExample 2 - Random numbers:")
    print("Vector 1:", random_vector1)
    print("Vector 2:", random_vector2)
    print("Result:", random_result)

    return static_result, random_result


def task_two():
    return np.random.randint(0, 11, size=(3, 3))


def task_three():
    matrix1 = np.random.randint(0, 11, size=(10, 10))
    matrix2 = np.random.randint(0, 11, size=(10, 10))

    return np.concatenate((matrix1.flatten(), matrix2.flatten()))


def task_four():
    array_1d = np.random.randint(0, 101, size=36)
    array_2d = np.random.randint(0, 101, size=(6, 6))
    array_3d = np.random.randint(0, 101, size=(3, 3, 4))

    print("1-Dimensional Array:")
    print(array_1d)
    print("\n2-Dimensional Array:")
    print(array_2d)
    print("\n3-Dimensional Array:")
    print(array_3d)


def task_five():
    a = np.random.randint(0, 101, size=36)
    divisor = int(input("Divisor : "))

    b = a / divisor
    c = np.floor_divide(a, divisor)

    return a, b, c


def task_six():
    # x^2 + 4x - 5 = 0
    coefficients_eq1 = [1, 4, -5]

    # x^4 - 2*x^3 + x^2 - 4x - 5 = 0
    coefficients_eq2 = [1, -2, 1, -4, -5]

    roots_eq1 = np.roots(coefficients_eq1)
    roots_eq2 = np.roots(coefficients_eq2)

    print("(x^2 + 4x - 5 = 0):", roots_eq1)
    print("(x^4 - 2*x^3 + x^2 - 4x - 5 = 0):", roots_eq2)


def task_seven():
    matrix_2d = np.random.randint(0, 10, size=(3, 3))
    matrix_3d = np.random.randint(0, 10, size=(3, 3, 3))
    matrix_4d = np.random.randint(0, 10, size=(4, 4, 4, 4))
    matrix_5d = np.random.randint(0, 10, size=(5, 5, 5, 5, 5))

    determinant_2d = np.linalg.det(matrix_2d)
    determinant_3d = np.linalg.det(matrix_3d)
    determinant_4d = np.linalg.det(matrix_4d)
    determinant_5d = np.linalg.det(matrix_5d)

    # Print the determinants
    print("Determinant of 2D matrix:")
    print(determinant_2d)
    print("\nDeterminant of 3D matrix:")
    print(determinant_3d)
    print("\nDeterminant of 4D matrix:")
    print(determinant_4d)
    print("\nDeterminant of 5D matrix:")
    print(determinant_5d)
