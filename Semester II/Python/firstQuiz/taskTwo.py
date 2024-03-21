import random


# დაწერეთ პროგრამა, რომელიც შექმნის სიას (List) და ჩაწერს მასში 20 შემთხვევით მთელ რიცხვს 5-დან 15-შუალედში. იპოვეთ
# სიაში ყველაზე ხშირად განმეორებადი რიცხვი. ასევე მიუთითეთ რამდენჯერ გვხვდება სიაში თითოეული განსხვავებული
# ელემენტი.

def occurrences(numbers):
    result = {}
    for number in numbers:
        if number in result:
            result[number] += 1
        else:
            result[number] = 1

    return result


def run():
    random_numbers = [random.randint(5, 15) for _ in range(20)]

    print("Generated numbers: ", random_numbers)

    number_counts = occurrences(random_numbers)

    most_common_number = max(number_counts, key=number_counts.get)
    max_count = number_counts[most_common_number]

    print("\nNumber occurrences:")
    for number, count in sorted(number_counts.items()):
        print(f"{number}: {count}")

    print(f"\nMost repeated number is {most_common_number}, repeated {max_count} times")
