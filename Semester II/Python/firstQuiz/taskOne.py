import random


# დაწერეთ პროგრამა, რომელიც შექმნის შემდეგი სახის ლექსიკონს (key არის 1-დან 100-მდე შემთხვევი განსხვავებული
# რიცხვები, ხოლო value- მათი ციფრების ჯამი). ლექსიკონი შედგება 10 ელემენტისგან. დაბეჭდეთ ყველაზე დიდი და მცირე
# მნიშვნელობის მქონდე ელემენტი, თუ ლექსიკონის ყველა ელემენტს ერთ სტრიქონში დავალაგებთ, გამოიტანეთ რამდენი
# ნული იქნება მწკრივში. (4 ქულა)

def digit_sum(number):
    return sum(int(digit) for digit in str(number))


def generate_lexicon():
    result = {}

    while len(result) < 10:
        key = random.randint(1, 100)

        if key not in result:
            value = digit_sum(key)
            result[key] = value
    return result


def run():
    lexicon = generate_lexicon()

    max_value_key = max(lexicon, key=lexicon.get)
    min_value_key = min(lexicon, key=lexicon.get)

    print(f"\nMax : Key => {max_value_key}, Value => {lexicon[max_value_key]}")

    print(f"\nMin : Key => {min_value_key}, Value => {lexicon[min_value_key]}")

    concatenated_string = ''.join(str(value) for value in lexicon.values())
    num_zeros = concatenated_string.count('0')

    print("\nConcatenated string:", concatenated_string)
    print("\nZeros:", num_zeros)
