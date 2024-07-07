namespace KyoproTessokuCsharp.chap09
{
    internal class B62
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

            List<int> path = new List<int>();
            bool[] visited = new bool[N+1];

            dfs(1,N,G,visited, path);
            if (0 < path.Count)
            {
                path.Add(1);
            }
            path.Reverse();

            Console.WriteLine(string.Join(" ", path));           
        }
        static bool dfs(int pos,int end, List<int>[] G, bool[] visited,List<int> path)
        {
            visited[pos] = true;

            if(pos == end)
            {
                return true;
            }

            for (int i = 0;i < G[pos].Count; i++)
            {
                int next = G[pos][i];
                if (!visited[next])
                {
                    bool result = dfs(next, end, G, visited, path);

                    if (result)
                    {
                        path.Add(next);
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
