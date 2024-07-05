namespace KyoproTessokuCsharp.chap06
{
    internal class B38
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            string ReadString() => Console.ReadLine()!;

            int N = ReadInt();
            string S = ReadString();

            if(N == 1)
            {
                Console.WriteLine(1);
                return;
            }

            int[] heights = new int[N + 1];

            if (S[0] == 'A')
            {
                heights[1] = 1;
            }

            if (S[N-2] == 'B')
            {
                heights[N] = 1;
            }

            for (int i = 0; i <= N - 3 ; i++)
            {
                if (S[i] == 'B' && S[i+1] == 'A')
                {
                    heights [i+2] = 1;
                }
            }

            for (int i = 0; i <= N - 2; i++)
            {
                if (S[i] == 'A')
                {
                    heights[i + 2] = Math.Max(heights[i + 2], heights[i + 1] + 1);
                }
            }

            for (int i = N - 2; 0 <= i; i--)
            {
                if (S[i] == 'B')
                {
                    heights[i + 1] = Math.Max(heights[i + 1], heights[i + 2] + 1);
                }
            }

            Console.WriteLine(heights.Sum());


        }
    }
}
