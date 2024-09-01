namespace KyoproTessokuCsharp.chap10
{
    internal class C20
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int ReadInt() => int.Parse(Console.ReadLine()!);

            Console.WriteLine();
        }
    }
}
