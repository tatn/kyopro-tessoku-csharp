namespace KyoproTessokuCsharp.chap10
{
    internal class C04
    {
        public static void Main(string[] args)
        {
            long ReadLonf() => long.Parse(Console.ReadLine()!);

            long N = ReadLonf();

            List<long> divisors = new List<long>();
            for (long i = 1L; i <= Math.Sqrt(N) + 1; i++)
            {
                if(N % i == 0)
                {
                    divisors.Add(i);
                    divisors.Add(N / i);
                }
            }

            foreach (long i in divisors.Distinct().OrderBy(x => x))
            {
                Console.WriteLine(i);
            }
        }
    }
}
