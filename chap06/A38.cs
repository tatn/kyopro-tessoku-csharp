namespace KyoproTessokuCsharp.chap06
{
    internal class A38
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] DN = ReadIntArray();
            int D = DN[0];
            int N = DN[1];

            int[] L = new int[N + 1];
            int[] R = new int[N + 1];
            int[] H = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                int[] LRH = ReadIntArray();
                L[i] = LRH[0];
                R[i] = LRH[1];
                H[i] = LRH[2];
            }

            if(N == 0)
            {
                Console.WriteLine(D * 24);
                return;
            }

            int[,] NDMatrix = new int[N + 1+1,D+1];
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= D; j++)
                {
                    if (L[i]<=j && j <= R[i])
                    {
                        NDMatrix[i, j] = H[i];
                    }
                    else
                    {
                        NDMatrix[i, j] = 24;
                    }
                }
            }

            int[] answer = new int[D + 1];

            for (int i = 1; i <= D; i++)
            {
                answer[i] = NDMatrix[1, i];
                for (int j = 2; j <= N ; j++)
                {
                    answer[i] = Math.Min(answer[i], NDMatrix[j,i]);                    
                }
            }

            Console.WriteLine(answer.Sum());

        }
    }
}
