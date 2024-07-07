namespace KyoproTessokuCsharp.chap10
{
    internal class A72
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            string ReadString() => Console.ReadLine()!;

            int[] HWK = ReadIntArray();
            int H = HWK[0];
            int W = HWK[1];
            int K = HWK[2];

            bool[,] tile = new bool[H, W];

            for (int i = 0; i < H; i++)
            {
                string line = ReadString();

                for (int j = 0; j < W; j++)
                {
                    tile[i, j] = line[j] == '#';
                }
            }

            int answer = 0;
            for (int i = 0; i < (1 << H); i++)
            {
                bool[,] workTile = new bool[tile.GetLength(0), tile.GetLength(1)];
                Array.Copy(tile, workTile, tile.Length);

                int rowPaintCount = 0;
                for (int h = 0; h < H; h++)
                {
                    bool isRowPaint = 0 < (i & (1 << h));

                    if (!isRowPaint)
                    {
                        continue;
                    }

                    rowPaintCount++;

                    for (int column = 0; column < W; column++)
                    {
                        workTile[h, column] = true;
                    }
                }

                int columPaintCount = K - rowPaintCount;

                if (columPaintCount < 0)
                {
                    continue;
                }

                ColumnPaint(workTile, H, W, columPaintCount);

                int blackCount = GetBlackCount(workTile, H, W);

                if(answer < blackCount)
                {
                    answer = blackCount;
                }

            }

            Console.WriteLine(answer);
        }

        public static void ColumnPaint(bool[,] tile, int H, int W, int columPaintCount)
        {
            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));

            for (int column = 0; column < W; column++)
            {
                int whiteCount = 0;
                for (int row = 0; row < H; row++)
                {
                    if (!tile[row, column])
                    {
                        whiteCount++;
                    }
                }
                priorityQueue.Enqueue(column, whiteCount);
            }

            for (int p = 0; p < columPaintCount; p++)
            {
                int paintColumn = priorityQueue.Dequeue();
                for (int row = 0; row < H; row++)
                {
                    tile[row, paintColumn] = true;
                }
            }
        }

        public static int GetBlackCount(bool[,] tile, int H, int W)
        {
            int blackCount = 0;
            for (int h = 0; h < H; h++)
            {
                for (int column = 0; column < W; column++)
                {
                    if (tile[h, column])
                    {
                        blackCount++;
                    }
                }

            }

            return blackCount;
        }

    }
}
