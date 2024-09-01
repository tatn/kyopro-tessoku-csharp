namespace KyoproTessokuCsharp.chap08
{
    internal class A59
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
                int[] q = ReadIntArray();
                Query[i, 0] = q[0];
                Query[i, 1] = q[1];
                Query[i, 2] = q[2];
            }

            // 2^17 = 131072 ≒ 1.3 * 10^5
            // 2^16 = 65536 ≒  6.5 * 10^4

            int level = 1;
            int leafSize = 1;

            while (true)
            {
                if (N <= leafSize)
                {
                    break;
                }

                level++;
                leafSize *= 2;
            }

            int nodeSize = leafSize * 2;

            int[] node = new int[nodeSize];

            void UpdateNode(int pos, int x)
            {
                int nodeIndex = pos + leafSize - 1;
                node[nodeIndex] = x;

                while (2 <= nodeIndex)
                {
                    nodeIndex /= 2;

                    node[nodeIndex] = node[nodeIndex * 2] + node[nodeIndex * 2 + 1];
                }
            }

            int GetLevel(int nodeIndex)
            {
                if (nodeIndex == 1)
                {
                    return 1;
                }

                int l = 0;
                int size = 1;

                while (true)
                {
                    if (nodeIndex < size)
                    {
                        break;
                    }

                    size *= 2;
                    l++;
                }

                return l;
            }


            int GetSumValue(int l, int r, int nodeIndex)
            {
                int nodeLevel = GetLevel(nodeIndex);

                int leftPosition = (nodeIndex) * (1 << (level - nodeLevel)) - leafSize + 1;
                int rightPosition = leftPosition + (1 << (level - nodeLevel)) - 1;

                if (r < leftPosition || rightPosition < l)
                {
                    return 0;
                }

                if (l <= leftPosition && rightPosition <= r)
                {
                    return node[nodeIndex];
                }

                int leftValue = GetSumValue(l, r, nodeIndex * 2);
                int rightValue = GetSumValue(l, r, nodeIndex * 2 + 1);

                return leftValue + rightValue;
            }


            for (int i = 0; i < Q; i++)
            {
                switch (Query[i, 0])
                {
                    case 1:
                        UpdateNode(Query[i, 1], Query[i, 2]);
                        break;
                    case 2:
                        int v = GetSumValue(Query[i, 1], Query[i, 2] - 1, 1);
                        Console.WriteLine(v);
                        break;
                }
            }

        }
    }
}
