namespace KyoproTessokuCsharp.chap05
{
    internal class B28
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();

            int fibonacciN = 1;
            int fibonacciN_1 = 1;
            int fibonacciN_2 = 1;

            for (int i = 1; i <= N-2; i++)
            {
                fibonacciN = fibonacciN_1 + fibonacciN_2;
                fibonacciN %= 1000000007;

                fibonacciN_2 = fibonacciN_1;
                fibonacciN_1 = fibonacciN;
            }

            Console.WriteLine(fibonacciN);
        }
    }
}
