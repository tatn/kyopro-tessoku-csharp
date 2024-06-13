namespace KyoproTessokuCsharp.chap02
{
    internal class B07
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int T = ReadInt();
            int N = ReadInt();

            int[] L = new int[N];
            int[] R = new int[N];
            for (int i = 0; i < N; i++)
            {
                int[] LR = ReadIntArray();
                L[i] = LR[0];
                R[i] = LR[1];
            }

            int[] diff = new int[T + 1];
            for (int i = 0; i < N; i++)
            {
                diff[L[i]] += 1;
                diff[R[i]] -= 1;
            }

            int[] sum = new int[T + 1];
            sum[0] = diff[0];
            for (int t = 1; t < T; t++)
            {
                sum[t] = sum[t - 1] + diff[t];
            }

            for (int t = 0; t < T; t++)
            {
                Console.WriteLine(sum[t]);
            }
        }
    }
}
