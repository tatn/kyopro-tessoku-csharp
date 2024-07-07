namespace KyoproTessokuCsharp.chap09
{
    internal class A62
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

            bool[] visited = new bool[N+1];

            dfs(1,G,visited);
            string answer = visited.Skip(1).Any(x => !x) ? "The graph is not connected." : "The graph is connected." ;
            Console.WriteLine(answer);            
        }
        static void dfs(int pos, List<int>[] G, bool[] visited)
        {
            visited[pos] = true;

            for (int i = 0;i < G[pos].Count; i++)
            {
                int next = G[pos][i];
                if (!visited[next])
                {
                    dfs(next,G,visited);
                }
            }
        }
    }
}
