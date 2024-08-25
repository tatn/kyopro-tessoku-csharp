namespace KyoproTessokuCsharp.chap04
{
    internal class B24
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] X = new int[N];
            int[] Y = new int[N];

            for (int i = 0; i < N; i++)
            {
                int[] XY = ReadIntArray();
                X[i] = XY[0];
                Y[i] = XY[1];
            }

            List<(int, int)> XYList = new List<(int, int)>();
            for (int i = 0; i < N; i++)
            {
                XYList.Add((X[i], Y[i]));
            }

            XYList.Sort((a, b) => a.Item1 == b.Item1 ? b.Item2 - a.Item2 : a.Item1 - b.Item1);

            int[] A = new int[N];
            for(int i = 0;i < N; i++)
            {
                A[i] = XYList[i].Item2;
            }

            int[] dp = new int[N + 1];
            List<int> minValues = new List<int>();

            for (int i = 0;i < N; i++)
            {
                int minValueIndex = minValues.BinarySearch(A[i]);

                if(minValueIndex < 0)
                {
                    minValueIndex = ~minValueIndex;

                    if(minValues.Count <= minValueIndex)
                    {
                        minValues.Add(A[i]);
                    }
                    else
                    {
                        minValues[minValueIndex] = A[i];
                    }
                }

                dp[i] = minValueIndex + 1;
            }

            Console.WriteLine(minValues.Count);
        }
    }
}
