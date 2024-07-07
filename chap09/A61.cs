namespace KyoproTessokuCsharp.chap09
{
    internal class A61    
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

            for (int i = 1; i <=N; i++)
            {
                Console.WriteLine($"{i}: {{{String.Join(", ", G[i])}}}");
            }
        }
    }
}
