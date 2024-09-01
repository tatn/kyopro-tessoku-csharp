namespace KyoproTessokuCsharp.chap09
{
    internal class A70
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] A = ReadIntArray();

            int[] X = new int[M];
            int[] Y = new int[M];
            int[] Z = new int[M];

            for (int i = 0; i < M; i++)
            {
                int[] xyz = ReadIntArray();
                X[i] = xyz[0];
                Y[i] = xyz[1];
                Z[i] = xyz[2];
            }

            List<int>[] G = new List<int>[1 << N];

            for (int i = 0; i < (1 << N) ; i++)
            {
                G[i] = new List<int>();
            }

            int allOneBit = (1 << N) - 1;

            for (int i = 0; i < 1 << N; i++)
            {
                for (int j = 0; j < M; j++)
                {

                    int switchedIndex = 0;
                    for (int k = 1; k <= N; k++)
                    {
                        int bit = (i & (1 << (k - 1))) == 0 ? 0 : 1;
                        if (X[j] == k)
                        {
                            bit = 1 - bit;
                        }
                        else if (Y[j] == k)
                        {
                            bit = 1 - bit;
                        }
                        else if (Z[j] == k)
                        {
                            bit = 1 - bit;

                        }

                        switchedIndex += bit == 0 ? 0 : 1 << (k-1) ;
                    }

                    if (!G[i].Contains(switchedIndex))
                    {
                        G[i].Add(switchedIndex);
                    }
                    if (!G[switchedIndex].Contains(i))
                    {
                        G[switchedIndex].Add(i);
                    }
                }
            }

            int startIndex = 0;
            for (int i = 0; i < N; i++)
            {
                if (A[i] == 1)
                {
                    startIndex += (1 << i);
                }
            }

            int[] d = new int[1 << N];
            for(int i = 0; i < 1 << N; i++)
            {
                d[i] = -1;
            }

            Queue<int> q = new Queue<int>();
            q.Enqueue(startIndex);
            d[startIndex] = 0;
            while(0 < q.Count)
            {
                int index = q.Dequeue();

                if(index == allOneBit)
                {
                    break;
                }

                foreach (int next in G[index])
                {
                    if (0 <= d[next])
                    {
                        continue;
                    }

                    q.Enqueue(next);
                    d[next] = d[index] + 1;
                }
            }

            Console.WriteLine(d[allOneBit]);

        }

    }
}
