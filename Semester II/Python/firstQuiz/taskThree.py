
# [10; 500] შუალედიდან, დაბეჭდეთ მხოლოდ ის რიცხვები რომლებსაც აქვთ მხოლოდ ორი გამყოფი, რომლიდანაც ერთი 5-ის
# ტოლია. (დავუშვათ 1-და თავის თავი გამყოფი არ არის. 5-ის გარდა არსებობს მხოლოდ მეორე გამყოფიც, მაგალითად: 15 = 5*3
# დაიბეჭდება, 30 = 3*10=5*6 არ დაიბეჭდება), დაითვალეთ რამდენი ასეთი რიცხვია.

def find_special_numbers(start, end):
    special_numbers = []
    for num in range(start, end + 1):
        divisors = get_divisors(num)
        if len(divisors) == 4 and 5 in divisors:
            special_numbers.append(num)
    return special_numbers


def get_divisors(num):
    divisors = []
    for i in range(1, int(num ** 0.5) + 1):
        if num % i == 0:
            divisors.append(i)
            if i != num // i:
                divisors.append(num // i)

    return divisors


def run():
    special_numbers = find_special_numbers(10, 500)
    print(special_numbers)
    print("Count :", len(special_numbers))
