namespace KyoproTessokuCsharp.chap04
{
    internal class B23
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[,] XY = new int[N, 2];

            for (int i = 0; i < N; i++)
            {
                int[] xy = ReadIntArray();
                XY[i, 0] = xy[0];
                XY[i, 1] = xy[1];
            }

            double[,] dp = new double[1<<N, N+1];
            for (int i = 0; i < (1 << N); i++)
            {
                for (int j = 0; j < N + 1; j++)
                {
                    dp[i, j] = 1_000_000_000d;
                }
            }

            dp[0, 0] = 0d;

            // i 通過した都市の集合
            for (int i = 0; i < (1 << N); i++)
            {
                // j 今いる都市
                for (int j = 0; j < N; j++)
                {
                    if(1_000_000_000d <= dp[i, j])
                    {
                        continue;
                    }

                    // 都市jから都市kへの移動
                    for (int k = 0; k < N ; k++)
                    {
                        //都市の集合iにkが含まれているか
                        bool passedK = (i & (1 << k) ) != 0;
                        if (passedK)
                        {
                            continue;
                        }

                        // i => j => k
                        // kを含まない通過した都市の集合iにkを追加して、距離を計算する
                        double distance = Math.Sqrt((XY[j, 0] - XY[k, 0]) * (XY[j, 0] - XY[k, 0]) + (XY[j, 1] - XY[k, 1]) * (XY[j, 1] - XY[k, 1]));
                        dp[i + (1 << k), k] = Math.Min(dp[i + (1 << k), k], dp[i, j] +  distance);

                    }

                }
            }

            Console.WriteLine(dp[(1 << N) - 1,0]);

        }
    }
}
