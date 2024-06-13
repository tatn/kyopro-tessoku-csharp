namespace KyoproTessokuCsharp.chap02
{
    internal class B06
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = ReadIntArray();
            int Q = ReadInt();

            int[] L = new int[Q];
            int[] R = new int[Q];
            for (int i = 0; i < Q; i++)
            {
                int[] LR = ReadIntArray();
                L[i] = LR[0];
                R[i] = LR[1];
            }

            int[] winSum = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                winSum[i] = winSum[i - 1] + A[i - 1];
            }

            for (int i = 0; i < Q; i++)
            {
                int winNumber = winSum[R[i]] - winSum[L[i] - 1];
                int lowseNumber = R[i] - L[i] + 1 - winNumber;

                if (winNumber == lowseNumber)
                {
                    Console.WriteLine("draw");
                }
                else
                {
                    Console.WriteLine(lowseNumber < winNumber ? "win" : "lose");
                }

            }
        }
    }
}
