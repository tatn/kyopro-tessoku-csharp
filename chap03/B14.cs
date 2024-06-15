namespace KyoproTessokuCsharp.chap03
{
    internal class B14
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int[] A = ReadIntArray();

            if (N == 1)
            {
                Console.WriteLine(A[0] == K ? "Yes" : "No");
                return;
            }

            int[] aLeft = A.Take(N / 2).ToArray();
            int[] aRight = A.Skip(N / 2).ToArray();

            int aLeftCount = aLeft.Length;
            int aRightCount = aRight.Length;

            long[] aLeftSum = new long[1<<aLeftCount];
            long[] aRightSum = new long[1 << aRightCount];

            // 2^(2/N) <= 2^15 < 3.3 * 10^4
            for (int i = 0; i < 1 << aLeftCount; i++)
            {
                long sum = 0;
                for (int j = 0; j < aLeftCount; j++)
                {
                    if(0 < (i & 1 << j))
                    {
                        sum += (long)aLeft[j];
                    }
                }
                aLeftSum[i] = sum;
            }
            aLeftSum = aLeftSum.OrderBy(x => x).ToArray();

            // 2^(2/N) <= 2^15 < 3.3 * 10^4
            for (int i = 0; i < 1 << aRightCount; i++)
            {
                long sum = 0;
                for (int j = 0; j < aRightCount; j++)
                {
                    if (0 < (i & 1 << j))
                    {
                        sum += (long)aRight[j];
                    }
                }
                aRightSum[i] = sum;
            }
            aRightSum = aRightSum.OrderBy(x => x).ToArray();

            for (int i = 0; i < 1 << aRightCount; i++)
            {
                long diff = K - aLeftSum[i];

                int index = Array.BinarySearch(aRightSum, diff);

                if(0 < index)
                {
                    Console.WriteLine("Yes");
                    return;
                }

            }

            Console.WriteLine("No");
        }
    }
}
