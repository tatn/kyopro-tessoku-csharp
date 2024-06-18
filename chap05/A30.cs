namespace KyoproTessokuCsharp.chap05
{
    internal class A30
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] nr = ReadLongArray();
            long n = nr[0];
            long r = nr[1];

            long M = 1_000_000_007L;

            long nFactorial = 1L;
            long rFactorial = 1L;
            long nrFactorial = 1L;

            for (long i = 1; i <= n ; i++)
            {
                nFactorial *= i;
                nFactorial %= M;
            }

            for (long i = 1; i <= r; i++)
            {
                rFactorial *= i;
                rFactorial %= M;
            }

            for (long i = 1; i <= n-r ; i++)
            {
                nrFactorial *= i;
                nrFactorial %= M;
            }

            long bottom = rFactorial * nrFactorial;
            bottom %= M;

            long answer = nFactorial;

            // ÷bottom <=> bottom^(M-2)
            long p = M - 2L;
            long bottomPower = bottom;
            for (int i = 0; i <=30; i++)
            {
                if(0 < (p & 1 << i))
                {
                    answer *= bottomPower;
                    answer %= M;
                }

                bottomPower *= bottomPower;
                bottomPower %= M;
            }

            Console.WriteLine(answer);

        }

    }
}
