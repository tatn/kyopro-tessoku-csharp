namespace KyoproTessokuCsharp.chap10
{
    internal class A76
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NWLR = ReadIntArray();
            int N = NWLR[0];
            int W = NWLR[1];
            int L = NWLR[2];
            int R = NWLR[3];

            int[] xInput = ReadIntArray();

            int[] X = new int[N + 2];
            for (int i = 1; i <= N; i++)
            {
                X[i] = xInput[i - 1];
            }
            X[N + 1] = W;
            
            long[] dp = new long[N + 2];
            long[] sum = new long[N + 2];
            dp[0] = 1;
            sum[0] = 1;

            for (int i = 1; i <=N+1; i++)
            {
                int leftIndex = Array.BinarySearch(X, X[i] - R);
                if (leftIndex<0)
                {
                    leftIndex = ~leftIndex;
                }

                int rightIndex = Array.BinarySearch(X, X[i] - L);
                if (rightIndex < 0)
                {
                    rightIndex = (~rightIndex) - 1;
                }

                if(leftIndex <= rightIndex)
                {
                    dp[i] = sum[rightIndex] - (leftIndex <= 0 ? 0L :sum[leftIndex-1]);
                    dp[i] = dp[i] < 0 ? dp[i] + 1_000_000_007 : dp[i];
                    dp[i] %= 1_000_000_007;
                    sum[i] = sum[i - 1] + dp[i];
                    sum[i] %= 1_000_000_007;
                }
                else
                {
                    dp[i] = 0;
                    sum[i] = sum[i - 1] + dp[i];
                    sum[i] %= 1_000_000_007;
                }
            }

            Console.WriteLine(dp[N + 1]);

        }
    }
}
