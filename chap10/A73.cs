namespace KyoproTessokuCsharp.chap10
{
    internal class A73
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] A = new int[M];
            int[] B = new int[M];
            int[] C = new int[M];
            int[] D = new int[M];
            for (int i = 0; i < M; i++)
            {
                int[] abcd = ReadIntArray();
                A[i] = abcd[0];
                B[i] = abcd[1];
                C[i] = abcd[2];
                D[i] = abcd[3];
            }

            List<(int, long)>[] G = new List<(int, long)>[N + 1];
            long[] cost = new long[N + 1];
            for (int i = 0; i <= N; i++)
            {
                G[i] = new List<(int, long)>();
                cost[i] = 1_000_000_000_001;
            }

            for (int i = 0; i < M; i++)
            {
                long c = C[i] * 10_000 - D[i];
                G[A[i]].Add((B[i], c));
                G[B[i]].Add((A[i], c));
            }

            PriorityQueue<(int, long),long> priorityQueue = new PriorityQueue<(int, long),long>();
            bool[] visited = new bool[N+1];

            priorityQueue.Enqueue((1, 0), 0);
            cost[1] = 0;

            while (0 < priorityQueue.Count)
            {
                (int index,long c) = priorityQueue.Dequeue();
                visited[index] = true;

                foreach ((int nextIndex,long nextCost) in G[index])
                {
                    if (visited[nextIndex])
                    {
                        continue;
                    }

                    if(cost[index] + nextCost < cost[nextIndex])
                    {
                        priorityQueue.Enqueue((nextIndex, nextCost), cost[index] + nextCost);
                        cost[nextIndex] = cost[index] + nextCost;
                    }
                }
            }

            long costWithTree = cost[N];
            long costAnswer = (costWithTree + 9999L) / 10_000L;
            long treeAnswer = costAnswer * 10_000L - costWithTree;
            Console.WriteLine($"{costAnswer} {treeAnswer}");
        }
    }
}
