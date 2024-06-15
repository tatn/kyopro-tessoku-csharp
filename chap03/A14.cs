namespace KyoproTessokuCsharp.chap03
{
    internal class A14
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] NK = ReadLongArray();
            long N = NK[0];
            long K = NK[1];

            long[] A = ReadLongArray();
            long[] B = ReadLongArray();
            long[] C = ReadLongArray();
            long[] D = ReadLongArray();

            long[] AB = new long[N*N];
            long[] CD = new long[N*N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    AB[N*i + j] = A[i]+B[j];                    
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    CD[N * i + j] = C[i] + D[j];
                }
            }
            CD = CD.OrderBy(x => x).ToArray();


            bool isOK = false;
            for(int i = 0;i < N*N; i++)
            {
                long diff = K - AB[i];

                int index = Array.BinarySearch(CD, diff);
                if(0 <= index)
                {
                    isOK = true;
                    break;
                }
            }

            Console.WriteLine(isOK ? "Yes" : "No");
        }
    }
}
