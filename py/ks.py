from scipy import stats
import os

def get_data(inp):
    f = open(inp)
    x = f.read().splitlines()
    f.close()
    x = [float(i) for i in x]
    return x


data = os.listdir("../data/")

for a in data:
    for b in data:
        if a != b:
            print(a,b)
            x = get_data("../data/" + a)
            y = get_data("../data/" + b)
            res = stats.ks_2samp(x, y)
            print(res)
