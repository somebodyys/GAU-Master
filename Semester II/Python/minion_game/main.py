def minion_game(string):
    vowels = 'AEIOU'
    length = len(string)
    vowel_score = 0
    consonant_score = 0

    for index in range(length):
        if string[index] in vowels:
            vowel_score += length - index
        else:
            consonant_score += length - index

    text = "AOEEESSA"

    unique_items = set()

    for item in text:
        unique_items.add(item)

    list(unique_items)



    if vowel_score > consonant_score:
        print(f"Kevin {vowel_score}")
    elif vowel_score < consonant_score:
        print(f"Stuart {consonant_score}")
    else:
        print("Draw")


if __name__ == '__main__':
    s = "BANANA"
    minion_game(s)