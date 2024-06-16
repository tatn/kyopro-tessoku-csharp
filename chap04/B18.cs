namespace KyoproTessokuCsharp.chap04
{
    internal class B18
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

            List<int> answer  = new List<int>();

            if(dp[N, S])
            {
                int sum = S;

                for (int i = N; 1 <= i; i--)
                {
                    if (0<= sum - A[i] && sum - A[i] <= S && dp[i - 1, sum - A[i]])
                    {
                        sum = sum - A[i];
                        answer.Add(i);
                    }
                }

                answer.Reverse();
                Console.WriteLine(answer.Count);
                Console.WriteLine(String.Join(" ",answer));
            }
            else
            {
                Console.WriteLine(-1);
            }

        }
    }
}
