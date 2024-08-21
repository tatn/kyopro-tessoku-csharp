namespace KyoproTessokuCsharp.chap04
{
    internal class A23
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[,] A = new int[M+1, N+1];

            for (int i = 0; i < M; i++)
            {

                int[] aArray = ReadIntArray();

                for (int j = 0; j < N; j++)
                {
                    A[i + 1, j + 1] = aArray[j];
                }
            }

            //クーポンの枚数[クーポンi番目まで,対象の品物]
            int[,] dp = new int[M + 1, 1 << N];

            for (int i = 0; i <= M; i++)
            {
                for (int j = 0; j < (1 << N); j++)
                {
                    dp[i, j] = 1_000_000_000;
                }
            }

            dp[0, 0] = 0;

            for (int i = 1; i <= M; i++)
            {
                for (int j = 0; j < (1 << N); j++)
                {
                    bool[] targetItem = new bool[N + 1];

                    for (int k = 1; k <= N; k++)
                    {
                        targetItem[k] = ((1 << (k - 1)) & j) != 0;
                    }

                    // 品物の集合jとクーポン対象の和集合
                    int v = 0;
                    for (int k = 1; k <=N; k++)
                    {
                        if (targetItem[k] || A[i,k] == 1)
                        {
                            v += (1 << (k - 1));
                        }
                    }

                    dp[i, j] = Math.Min(dp[i, j], dp[i-1, j]);
                    dp[i, v] = Math.Min(dp[i, v], dp[i - 1, j] + 1);
                }
            }

            if (dp[M, (1 << N) - 1] == 1_000_000_000)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(dp[M, (1 << N) - 1]);
            }
        }
    }
}
