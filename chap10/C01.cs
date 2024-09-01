namespace KyoproTessokuCsharp.chap10
{
    internal class C01
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int N = ReadInt();

            Console.WriteLine(N + N/10);
        }
    }
}
