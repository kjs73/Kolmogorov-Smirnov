namespace Kolmogorov_Smirnov
{
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
}