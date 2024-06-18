namespace KyoproTessokuCsharp.chap05
{
    internal class B31
    {
        public static void Main(string[] args)
        {
            long ReadLong() => long.Parse(Console.ReadLine()!);
            long N = ReadLong();

            long N3 = N / 3L;
            long N5 = N / 5L;
            long N7 = N / 7L;

            long N15 = N / 15L;
            long N21 = N / 21L;
            long N35 = N / 35L;

            long N105 = N / 105L;

            long answer = N3 + N5 + N7  - N15 - N21 - N35 + N105;

            Console.WriteLine(answer);
        }
    }
}
