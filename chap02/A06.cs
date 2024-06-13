namespace KyoproTessokuCsharp.chap02
{
    internal class A06
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NQ = ReadIntArray();
            int N = NQ[0];
            int Q = NQ[1];

            int[] A = ReadIntArray();

            int[] L = new int[Q];
            int[] R = new int[Q];

            for (int i = 0; i < Q; i++)
            {
                int[] LR = ReadIntArray();
                L[i] = LR[0];
                R[i] = LR[1];
            }

            int[] sum = new int[N];
            sum[0] = A[0];

            for (int i = 1; i < N; i++)
            {
                sum[i] = sum[i - 1] + A[i];
            }

            for (int i = 0; i < Q; i++)
            {
                if (L[i] == 1)
                {
                    Console.WriteLine(sum[R[i] - 1]);
                }
                else
                {
                    Console.WriteLine(sum[R[i] - 1] - sum[L[i] - 2]);

                }
            }
        }
    }
}
