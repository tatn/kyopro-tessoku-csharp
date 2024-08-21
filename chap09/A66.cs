namespace KyoproTessokuCsharp.chap09
{
    internal class A66
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NQ = ReadIntArray();
            int N = NQ[0];
            int Q = NQ[1];

            int[,] Query = new int[Q, 3];

            for (int i = 0; i < Q; i++)
            {
                int[] qInput = ReadIntArray();
                Query[i, 0] = qInput[0];
                Query[i, 1] = qInput[1];
                Query[i, 2] = qInput[2];
            }

            int[] parent = new int[N + 1];
            int[] size = new int[N + 1];

            for (int i = 0; i <= N; i++)
            {
                size[i] = 1;
            }

            for (int i = 0; i < Q; i++)
            {
                int q = Query[i, 0];
                int u = Query[i, 1];
                int v = Query[i, 2];

                switch (q)
                {
                    case 1:
                        Unite(u, v);
                        break;
                    case 2:
                        Console.WriteLine(GetRoot(u) == GetRoot(v) ? "Yes" : "No");
                        break;
                }
            }


            int GetRoot(int x)
            {
                int p = parent[x];
                return p == 0 ? x : GetRoot(p);
            }
            ;

            void Unite(int u,int v)
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
