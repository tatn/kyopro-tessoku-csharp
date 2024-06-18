namespace KyoproTessokuCsharp.chap05
{
    internal class A31
    {
        public static void Main(string[] args)
        {
            long ReadLong() => long.Parse(Console.ReadLine()!);
            long N = ReadLong();

            long N3 = N / 3;
            long N5 = N / 5;
            long N15 = N / 15;

            long answer = N3 + N5 - N15;

            Console.WriteLine(answer);
        }
    }
}
