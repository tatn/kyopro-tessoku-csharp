namespace KyoproTessokuCsharp.chap01
{
    internal class A01
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();
            Console.WriteLine(N * N);
        }
    }
}
