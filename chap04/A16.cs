namespace KyoproTessokuCsharp.chap04
{
    internal class A16
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> A = new List<int>();
            A.Add(0);// 0
            A.Add(0);// 1
            A.AddRange(ReadIntArray()); // 2 to N

            List<int> B = new List<int>();
            B.Add(0);// 0
            B.Add(0);// 1
            B.Add(0);// 2
            B.AddRange(ReadIntArray()); // 3 to N

            int[] dp = new int[N + 1];
            dp[2] = A[2];

            for (int i = 3; i <= N; i++)
            {
                dp[i] = Math.Min(dp[i - 1] + A[i], dp[i - 2] + B[i]);
            }

            Console.WriteLine(dp[N]);
        }

        public static void MainOther(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> A = new List<int>();
            A.Add(0);// 0
            A.Add(0);// 1
            A.AddRange(ReadIntArray()); // 2 to N

            List<int> B = new List<int>();
            B.Add(0);// 0
            B.Add(0);// 1
            B.Add(0);// 2
            B.AddRange(ReadIntArray()); // 3 to N

            int[] dp = new int[N + 1];
            for (int i = 0; i <= N; i++)
            {
                dp[i] = 100_000_000;
            }

            dp[1] = 0;
            dp[2] = A[2];

            for (int i = 3; i <= N; i++)
            {
                dp[i] = Math.Min(dp[i], dp[i - 1] + A[i]);
                dp[i] = Math.Min(dp[i], dp[i - 2] + B[i]);
            }

            Console.WriteLine(dp[N]);
        }
    }
}
