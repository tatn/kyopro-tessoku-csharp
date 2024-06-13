namespace KyoproTessokuCsharp.chap02
{
    internal class A07
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int D = ReadInt();
            int N = ReadInt();

            int[] L = new int[N];
            int[] R = new int[N];

            for (int i = 0; i < N; i++)
            {
                int[] LR = ReadIntArray();
                L[i] = LR[0];
                R[i] = LR[1];
            }

            int[] diff = new int[D + 2];

            for (int i = 0; i < N; i++)
            {
                diff[L[i]] += 1;
                diff[R[i] + 1] -= 1;
            }

            int[] diffSum = new int[D + 2];
            for (int i = 1; i <= D; i++)
            {
                diffSum[i] = diffSum[i - 1] + diff[i];
            }

            for (int i = 1; i <= D; i++)
            {
                Console.WriteLine(diffSum[i]);
            }

        }
    }
}
