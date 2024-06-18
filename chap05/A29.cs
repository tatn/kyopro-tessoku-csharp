namespace KyoproTessokuCsharp.chap05
{
    internal class A29
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] ab = ReadIntArray();
            int a = ab[0];
            int b = ab[1];

            long mod = 1_000_000_007L;
            long answer = 1L;
            long aPower = a;
            for (int i = 0; i <= 30; i++)
            {
                if (0 < (b & 1 << i))
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
