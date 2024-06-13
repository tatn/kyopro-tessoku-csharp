namespace KyoproTessokuCsharp.chap02
{
    internal class A10
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = ReadIntArray();
            int D = ReadInt();

            int[] L = new int[D];
            int[] R = new int[D];

            for (int i = 0; i < D; i++)
            {
                int[] LR = ReadIntArray();
                L[i] = LR[0];
                R[i] = LR[1];
            }

            int[] leftMax = new int[N + 2];
            for (int i = 1; i <= N; i++)
            {
                leftMax[i] = Math.Max(A[i - 1], leftMax[i - 1]);
            }
            leftMax[N + 1] = leftMax[N];

            int[] rightMax = new int[N + 2];
            for (int i = N; 1 <= i; i--)
            {
                rightMax[i] = Math.Max(A[i - 1], rightMax[i + 1]);
            }
            rightMax[0] = rightMax[1];

            for (int i = 0; i < D; i++)
            {
                int lMax = leftMax[L[i] - 1];
                int rMax = rightMax[R[i] + 1];

                Console.WriteLine(Math.Max(rMax, lMax));
            }
        }

    }
}
