namespace KyoproTessokuCsharp.chap08
{
    internal class B57
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            // 2^30 = 1073741824  ≒ 1.0 * 10^9
            // 2^29 = 536870912  ≒ 5.3 * 10^8

            // dp[i,j] 整数jを2^i回操作後の値
            int[,] dp = new int[30, N + 1];

            int GetSubtracttedNumber(int n)
            {
                int diffNumber = 0;
                int calcNumber = n;

                while (0 < calcNumber)
                {
                    diffNumber += calcNumber % 10;
                    calcNumber /= 10;
                }

                return n - diffNumber;
            }

            for (int i = 1; i <= N; i++)
            {
                dp[0,i] = GetSubtracttedNumber(i);
            }

            for (int i = 1; i <= 29; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    dp[i, j] = dp[i - 1, dp[i - 1, j]];
                }
            }

            int[] answers = new int[N];
            for (int i = 1; i <= N; i++)
            {
                int answer = i;
                int devidedNumber = K;
                for (int j = 0; j <= 29; j++)
                {
                   if(devidedNumber % 2 == 1)
                    {
                        answer = dp[j, answer];
                    }

                    devidedNumber /= 2;

                    if(devidedNumber == 0)
                    {
                        break;
                    }
                }

                answers[i-1] = answer;
            }

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(answers[i]);
            }

        }
    }
}
