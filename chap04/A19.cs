namespace KyoproTessokuCsharp.chap04
{
    internal class A19
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray () => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NW = ReadIntArray();
            int N = NW[0];
            int W = NW[1];

            List<int> w = new List<int>();
            List<int> v = new List<int>();
            w.Add(0);// 0
            v.Add(0);// 0

            for (int i = 0;i < N; i++)
            {
                int[] wv = ReadIntArray();
                w.Add(wv[0]);
                v.Add(wv[1]);
            }

            long[,] dp = new long[N+1,W+1];
            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j <= W; j++)
                {
                    dp[i, j] = -1_000_000_000_000L;
                }
            }
            dp[0, 0] = 0;

            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j <= W; j++)
                {
                    if (0 <= dp[i-1,j])
                    {
                        dp[i,j] = dp[i-1,j];
                    }

                    if (0 <= j - w[i] && 0 <= dp[i - 1, j - w[i]])
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j - w[i]] + v[i], dp[i - 1, j]);
                    }
                }
            }

            long answer = 0L;
            for (int i = 0; i <= W; i++)
            {
                answer = Math.Max(answer, dp[N,i]);
            }

            Console.WriteLine(answer);
        }
    }
}
