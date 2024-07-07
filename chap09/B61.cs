using System.Linq;

namespace KyoproTessokuCsharp.chap09
{
    internal class B61
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

            List<List<int>> G = new List<List<int>>();
            for (int i = 0; i < N+1; i++)
            {
                G.Add(new List<int>());
            }

            for (int i = 0; i < M; i++)
            {
                G[A[i]].Add(B[i]);
                G[B[i]].Add(A[i]);
            }

            int index = 0;
            int size = 0;
            for (int i = 1; i <= N; i++)
            {
                if (size < G[i].Count)
                {
                    size = G[i].Count;
                    index = i;
                }
            }

            Console.WriteLine(index);

        }
    }
}
