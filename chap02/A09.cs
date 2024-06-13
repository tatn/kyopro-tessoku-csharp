namespace KyoproTessokuCsharp.chap02
{
    internal class A09
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] HWN = ReadIntArray();
            int H = HWN[0];
            int W = HWN[1];
            int N = HWN[2];

            int[] A = new int[N];
            int[] B = new int[N];
            int[] C = new int[N];
            int[] D = new int[N];

            for (int i = 0; i < N; i++)
            {
                int[] ABCD = ReadIntArray();
                A[i] = ABCD[0];
                B[i] = ABCD[1];
                C[i] = ABCD[2];
                D[i] = ABCD[3];
            }

            int[,] diff = new int[H + 2, W + 2];

            for (int i = 0; i < N; i++)
            {
                diff[A[i], B[i]] += 1;
                diff[C[i] + 1, D[i] + 1] += 1;
                diff[A[i], D[i] + 1] -= 1;
                diff[C[i] + 1, B[i]] -= 1;
            }

            int[,] sum = new int[H + 1, W + 1];

            for (int i = 1; i <= H; i++)
            {
                for (int j = 1; j <= W; j++)
                {
                    sum[i, j] += sum[i, j - 1] + diff[i, j];
                }
            }

            for (int i = 1; i <= W; i++)
            {
                for (int j = 1; j <= H; j++)
                {
                    sum[j, i] += sum[j - 1, i];
                }
            }

            for (int i = 1; i <= H; i++)
            {
                for (int j = 1; j <= W; j++)
                {
                    Console.Write(sum[i, j]);
                    if (j < W)
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
