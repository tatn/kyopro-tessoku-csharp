namespace KyoproTessokuCsharp.chap04
{
    internal class A20
    {
        public static void Main(string[] args)
        {
            string ReadString() => Console.ReadLine()!;

            string S = ReadString();
            string T = ReadString();

            int sNumber = S.Length;
            int tNumber = T.Length;

            int[,] dp = new int[sNumber+1, tNumber+1];

            for (int i = 1; i <= sNumber; i++)
            {
                for (int j = 1; j <= tNumber; j++)
                {
                    if (S[i - 1] == T[j - 1])
                    {
                        dp[i, j] = Math.Max(Math.Max(dp[i - 1, j], dp[i, j - 1]), dp[i-1,j-1]+1);
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            Console.WriteLine(dp[sNumber,tNumber]);
        }
    }
}
