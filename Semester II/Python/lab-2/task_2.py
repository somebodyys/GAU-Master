def read_file(file):
    with open(file, 'r') as file:
        data = file.read()
    return data

def count_words(text):
    return len(text.split())

def count_sentences(text):
    return len(text.split('.'))

def count_characters(text):
    return len(text)

def count_numbers(text):
    return sum(char.isdigit() for char in text)

def get_top_10_words(text):
    words = text.lower().split()
    word_count = {}
    for word in words:
        if word in word_count:
            word_count[word] += 1
        else:
            word_count[word] = 1
    return sorted(word_count.items(), key=lambda x: x[1], reverse=True)[:10]