namespace KyoproTessokuCsharp.chap04
{
    internal class A25
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            string ReadString() => Console.ReadLine()!;

            int[] HW = ReadIntArray();
            int H = HW[0];
            int W = HW[1];

            bool[,] isWhite = new bool[H + 2, W + 2];

            for (int i = 0; i < H; i++)
            {
                string line = ReadString();
                for (int j = 0; j < W; j++)
                {
                    isWhite[i + 1, j + 1] = line[j] == '.';
                }
            }

            long[,] dp = new long[H+2, W+2];            

            for (int i = 1; i <= H; i++)
            {
                for (int j = 1;j <= W; j++)
                {

                    if(i == 1 && j == 1)
                    {
                        dp[1, 1] = 1;
                    }
                    else
                    {

                        if (isWhite[i - 1, j])
                        {
                            dp[i, j] += dp[i - 1, j];
                        }
                        if (isWhite[i , j - 1])
                        {
                            dp[i, j] += dp[i, j - 1];
                        }
                    }
                }
            }

            Console.WriteLine(dp[H, W]);

        }
    }
}
