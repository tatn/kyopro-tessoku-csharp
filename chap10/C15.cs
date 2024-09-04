namespace KyoproTessokuCsharp.chap10
{
    internal class C15
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int K = ReadInt();

            int[] L = new int[N + 1];
            int[] R = new int[N + 1];

            List<(int, int)> meetings1 = new List<(int, int)>();
            List<(int, int)> meetings2 = new List<(int, int)>();

            for (int i = 1; i <= N; i++)
            {
                int[] lr = ReadIntArray();
                L[i] = lr[0];
                R[i] = lr[1] + K;
                meetings1.Add((L[i], R[i]));
                meetings2.Add((L[i], R[i]));
            }
            meetings1.Sort((a,b) => a.Item2 - b.Item2 == 0 ? a.Item1 - b.Item1 : a.Item2 - b.Item2);
            meetings2.Sort((a, b) => a.Item1 - b.Item1 == 0 ? a.Item2 - b.Item2 : a.Item1 - b.Item1);

            int[] countLeft = new int[86400 * 2 + 1];
            int nowTimeL = 0;
            int countL = 0;
            for (int i = 1; i <= N; i++)
            {
                (int begin, int end) = meetings1[i-1];
                if (nowTimeL <= begin)
                {
                    countL++;
                    countLeft[end] = countL;
                    nowTimeL = end;
                }
            }
            for (int i = 1; i < 86400 * 2 + 1; i++)
            {
                countLeft[i] = Math.Max(countLeft[i - 1], countLeft[i]);
            }

            int[] countRight = new int[86400 * 2 + 1];
            int nowTimeR = 86400 * 2;
            int countR = 0;
            for (int i = N; 1 <= i; i--)
            {
                (int begin, int end) = meetings2[i - 1];
                if (end <= nowTimeR)
                {
                    countR++;
                    countRight[begin] = countR;
                    nowTimeR = begin;
                }
            }
            for (int i = 86400 * 2 - 1; 0 <= i; i--)
            {
                countRight[i] = Math.Max(countRight[i], countRight[i+1]);
            }

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine(countLeft[L[i]] + 1 + countRight[R[i]]);
            }

        }
    }
}
