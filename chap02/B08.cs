namespace KyoproTessokuCsharp.chap02
{
    internal class B08
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int M = 0;

            int[] X = new int[N];
            int[] Y = new int[N];
            for (int i = 0; i < N; i++)
            {
                int[] XY = ReadIntArray();
                X[i] = XY[0];
                Y[i] = XY[1];

                M = Math.Max(M, X[i]);
                M = Math.Max(M, Y[i]);
            }

            int Q = ReadInt();
            int[] A = new int[Q];
            int[] B = new int[Q];
            int[] C = new int[Q];
            int[] D = new int[Q];

            for (int i = 0; i < Q; i++)
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
                diff[X[i], Y[i]]++;
            }

            int[,] sum = new int[M + 1, M + 1];
            for (int i = 1; i <= M; i++)
            {
                for (int j = 1; j <= M; j++)
                {
                    sum[j, i] = sum[j - 1, i] + diff[j, i];
                }
            }

            for (int i = 1; i <= M; i++)
            {
                for (int j = 1; j <= M; j++)
                {
                    sum[i, j] += sum[i, j - 1];
                }
            }

            for (int i = 0; i < Q; i++)
            {
                int answer = sum[C[i], D[i]] + sum[A[i] - 1, B[i] - 1] - sum[C[i], B[i] - 1] - sum[A[i] - 1, D[i]];
                Console.WriteLine(answer);
            }
        }
    }
}
