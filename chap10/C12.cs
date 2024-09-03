namespace KyoproTessokuCsharp.chap10
{
    internal class C12
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NMK = ReadIntArray();
            int N = NMK[0];
            int M = NMK[1];
            int K = NMK[2];

            List<int> A = new List<int>();
            List<int> B = new List<int>();
            for (int i = 0; i < M; i++)
            {
                int[] AB = ReadIntArray();
                A.Add(AB[0]);
                B.Add(AB[1]);
            }
            A.Insert(0, 0);
            B.Insert(0, 0);

            int[,] connectCount = new int[N + 1, N + 1];

            for (int i = 1; i <= N - 1; i++)
            {
                for (int j = i + 1; j <= N; j++)
                {
                    int count = 0;
                    for (int k = 1; k <= M; k++)
                    {
                        count += i <= A[k] && B[k] <= j ? 1 : 0;

                    }
                    connectCount[i, j] = count;
                }
            }

            // dp[i,j] i章の終わりがページjの場合の繋がりの個数
            int[,] dp = new int[K + 1, N + 1];

            for (int i = 0; i < K + 1; i++)
            {
                for (int j = 0; j < N + 1; j++)
                {
                    dp[i, j] = -1_000;
                }
            }

            dp[0, 0] = 0;

            for (int i = 1; i <= K; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    for(int k = 0; k <= j - 1; k++)
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i - 1, k] + connectCount[k + 1, j]);
                    }

                }
            }

            Console.WriteLine(dp[K,N]);

        }
    }
}
