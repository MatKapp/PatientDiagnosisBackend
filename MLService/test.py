import random

results = [False for _ in range(50)]

for i in range(20):
    for _ in range(15):
        selected = random.randint(0,49)
        results[selected] = True
    after_tour = results.count(True)
    print(f'{i}.{after_tour}')