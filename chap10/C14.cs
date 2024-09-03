using System;
using System.Collections.Generic;

namespace KyoproTessokuCsharp.chap10
{
    internal class C14
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] A = new int[M + 1];
            int[] B = new int[M + 1];
            int[] C = new int[M + 1];

            List<(int, int)>[] G = new List<(int, int)>[N + 1];
            bool[] visited = new bool[N + 1];
            long[] distance = new long[N + 1];
            bool[] visitedRev = new bool[N + 1];
            long[] distanceRev = new long[N + 1];
            for (int i = 0; i < N + 1; i++)
            {
                G[i] = new List<(int,int)>();
                distance[i] = 20_000_000_000L;
                distanceRev[i] = 20_000_000_000L;
            }

            for (int i = 1; i <=M; i++)
            {
                int[] abc = ReadIntArray();
                A[i] = abc[0];
                B[i] = abc[1];
                C[i] = abc[2];

                G[A[i]].Add((B[i], C[i]));
                G[B[i]].Add((A[i], C[i]));
            }


            PriorityQueue<(int, long),long> priorityQueue = new PriorityQueue<(int, long), long>();
            priorityQueue.Enqueue((1, 0), 0);
            distance[1] = 0;

            while (0 < priorityQueue.Count)
            {
                (int index , long d) = priorityQueue.Dequeue();
                if (visited[index])
                {
                    continue;
                }

                if(index == N)
                {
                    continue;
                }

                visited[index] = true;
                foreach((int next,int c) in G[index])
                {
                    if (visited[next])
                    {
                        continue;
                    }

                    if (distance[index] + (long)c < distance[next])
                    {
                        distance[next] = distance[index] + (long)c;
                        priorityQueue.Enqueue((next, distance[next]), distance[next]);
                    }

                }
            }

            PriorityQueue<(int, long), long> priorityQueueRev = new PriorityQueue<(int, long), long>();
            priorityQueueRev.Enqueue((N, 0), 0);
            distanceRev[N] = 0;

            while (0 < priorityQueueRev.Count)
            {
                (int index, long d) = priorityQueueRev.Dequeue();
                if (visitedRev[index])
                {
                    continue;
                }

                if (index == 1)
                {
                    continue;
                }

                visitedRev[index] = true;
                foreach ((int next, int c) in G[index])
                {
                    if (visitedRev[next])
                    {
                        continue;
                    }

                    if (distanceRev[index] + (long)c < distanceRev[next])
                    {
                        distanceRev[next] = distanceRev[index] + (long)c;
                        priorityQueueRev.Enqueue((next, distanceRev[next]), distanceRev[next]);
                    }

                }
            }

            bool[] passIndex = new bool[N+1];
            for (int i = 1; i <= N; i++)
            {
                long distanceFrom1 = distance[i];
                long distanceFromN = distanceRev[i];

                if(distanceFrom1 == 20_000_000_000L)
                {
                    continue;
                }

                if (distanceFromN == 20_000_000_000L)
                {
                    continue;
                }

                if (distanceFrom1 + distanceFromN == distance[N])
                {
                    passIndex[i] = true;
                }
            }

            Console.WriteLine(passIndex.Skip(1).Where(b=>b).Count());

        }
    }
}
