namespace KyoproTessokuCsharp.chap05
{
    internal class A32
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NAB = ReadIntArray();
            int N = NAB[0];
            int A = NAB[1];
            int B = NAB[2];

            bool[] dp = new bool[N + 1];

            for (int i = 0; i <= N; i++)
            {
                if (i < A)
                {
                    dp[i] = false;
                }
                else if (A <= i && !dp[i - A])
                {
                    dp[i] = true;
                }
                else if (B <= i && !dp[i - B])
                {
                    dp[i] = true;
                }
                else
                {
                    dp[i] = false;
                }
            }

            Console.WriteLine(dp[N] ? "First" : "Second");

        }

    }
}
