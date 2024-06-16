namespace KyoproTessokuCsharp.chap04
{
    internal class A22
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = ReadIntArray();
            int[] B = ReadIntArray();

            int[] dp = new int[N+1];
            for (int i = 0; i <= N; i++)
            {
                dp[i] = -100_000_000;
            }

            dp[0] = 0;
            dp[1] = 0;

            for (int i = 0; i < N-1; i++)
            {
                dp[A[i]] = Math.Max(dp[i + 1] + 100, dp[A[i]]);
                dp[B[i]] = Math.Max(dp[i + 1] + 150, dp[B[i]]);
            }

            Console.WriteLine(dp[N]);
        }
    }
}
