namespace KyoproTessokuCsharp.chap05
{
    internal class B29
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] ab = ReadLongArray();
            long a = ab[0];
            long b = ab[1];

            long mod = 1_000_000_007L;
            long answer = 1L;
            long aPower = a;
            for (int i = 0; i <= 60; i++)
            {
                if (0 < (b & (1L << i)))
                {
                    answer *= aPower;
                    answer %= mod;
                }

                aPower *= aPower;
                aPower %= mod;
            }

            Console.WriteLine(answer);

        }

    }
}
