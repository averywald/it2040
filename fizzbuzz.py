# fizzbuzz.py
# Avery Wald

# outputs numbers 0-100;
# all numbers divisible by 3 are replaced by 'fizz';
# all numbers divisible by 5 are replaced by 'buzz';
# numbers matching both cases are replaceed by 'fizzbuzz'

for x in range(0, 100):
    if (x % 3 == 0 and x % 5 == 0): print('fizzbuzz')
    elif (x % 3 == 0): print('fizz')
    elif (x % 5 == 0): print('buzz')
    else: print(x)
