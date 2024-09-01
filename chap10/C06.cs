namespace KyoproTessokuCsharp.chap10
{
    internal class C06
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int N = ReadInt();

            Console.WriteLine(N);
            for (int i = 1; i <= N-1; i++)
            {
                Console.WriteLine($"{i} {i+1}");
            }
            Console.WriteLine($"{N} 1");

        }
    }
}
