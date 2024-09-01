using System.ComponentModel;

namespace KyoproTessokuCsharp.chap09
{
    internal class B66
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[] A = new int[M];
            int[] B = new int[M];
            for (int i = 0; i < M; i++)
            {
                int[] ab = ReadIntArray();
                A[i] = ab[0];
                B[i] = ab[1];
            }

            int Q = ReadInt();

            int[,] Query = new int[Q, 3];
            bool[] cancelled = new bool[M];

            for (int i = 0; i < Q; i++)
            {
                int[] qInput = ReadIntArray();
                Query[i, 0] = qInput[0];
                Query[i, 1] = qInput[1];

                if(Query[i, 0] == 1)
                {
                    cancelled[Query[i,1]-1] = true;
                }
                else if (Query[i, 0] == 2)
                {
                    Query[i, 2] = qInput[2];
                }
            }

            int[] parent = new int[N + 1];
            int[] size = new int[N + 1];

            for (int i = 0; i <= N; i++)
            {
                size[i] = 1;
            }

            for (int i = 0; i < M; i++)
            {
                if (cancelled[i])
                {
                    continue;
                }

                Unite(A[i],B[i]);
            }

            List<string> answers = new List<string>();
            for (int i = Q - 1; 0 <= i; i--)
            {
                int q = Query[i, 0];

                switch (q)
                {
                    case 1:
                        int x = Query[i, 1];
                        Unite(A[x - 1], B[x - 1]);
                        break;
                    case 2:
                        int u = Query[i, 1];
                        int v = Query[i, 2];
                        answers.Add(GetRoot(u) == GetRoot(v) && GetRoot(u) != 0 ? "Yes" : "No");
                        break;
                }
            }

            answers.Reverse();
            foreach (string answer in answers)
            {
                Console.WriteLine(answer);
            }

            int GetRoot(int x)
            {
                int p = parent[x];
                return p == 0 ? x : GetRoot(p);
            }
            ;

            void Unite(int u, int v)
            {

                int rootU = GetRoot(u);
                int rootV = GetRoot(v);

                if (rootU == rootV)
                {
                    return;
                }

                int sizeU = size[rootU];
                int sizeV = size[rootV];

                if (sizeU < sizeV)
                {
                    parent[rootU] = rootV;
                    size[rootV] = sizeU + sizeV;
                }
                else
                {
                    parent[rootV] = rootU;
                    size[rootU] = sizeU + sizeV;
                }
            };


        }

    }
}
