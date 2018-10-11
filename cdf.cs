using System.Collections.Generic;

namespace Kolmogorov_Smirnov
{
    class cdf : SortedDictionary<double, int>
    {
        public cdf(IEnumerable<double> inp)
        {
            totalNumber = 0;
            add(inp);
        }
        public void add(double inp)
        {
            if (this.ContainsKey(inp))
            {
                ++this[inp];
            }
            else
            {
                this.Add(inp, 1);
            }
            ++totalNumber;
        }
        public void add(IEnumerable<double> inp)
        {
            foreach (var x in inp)
            {
                add(x);
            }
        }
        public void computeCdf()
        {
            result = new SortedDictionary<double, double>();
            var remaining = totalNumber;
            foreach (var p in this)
            {
                result.Add(p.Key, (double)remaining / (double)totalNumber);
                remaining -= p.Value;
            }
        }
        private int totalNumber;
        public int TotalNumber { get => totalNumber; set => totalNumber = value; }
        public SortedDictionary<double, double> result;
    }
}
