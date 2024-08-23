using System;

namespace KyoproTessokuCsharp.chap09
{
    internal class B64
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            List<(int, int)>[] G = new List<(int, int)>[N + 1];
            for (int i = 0; i < N + 1; i++)
            {
                G[i] = new List<(int, int)>();
            }

            for (int i = 0; i < M; i++)
            {
                int[] ABC = ReadIntArray();
                int A = ABC[0];
                int B = ABC[1];
                int C = ABC[2];

                G[A].Add((B, C));
                G[B].Add((A, C));
            }

            int[] distance = new int[N + 1];
            for (int i = 0; i < N + 1; i++)
            {
                distance[i] = 1_000_000_001;
            }
            distance[1] = 0;

            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
            priorityQueue.Enqueue(1, 0);

            bool[] fixedNode = new bool[N + 1];

            while (0 < priorityQueue.Count)
            {
                int index = priorityQueue.Dequeue();
                if (fixedNode[index])
                {
                    continue;
                }

                foreach ((int node, int cost) in G[index])
                {
                    if (distance[index] + cost < distance[node])
                    {
                        distance[node] = distance[index] + cost;
                        priorityQueue.Enqueue(node, distance[node]);
                    }
                }

                fixedNode[index] = true;
            }

            List<int> path = new List<int>();

            int current = N;
            while (current != 1)
            {
                path.Add(current);

                foreach ((int node, int cost) in G[current])
                {
                    if (distance[node] + cost == distance[current])
                    {
                        current = node;
                        break;
                    }                    
                }
            }

            path.Add(1);
            path.Reverse();
            Console.WriteLine(String.Join(" ", path));

        }

    }
}
