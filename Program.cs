using System;
using System.IO;
using System.Collections.Generic;

namespace Kolmogorov_Smirnov
{
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
            try
            {
                if (args.Length != 2)
                {
                    throw new ArgumentNullException("Two file names expected. Pass them as command line arguments.");
                }
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
