namespace KyoproTessokuCsharp.chap03
{
    internal class A13
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int[] A = ReadIntArray();

            int[] R = new int[N];

            for (int i = 0; i <= N - 1; i++)
            {
                if (0 < i)
                {
                    R[i] = R[i - 1];
                }

                while (R[i] < N - 1 && A[R[i] + 1] - A[i] <= K)
                {
                    R[i] += 1;
                }
            }


            long answer = 0;
            for (int i = 0; i <= N-1; i++)
            {
                answer += (long)R[i] - (long)i;
            }

            Console.WriteLine(answer);
        }
    }
}
