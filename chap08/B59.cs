namespace KyoproTessokuCsharp.chap08
{
    internal class B59
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();
            int[] A = ReadIntArray();

            // 2^18 = 262144 ≒ 2.6 * 10^5
            // 2^17 = 131072 ≒ 1.3 * 10^5

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

            void UpdateNode(int pos)
            {
                int nodeIndex = pos + leafSize - 1;
                node[nodeIndex]++;

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

            long answer = 0L;
            for (int i = 0; i < N; i++)
            {
                int sum = GetSumValue(A[i]+1, leafSize,1);
                answer += (long)sum;

                UpdateNode(A[i]);


            }
            Console.WriteLine(answer);
        }


        public static void MainTLE(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();
            int[] A = ReadIntArray();

            // 2^18 = 262144 ≒ 2.6 * 10^5
            // 2^17 = 131072 ≒ 1.3 * 10^5

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

            int[] nodeMax = new int[nodeSize];
            int[] nodeMin = new int[nodeSize];

            void UpdateNode(int pos, int x)
            {
                int nodeIndex = pos + leafSize - 1;
                nodeMax[nodeIndex] = x;
                nodeMin[nodeIndex] = x;

                while (2 <= nodeIndex)
                {
                    nodeIndex /= 2;

                    nodeMax[nodeIndex] = Math.Max(nodeMax[nodeIndex * 2], nodeMax[nodeIndex * 2 + 1]);
                    nodeMin[nodeIndex] = Math.Min(nodeMin[nodeIndex * 2], nodeMin[nodeIndex * 2 + 1]);
                }
            }

            int[] levelMemo = new int[nodeSize];

            int GetLevel(int nodeIndex)
            {
                if (levelMemo[nodeIndex] != 0)
                {
                    return levelMemo[nodeIndex];
                }

                if (nodeIndex == 1)
                {
                    levelMemo[nodeIndex] = 1;
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

                levelMemo[nodeIndex] = l;
                return l;
            }

            int[] levelPositionLeftMemo = new int[nodeSize];
            int[] levelPositionRightMemo = new int[nodeSize];


            // pos : 配列Aの位置1～N
            // x  : 配列の値(A[pos-1])
            // nodeIndex : カウント対象のノードのインデックス
            int GetMoreValueCount(int pos, int x, int nodeIndex)
            {
                int nodeLevel = GetLevel(nodeIndex);

                if (levelPositionLeftMemo[nodeIndex] == 0)
                {
                    int leftPositionCalc = (nodeIndex) * (1 << (level - nodeLevel)) - leafSize + 1;
                    levelPositionLeftMemo[nodeIndex] = leftPositionCalc;
                }
                int leftPosition = levelPositionLeftMemo[nodeIndex];

                if (levelPositionRightMemo[nodeIndex] == 0)
                {
                    int rightPositionCalc = leftPosition + (1 << (level - nodeLevel)) - 1;
                    levelPositionRightMemo[nodeIndex] = rightPositionCalc;
                }

                int rightPosition = levelPositionRightMemo[nodeIndex];

                if (pos <= leftPosition)
                {
                    return 0;
                }

                if (nodeMax[nodeIndex] <= x)
                {
                    return 0;
                }

                if (x < nodeMin[nodeIndex])
                {
                    int countNode = (1 << (level - nodeLevel));

                    if (N < rightPosition)
                    {
                        countNode -= rightPosition - N;
                    }

                    return countNode;
                }

                int leftCount = GetMoreValueCount(pos, x, nodeIndex * 2);
                int rightCount = GetMoreValueCount(pos, x, nodeIndex * 2 + 1);

                return leftCount + rightCount;
            }


            for (int i = 0; i < N; i++)
            {
                UpdateNode(i + 1, A[i]);
            }

            long answer = 0L;
            for (int i = 0; i < N; i++)
            {
                int count = GetMoreValueCount(i + 1, A[i], 1);
                answer += (long)count;
            }

            Console.WriteLine(answer);
        }

    }
}
