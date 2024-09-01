namespace KyoproTessokuCsharp.chap10
{
    internal class C10
    {
        public static void Main(string[] args)
        {
            long ReadInt() => long.Parse(Console.ReadLine()!);

            long W = ReadInt();

            long mod = 1000000007L;

            long answer = 12L;
            long multiple = 7L;
            long workWidth = W-1;

            while (0 < workWidth)
            {
                if(workWidth % 2 == 1)
                {
                    answer *= multiple;
                    answer %= mod;
                }

                workWidth /= 2;
                multiple *= multiple;
                multiple %= mod;
            }

            Console.WriteLine(answer);
        }
    }
}
