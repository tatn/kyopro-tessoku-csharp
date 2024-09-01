namespace KyoproTessokuCsharp.chap10
{
    internal class C09
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);

            long[,] dp = new long[N+1,2];

            dp[1, 0] = 0L;
            dp[1, 1] = A[1];

            for (int i = 2; i <= N; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
                dp[i, 1] = dp[i - 1, 0] + (long)A[i];
            }

            Console.WriteLine(Math.Max(dp[N, 0], dp[N, 1]));
        }
    }
}
