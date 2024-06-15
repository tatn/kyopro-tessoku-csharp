namespace KyoproTessokuCsharp.chap03
{
    internal class A11
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NX = ReadIntArray();
            int N = NX[0];
            int X = NX[1];

            int[] A = ReadIntArray();

            int left = 0;
            int right = N - 1;

            int answer = -1;
            while (left <= right)
            {
                int m = (left + right) / 2;

                int a = A[m];

                if (a == X)
                {
                    answer = m;
                    break;
                }

                if (a < X)
                {
                    left = m + 1;
                }
                else
                {
                    right = m - 1;
                }
            }

            Console.WriteLine(answer + 1);
        }
    }
}
