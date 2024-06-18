namespace KyoproTessokuCsharp.chap05
{
    internal class A35
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = ReadIntArray();

            int[,] dp = new int[N + 1, N + 1];
            for (int i = 1; i < N; i++)
            {
                dp[N, i] = A[i - 1];
            }

            for (int i = N - 1; 1 <= i; i--)
            {
                if(i % 2 == 0)
                {
                    // Jiro
                    for (int j = 1; j <= i; j++)
                    {
                        dp[i, j] = Math.Min(dp[i + 1, j], dp[i + 1, j + 1]);
                    }
                }
                else
                {
                    // Taro
                    for (int j = 1; j <= i; j++)
                    {
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i + 1, j + 1]);
                    }

                }
            }

            Console.WriteLine(dp[1, 1]);
        }
    }
}
