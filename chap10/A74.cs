namespace KyoproTessokuCsharp.chap10
{
    internal class A74
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();

            int[,] P = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                int[] line = ReadIntArray();
                for (int j = 0; j < N; j++)
                {
                    P[i, j] = line[j];
                }
            }

            int[] A = new int[N];
            int[] B = new int[N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (P[i, j] != 0)
                    {
                        A[i] = P[i, j];
                        break;
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (P[j, i] != 0)
                    {
                        B[i] = P[j, i];
                        break;
                    }
                }
            }

            int answer = 0;
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (A[j] < A[i])
                    {
                        answer++;
                    }
                    if (B[j] < B[i])
                    {
                        answer++;
                    }
                }
            }
            Console.WriteLine(answer);
        }
    }
}
