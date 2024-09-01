namespace KyoproTessokuCsharp.chap09
{
    internal class B67
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            List<(int, int, int)> ABC = new List<(int, int, int)>();

            for (int i = 0; i < M; i++)
            {
                int[] abc = ReadIntArray();
                ABC.Add((abc[0], abc[1], abc[2]));
            }

            ABC.Sort((x, y) => y.Item3 - x.Item3);

            int[] parent = new int[N + 1];
            int[] size = new int[N + 1];

            for (int i = 0; i <= N; i++)
            {
                size[i] = 1;
            }

            long answer = 0L;
            for (int i = 0; i < M; i++)
            {
                (int a, int b, int c) = ABC[i];

                if (GetRoot(a) == GetRoot(b) && GetRoot(a) != 0)
                {
                    continue;
                }

                Unite(a, b);
                answer += (long)c;

            }

            Console.WriteLine(answer);

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
