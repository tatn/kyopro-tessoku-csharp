namespace KyoproTessokuCsharp.chap04
{
    internal class B20
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            string S = ReadString();
            string T = ReadString();

            int sNumber = S.Length;
            int tNumber = T.Length;

            int[,] dp = new int[tNumber + 1, sNumber + 1];

            for (int i = 0; i <= sNumber; i++)
            {
                dp[0, i] = i;
            }
            for (int i = 0; i <= tNumber; i++)
            {
                dp[i, 0] = i;
            }

            for (int i = 1; i <= tNumber; i++)
            {
                for (int j = 1; j <= sNumber; j++)
                {
                    if (S[j - 1] == T[i - 1])
                    {                        
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j]+1, dp[i, j - 1]+1), dp[i-1,j-1]);
                    }
                    else
                    {
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1]+1);
                    }
                }
            }

            Console.WriteLine(dp[tNumber, sNumber]);
        }
    }
}
