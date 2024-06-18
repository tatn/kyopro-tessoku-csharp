namespace KyoproTessokuCsharp.chap05
{
    internal class B30
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] HW = ReadLongArray();
            long H = HW[0];
            long W = HW[1];

            long M = 1_000_000_007L;

            long top = 1L;

            for (long i = 1; i <= H + W - 2; i++)
            {
                top *= i;
                top %= M;
            }

            long bottom = 1L;

            for (long i = 1; i <= H - 1; i++)
            {
                bottom *= i;
                bottom %= M;
            }

            for (long i = 1; i <= W - 1; i++)
            {
                bottom *= i;
                bottom %= M;
            }

            long answer = top;

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
