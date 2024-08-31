using System.Linq;

namespace KyoproTessokuCsharp.chap08
{
    internal class B56
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            string ReadString() => Console.ReadLine()!;


            int[] NQ = ReadIntArray();
            int N = NQ[0];
            int Q = NQ[1];

            string S = ReadString();
            string SReverse = string.Join("", S.Reverse());

            int[,] lr = new int[Q, 2];
            for (int i = 0; i < Q; i++)
            {
                int[] input = ReadIntArray();
                lr[i, 0] = input[0];
                lr[i, 1] = input[1];
            }

            long mode = Int32.MaxValue;
            long bValue = 100L;


            long[] T = new long[N + 1];
            long[] B = new long[N + 1];
            long[] H = new long[N + 1];
            long[] HReverse = new long[N + 1];

            for (int i = 1; i <= N; i++)
            {
                T[i] = (S[i - 1] - 'a') + 1;
                HReverse[i] = (SReverse[i - 1] - 'a') + 1;
            }

            B[0] = 1;
            H[0] = 0;
            HReverse[0] = 0;
            for (int i = 1; i <= N; i++)
            {
                B[i] = 100L * B[i - 1] % mode;
                H[i] = (bValue * H[i - 1] + T[i]) % mode;
                HReverse[i] = (bValue * HReverse[i - 1] + HReverse[i]) % mode;
            }

            long GetHash(int left, int right)
            {
                long hash = H[right] - (H[left - 1] * B[right - left + 1] % mode);
                hash += hash < 0 ? mode : 0;
                return hash;
            }
            long GetHashReverse(int leftInput, int rightInput, int N)
            {
                int left = N - rightInput + 1;
                int right = N -leftInput + 1;
                long hash = HReverse[right] - (HReverse[left - 1] * B[right - left + 1] % mode);
                hash += hash < 0 ? mode : 0;
                return hash;
            }

            for (int i = 0; i < Q; i++)
            {
                int length = (lr[i, 1] - lr[i, 0] + 2) / 2;
                long hash = GetHash(lr[i, 0], lr[i, 0] + length - 1);
                long hashReverse = GetHashReverse(lr[i, 1] - length+1, lr[i, 1], N);

                Console.WriteLine(hash == hashReverse ? "Yes" : "No");
            }
        }
    }
}
