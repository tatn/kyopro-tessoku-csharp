namespace KyoproTessokuCsharp.chap08
{
    internal class A56
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            string ReadString() => Console.ReadLine()!;


            int[] NQ = ReadIntArray();
            int N = NQ[0];
            int Q = NQ[1];

            string S = ReadString();

            int[,] abcd = new int[Q,4];
            for (int i = 0; i < Q; i++)
            {
                int[] input = ReadIntArray();
                abcd[i, 0] = input[0];
                abcd[i, 1] = input[1];
                abcd[i, 2] = input[2];
                abcd[i, 3] = input[3];
            }

            long mode = Int32.MaxValue;
            long bValue = 100L;


            long[] T = new long[N+1];
            long[] B = new long[N+1];
            long[] H = new long[N+1];

            for (int i = 1;i <= N; i++)
            {
                T[i] = (S[i-1] - 'a') + 1;
            }

            B[0] = 1;
            H[0] = 0;
            for (int i = 1; i <= N; i++)
            {
                B[i] = 100L * B[i - 1] % mode;
                H[i] = (bValue * H[i-1] + T[i]) % mode;
            }

            long GetHash(int left,int right)
            {
                long hash = H[right] - (H[left - 1] * B[right - left + 1] % mode);
                hash += hash < 0 ? mode : 0;
                return hash;
            }

            for (int i = 0; i < Q; i++)
            {
                long hashAB = GetHash(abcd[i, 0], abcd[i, 1]);
                long hashCD = GetHash(abcd[i, 2], abcd[i, 3]);

                Console.WriteLine( hashAB == hashCD ?  "Yes" : "No");
            }
        }
    }
}
