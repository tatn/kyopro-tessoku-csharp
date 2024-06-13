namespace KyoproTessokuCsharp.chap01
{
    internal class A05
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NK = ReadIntArray();
            int N = NK[0];
            int K = NK[1];

            int answer = 0;
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    int diff = K - i - j;

                    if (diff <= 0)
                    {
                        break;
                    }

                    if (1 <= diff && diff <= N)
                    {
                        answer++;
                    }
                }
            }

            Console.WriteLine(answer);
        }
    }
}
