namespace KyoproTessokuCsharp.chap04
{
    internal class A18
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray () => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NS = ReadIntArray();
            int N = NS[0];
            int S = NS[1];
            List<int> A = new List<int>();
            A.Add(0);// 0
            A.AddRange(ReadIntArray()); // 2 to N

            bool[,] dp = new bool[N+1,S+1];
            dp[0, 0] = true;

            for (int i = 1; i <= N; i++)
            {
                for (int j = 0; j <= S; j++)
                {
                    if (dp[i-1,j])
                    {
                        dp[i,j] = true;
                    }
                    else if (0<= j - A[i] && j - A[i]  <=S  && dp[i - 1, j - A[i]])
                    {
                        dp[i, j] = true;
                    }
                }
            }

            Console.WriteLine(dp[N, S] ? "Yes" : "No");
        }
    }
}
