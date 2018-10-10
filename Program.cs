using System;
using System.IO;
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
    class KS
    {
        public KS(cdf A, cdf B)
        {
            n = A.TotalNumber;
            m = B.TotalNumber;
            A.computeCdf();
            B.computeCdf();
        }
        private int n;
        private int m;

        public int N { get => n; set => n = value; }
        public int M { get => m; set => m = value; }
    }
    class Program
    {
        static IEnumerable<double> readData(string file)
        {
            string line;
            using (var reader = File.OpenText(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    yield return double.Parse(line);
                }
            }
        }
        static void Main(string[] args)
        {
            var fileA = args[0];
            var fileB = args[1];
            var cdfA = new cdf(readData(fileA));
            var cdfB = new cdf(readData(fileB));
            Console.WriteLine($"Read data with {cdfA.Count} and {cdfB.Count} distinct points.");
            Console.WriteLine($"Read data with {cdfA.TotalNumber} and {cdfB.TotalNumber} total points.");
            Console.WriteLine(fileA);
            cdfA.computeCdf();
            foreach (var r in cdfA.result)
            {
                Console.WriteLine($"{r.Key, -5}{r.Value, 5}");
            }
            Console.WriteLine(fileB);
            cdfB.computeCdf();
            foreach (var r in cdfB.result)
            {
                Console.WriteLine($"{r.Key, -5}{r.Value, 5}");
            }
        }
    }
}
