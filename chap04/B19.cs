namespace KyoproTessokuCsharp.chap04
{
    internal class B19
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

            int valueSumMax = v.Sum();

            // N × valueSumMax <= 100 × 1000 * 100 = 10^7
            long[,] dp = new long[N+1, valueSumMax+1];
            for (int i = 0 ; i <= N; i++)
            {
                for (int j = 0; j <= valueSumMax; j++)
                {
                    dp[i, j] = 1_000_000_000_000L;
                }
            }

            dp[0, 0] = 0;

            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j <= valueSumMax; j++)
                {
                    if (dp[i-1,j] < 1_000_000_000_000L)
                    {
                        dp[i,j] = dp[i-1,j];
                    }

                    if (0 <= j - v[i] && dp[i - 1, j - v[i]] < 1_000_000_000_000L)
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j - v[i]] + w[i], dp[i - 1, j]);

                        if(W < dp[i, j])
                        {
                            dp[i, j] = 1_000_000_000_000L;
                        }
                    }
                }
            }

            long answer = 0L;
            for (int i = valueSumMax; 0 <= i ; i--)
            {
                if (dp[N, i] <= W)
                {
                    answer = i;
                    break;
                }

                if (0 < answer)
                {
                    break;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
