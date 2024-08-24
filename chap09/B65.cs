namespace KyoproTessokuCsharp.chap09
{
    internal class B65
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NT = ReadIntArray();
            int N = NT[0];
            int T = NT[1];

            int[] A = new int[N - 1];
            int[] B = new int[N - 1];

            List<int>[] G = new List<int>[N + 1];
            for (int i = 0; i <= N; i++)
            {
                G[i] = new List<int>();
            }

            List<int> edgeIndexes = new List<int>();
            for (int i = 0; i < N - 1; i++)
            {
                int[] AB = ReadIntArray();
                A[i] = AB[0];
                B[i] = AB[1];
                edgeIndexes.Add(i);
                G[AB[0]].Add(AB[1]);
                G[AB[1]].Add(AB[0]);
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(T);

            bool[] visited = new bool[N + 1];

            while (0 < queue.Count)
            {
                int index = queue.Dequeue();
                visited[index] = true;
                foreach (int edgeIndex in G[index])
                {
                    G[edgeIndex].Remove(index);
                    queue.Enqueue(edgeIndex);
                }
            }

            int[] levelMemo = new int[N+1];
            for (int i = 0; i < N+1; i++)
            {
                levelMemo[i] = -1;
            }

            int GetLevel(int pos)
            {
                if (levelMemo[pos] == -1)
                {

                    if (0 < G[pos].Count)
                    {
                        int maxLevel = -1;
                        foreach (int member in G[pos])
                        {
                            maxLevel = Math.Max(maxLevel, GetLevel(member));
                        }
                        levelMemo[pos] = maxLevel + 1;
                    }
                    else
                    {
                        levelMemo[pos] = 0;
                    }
                }

                return levelMemo[pos];
            }

            GetLevel(T);

            Console.WriteLine(String.Join(" ", levelMemo.ToList().Skip(1)));

        }

    }
}
