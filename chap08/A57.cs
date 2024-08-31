namespace KyoproTessokuCsharp.chap08
{
    internal class A57
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NQ = ReadIntArray();
            int N = NQ[0];
            int Q = NQ[1];

            int[] A = ReadIntArray();

            int[] X= new int[Q];
            int[] Y= new int[Q];
            for (int i = 0; i < Q; i++)
            {
                int[] XY = ReadIntArray();
                X[i] = XY[0];
                Y[i] = XY[1];
            }

            // 2^30 = 1073741824  ≒ 1.0 * 10^9
            // 2^29 = 536870912  ≒ 5.3 * 10^8

            // dp[i,j] 穴jの位置にいる状態の2^i日後
            int[,] dp = new int[30, N + 1];

            for (int i = 0; i < N; i++)
            {
                dp[0, i + 1] = A[i];
            }

            for (int i = 1; i <= 29; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    dp[i, j] = dp[i - 1, dp[i - 1, j]];
                }
            }

            int[] answer = new int[Q];

            for (int i = 0; i < Q; i++)
            {
                int x = X[i];//穴
                int y = Y[i];//日数

                int hole = x;
                int calc = y;
                for (int j = 0; j <= 29; j++)
                {
                    if(calc == 0)
                    {
                        break;
                    }

                    if(calc % 2 == 1)
                    {
                        hole = dp[j, hole];
                    }

                    calc = calc / 2;

                    if(calc == 0)
                    {
                        break;
                    }

                }

                answer[i] = hole;
            }


            for (int i = 0; i < Q; i++)
            {
                Console.WriteLine(answer[i]);
            }


        }
    }
}
