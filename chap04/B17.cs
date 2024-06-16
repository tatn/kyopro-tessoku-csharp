namespace KyoproTessokuCsharp.chap04
{
    internal class B17
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            List<int> H = new List<int>();
            H.Add(0);// 0
            H.AddRange(ReadIntArray()); // 1 to N

            long[] dp = new long[N + 1];
            dp[2] = Math.Abs(H[2] - H[1]);

            for (int i = 3; i <= N; i++)
            {
                dp[i] = Math.Min(dp[i - 1] + Math.Abs(H[i] - H[i - 1]), dp[i - 2] + Math.Abs(H[i] - H[i - 2]));
            }

            List<int> path = new List<int>();
            path.Add(N);

            int index = N;
            while(1 < index)
            {
                int costStepOne = (int)(dp[index] - dp[index - 1]);

                if(costStepOne == Math.Abs(H[index]- H[index-1]))
                {
                    index = index - 1;
                }
                else
                {
                    index = index - 2;
                }

                path.Add(index);
            }

            path.Reverse();

            Console.WriteLine(path.Count);
            Console.WriteLine(string.Join(" ", path));
        }
    }
}
