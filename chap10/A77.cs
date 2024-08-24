namespace KyoproTessokuCsharp.chap10
{
    internal class A77
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int[] NL = ReadIntArray();
            int N = NL[0];
            int L = NL[1];
            int K = ReadInt();
            int[] Ainput = ReadIntArray();
            int[] A = new int[N + 2];
            for (int i = 0; i < N; i++)
            {
                A[i + 1] = Ainput[i];
            }
            A[N + 1] = L;

            int GetCutNumber(int length)
            {
                int cutNumber = 0;
                int lastCutPoint = 0;

                for (int i = 1; i <= N+1; i++)
                {
                    if(length <= A[i] - lastCutPoint)
                    {
                        lastCutPoint = A[i];
                        cutNumber++;
                    }
                }

                return cutNumber;
            }

            int scoreLeft = 1;
            int scoreRight = L;
            while(scoreLeft + 1 < scoreRight)
            {
                int m = (scoreLeft+scoreRight)/2;

                int cutNumber = GetCutNumber(m);
                if(cutNumber < K + 1)
                {
                    scoreRight = m;
                }
                else
                {
                    scoreLeft = m;
                }
            }

            Console.WriteLine(scoreLeft);

        }
    }
}
