namespace KyoproTessokuCsharp.chap09
{
    internal class A63
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] A = new int[M];
            int[] B = new int[M];

            for (int i = 0; i < M; i++)
            {
                int[] AB = ReadIntArray();
                A[i] = AB[0];
                B[i] = AB[1];
            }

            List<int>[] G = new List<int>[N+1];
            for (int i = 0; i < N+1; i++)
            {
                G[i] = new List<int>();
            }

            for (int i = 0; i < M; i++)
            {
                G[A[i]].Add(B[i]);
                G[B[i]].Add(A[i]);
            }

            int[] distance = new int[N+1];
            for (int i = 0; i < N+1; i++)
            {
                distance[i] = -1;
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            distance[1] = 0;

            while (0 < queue.Count)
            {
                int from = queue.Dequeue();

                foreach (int to in G[from])
                {
                    if(distance[to] == -1)
                    {
                        distance[to] = distance[from] + 1;
                        queue.Enqueue(to);
                    }

                }
            }

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine(distance[i]);
            }

        }

    }
}
