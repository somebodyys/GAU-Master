from library import decimal_to_binary, is_multiple_of, is_leap_year, multiples_in_range, avarage_of_numbers, \
    greatest_common_divisor, divisors_of_number, prime_numbers_in_range, count_digits, is_palindrome, calculator, \
    generate_random_string_line


def main():
    print(f"Task 1 : {decimal_to_binary(10)}")
    print(f"Task 2 : {is_multiple_of(1005, 10)}")
    print(f"Task 3 : {is_leap_year(2100)}")
    print(f"Task 4 : {multiples_in_range(5, 20, 125)}")
    print(f"Task 5 : {avarage_of_numbers([1, 2, 3, 4, 5, 6, 7, 8, 9, 10])}")
    print(f"Task 6 : {greatest_common_divisor(10, 15)}")
    print(f"Task 7 : {divisors_of_number(18)}")
    print(f"Task 8 : {prime_numbers_in_range(2, 100)}")
    print(f"Task 9 : {count_digits(3456)}")
    print(f"Task 10 : {is_palindrome(12321)}")
    print(f"Task 11 : {calculator('(5 + 3 * (4 - 2)) / (1 + 2 ** 3)')}")
    print(f"Task 12 : {generate_random_string_line()}")


main()
