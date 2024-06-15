namespace KyoproTessokuCsharp.chap03
{
    internal class B13
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int[] A = ReadIntArray();

            long[] sum = new long[N];
            sum[0] = A[0];
            for (int i = 1; i < N; i++)
            {
                sum[i] = sum[i-1] + A[i];
            }

            int[] R = new int[N];

            R[0] = -1;
            for (int i = 0; i <= N - 1; i++)
            {
                if (0 < i)
                {
                    R[i] = R[i - 1];
                }

                if (i == 0)
                {
                    while (R[i] < N - 1 && sum[R[i] + 1] <= (long)K)
                    {
                        R[i] += 1;
                    }

                }
                else
                {
                    while (R[i] < N - 1 && sum[R[i] + 1] - sum[i - 1] <= (long)K)
                    {
                        R[i] += 1;
                    }

                }

            }

            long answer = 0;
            for (int i = 0; i <= N - 1; i++)
            {
                answer += (long)R[i] - (long)i + (long)1;
            }

            Console.WriteLine(answer);
        }
    }
}
