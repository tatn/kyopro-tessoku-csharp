namespace KyoproTessokuCsharp.chap06
{
    internal class B45
    {
        public static void Main(string[] args)
        {
            long[] ReadLongArray() => Console.ReadLine()!.Split().Select(long.Parse).ToArray();

            long[] ABC = ReadLongArray();
            long a = ABC[0];
            long b = ABC[1];
            long c = ABC[2];

            Console.WriteLine( a + b + c  == 0L ? "Yes" : "No");
        }
    }
}
