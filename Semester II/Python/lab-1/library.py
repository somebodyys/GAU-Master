import random
import string
from math import isqrt

# დაწერეთ პროგრამა, რომელიც შეყვანილ ათობით რიცხვს გადაიყვანს ორობითში.
def decimal_to_binary(decimal):
    if decimal == 0:
        return 0

    binary = ''
    while decimal > 0:
        binary = str(decimal % 2) + binary
        decimal = decimal // 2

    return binary


# დაწერეთ პროგრამა, რომლის მეშვეობითაც შეიტანთ ნებისმიერ რიცხვს. პროგრამამ შეამოწმოს, თუ შეყვანილი
# რიცხვი 10-ის ჯერადია, დაბეჭდოს “რიცხვი ბოლოვდება 0-ით”, თუ არადა დაბეჭდოს “რიცხვი არ ბოლოვდება 0-ით”.
def is_multiple_of(number, divisor):
    return number % divisor == 0


# დაწერეთ პროგრამა, რომლის მეშვეობითაც შეიტანთ წელს და დაადგენთ არის თუ არა შეყვანილი რიცხვი ნაკიანი
# წელიწადი. მაგ: 2012, 2016 წლები ნაკიანია. გაითვალისწინეთ, ნაკიანია წელიწადი, რომელიც უნაშთოდ იყოფა
# ოთხზე, გარდა იმ წლებისა რომლებიც იყოფა 100-ზე მაგრამ არ იყოფა 400-ზე. მაგ. 2100, 2200, 2300 წლები არ არის
# ნაკიანი. 2000 წელი ნაკიანია.
def is_leap_year(year):
    return (year % 4 == 0 and year % 100 != 0) or year % 400 == 0


# დაბეჭდეთ 5-ის ჯერადი რიცხვები 20-დან 125-ის ჩათვლით.
def multiples_in_range(number, start, end):
    result = []
    multiple = (start + number - 1) // number * number

    while multiple <= end:
        result.append(multiple)
        multiple += number
    return result


# შეიყვანეთ 10 რიცხვი კლავიატურიდან, დაითვალეთ შეყვანილი რიცხვების საშუალო არითმეტიკული.
def avarage_of_numbers(numbers):
    return sum(numbers) / len(numbers)


# შეიყვანეთ 2 დადებითი მთელი რიცხვი. იპოვეთ ამ ორი რიცხვის უდიდესი საერთო გამყოფი.
def greatest_common_divisor(a, b):
    while b:
        a, b = b, a % b
    return a


# შეიყვანეთ რიცხვი კლავიატურიდან. პროგრამამ უნდა დაბეჭდოს შეყვანილი რიცხვის ყველა გამყოფი. (მაგ. 18-ის
# გამოყოფებია: 1, 2, 3, 6, 9, 18)
def divisors_of_number(number):
    result = []
    for i in range(1, isqrt(number) + 1):
        if number % i == 0:
            result.append(i)
            if i != number // i:
                result.append(number // i)
    return result


# დაბეჭდეთ 2-დან 1000-მდე ყველა მარტივი რიცხვი.
def prime_numbers_in_range(start, end):
    sieve = [True] * (end + 1)
    sieve[0] = sieve[1] = False

    for i in range(2, isqrt(end) + 1):
        if sieve[i]:
            for j in range(i * i, end + 1, i):
                sieve[j] = False

    return [i for i in range(start, end + 1) if sieve[i]]


# შეიყვანეთ ნებისმიერი რიცხი. იპოვეთ ამ რიცხვის ციფრთა რაოდენობა და დაბეჭდეთ.
def count_digits(number):
    return len(str(number))


# შეიყვანეთ ნებისმიერი რიცხი. დაადგინეთ არის თუ არა შეტანილი რიცხვი პალინდრომი. (მითითება: პალინდრომია
# რიცხვი, რომელიც მარჯვნიდან და მარცხნიდან ერთნაირად იკითხება). მაგ. 12521.
def is_palindrome(number):
    return str(number) == str(number)[::-1]


# ააგეთ კალკულატორი. (სტრიქონის ანალიზის საშუალებით).
def calculator(expression):
    try:
        result = eval(expression)
        return result
    except Exception as e:
        return f"Error: {e}"


# ააგეთ შემთხვევით სტრიქონების გენერატორი (სტრიქონის ანალიზი).
def generate_random_string_line(min_words=1, max_words=10, min_chars_per_word=1, max_chars_per_word=10):
    number_of_words = random.randint(min_words, max_words)
    words = []
    for _ in range(number_of_words):
        word_length = random.randint(min_chars_per_word, max_chars_per_word)
        word = ''.join(random.choice(string.ascii_letters) for _ in range(word_length))
        words.append(word)
    return ' '.join(words)