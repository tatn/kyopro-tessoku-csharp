namespace KyoproTessokuCsharp.chap04
{
    internal class A21
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            List<int> P = new List<int>();
            List<int> A = new List<int>();
            P.Add(0);// 0
            A.Add(0);// 0

            for (int i = 0; i < N; i++)
            {
                int[] PA = ReadIntArray();
                P.Add(PA[0]);
                A.Add(PA[1]);
            }

            int[,] dp = new int[N + 1, N + 1];

            for (int i = 2; i <= N;i++)
            {
                int leftRemvePoint = i <= P[i-1] && P[i-1] <= N ? A[i-1] : 0;
                dp[i, N] = dp[i - 1, N] + leftRemvePoint;
            }

            for (int i = 1; i <=N ; i++)
            {
                for (int j = N; 1 <= j; j--)
                {
                    //i-1を左から除外、または、jを右から除外

                    int leftRemvePoint = i <= P[i-1] &&  P[i - 1] <= j -1  ? A[i-1] : 0;
                    int rightRemvePoint = i <= P[j] &&  P[j] <= j - 1 ? A[j] : 0;
                    dp[i, j - 1] = Math.Max(dp[i - 1, j - 1] + leftRemvePoint, dp[i, j] + rightRemvePoint);
                }
            }

            Console.WriteLine(dp[N,1]);
        }
    }
}
