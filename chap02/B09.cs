namespace KyoproTessokuCsharp.chap02
{
    internal class B09
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[] A = new int[N];
            int[] B = new int[N];
            int[] C = new int[N];
            int[] D = new int[N];

            int M = 0;

            for (int i = 0; i < N; i++)
            {
                int[] ABCD = ReadIntArray();
                A[i] = ABCD[0];
                B[i] = ABCD[1];
                C[i] = ABCD[2];
                D[i] = ABCD[3];

                M = Math.Max(M, A[i]);
                M = Math.Max(M, B[i]);
                M = Math.Max(M, C[i]);
                M = Math.Max(M, D[i]);
            }

            int[,] diff = new int[M + 1, M + 1];

            for (int i = 0; i < N; i++)
            {
                diff[A[i], B[i]]++;
                diff[C[i], D[i]]++;
                diff[C[i], B[i]]--;
                diff[A[i], D[i]]--;
            }

            int[,] sum = new int[M + 1, M + 1];
            for (int i = 0; i <= M; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    sum[j + 1, i] = sum[j, i] + diff[j, i];
                }
            }

            for (int i = 0; i <= M; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    sum[i, j + 1] += sum[i, j];
                }
            }

            int answer = 0;
            for (int i = 0; i <= M; i++)
            {
                for (int j = 0; j <= M; j++)
                {
                    if (0 < sum[i, j])
                    {
                        answer++;
                    }
                }
            }

            Console.WriteLine(answer);
        }
    }
}
