namespace KyoproTessokuCsharp.chap05
{
    internal class B32
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int[] A = ReadIntArray();

            bool[] dp = new bool[N+1];


            int[] ASorted = A.OrderBy(x => x).ToArray();

            for (int i = 0; i <= N; i++)
            {
                if (i < ASorted[0])
                {
                    dp[i] = false;
                    continue;
                }

                foreach (int a in A)
                {
                    if(a <= i && !dp[i-a])
                    {
                        dp[i] = true;
                    }
                }
            }

            Console.WriteLine(dp[N] ? "First" : "Second");

        }

    }
}
