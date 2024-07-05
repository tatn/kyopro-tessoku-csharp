namespace KyoproTessokuCsharp.chap06
{
    internal class B42
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            int N = ReadInt();

            long[] A = new long[N];
            long[] B = new long[N];

            for (int i = 0; i < N; i++)
            {
                long[] AB = ReadLongArray();
                A[i] = AB[0];
                B[i] = AB[1];
            }

            Func<bool,bool,long> getScore =  (isAPositive,isBPositive) =>  {

                long score = 0;

                for (int i = 0;i < N; i++)
                {
                    long a = A[i];
                    long b = B[i];

                    if (!isAPositive)
                    {
                        a = -a;
                    }

                    if (!isBPositive)
                    {
                        b = -b;
                    }

                    if(0 < a + b)
                    {
                        score += a + b;
                    }
                }

                return score;
            };

            long score_pp = getScore(true, true);
            long score_pn = getScore(true, false);
            long score_np = getScore(false, true);
            long score_nn = getScore(false, false);

            long score = score_pp;
            score = score < score_pn ? score_pn : score;
            score = score < score_np ? score_np : score;
            score = score < score_nn ? score_nn : score;

            Console.WriteLine(score);
        }
    }
}
