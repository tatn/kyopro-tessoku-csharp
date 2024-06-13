namespace KyoproTessokuCsharp.chap02
{
    internal class A08
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] HW = ReadIntArray();
            int H = HW[0];
            int W = HW[1];

            int[,] X = new int[H, W];
            for (int i = 0; i < H; i++)
            {
                int[] xInput = ReadIntArray();
                for (int j = 0; j < W; j++)
                {
                    X[i, j] = xInput[j];
                }
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
            }

            int[,] sum = new int[H + 1, W + 1];

            for (int i = 1; i <= H; i++)
            {
                for (int j = 1; j <= W; j++)
                {
                    sum[i, j] += sum[i, j - 1] + X[i - 1, j - 1];
                }
            }

            for (int i = 1; i <= W; i++)
            {
                for (int j = 1; j <= H; j++)
                {
                    sum[j, i] += sum[j - 1, i];
                }
            }

            for (int i = 0; i < Q; i++)
            {
                int answer = sum[C[i], D[i]] + sum[A[i] - 1, B[i] - 1] - sum[A[i] - 1, D[i]] - sum[C[i], B[i] - 1];

                Console.WriteLine(answer);
            }
        }
    }
}
