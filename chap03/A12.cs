namespace KyoproTessokuCsharp.chap03
{
    internal class A12
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] NK = ReadLongArray();
            long N = NK[0];
            long K = NK[1];

            long[] A = ReadLongArray();

            long left = 1;
            long right = 1_000_000_000;

            while (left < right)
            {
                long t = (left + right) / 2;

                long printNumber = 0;
                for (long i = 0; i < N; i++)
                {
                    printNumber += t / A[i];
                }

                if (printNumber < K)
                {
                    left = t + 1;
                }
                else if (K <= printNumber)
                {
                    right = t;
                }
            }

            Console.WriteLine(left);
        }
    }
}
