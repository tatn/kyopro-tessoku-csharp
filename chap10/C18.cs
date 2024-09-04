namespace KyoproTessokuCsharp.chap10
{
    internal class C18
    {
        public static void Main(string[] args)
        {

            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> A = ReadIntArray().ToList();
            A.Insert(0, 0);

            int[,] dp = new int[2 * N + 1, 2 * N + 1];
            for (int i = 0; i <= 2 * N; i++)
            {
                for (int j = 0; j <= 2 * N; j++)
                {
                    dp[i, j] = 1_000_000_000;
                }
            }

            for (int i = 1; i < 2 * N; i++)
            {
                dp[i, i + 1] = Math.Abs(A[i]-A[i+1]);
            }

            for (int length = 4; length <= 2 * N; length+=2)
            {
                for (int i = 1; i <= 2 * N -length + 1; i++)
                {
                    int left = i;
                    int right = left + length -1;

                    dp[left,right] = Math.Min(dp[left,right], dp[left+1,right-1] + Math.Abs(A[left] - A[right]));

                    for(int j= left+1;j < right; j += 2)
                    {
                        dp[left, right] = Math.Min(dp[left, right], dp[left, j] + dp[j+1,right] );
                    }
                }
            }

            Console.WriteLine(dp[1, 2 * N]);

        }
    }
}
