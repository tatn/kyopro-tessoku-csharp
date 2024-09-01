namespace KyoproTessokuCsharp.chap10
{
    internal class C02
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = ReadIntArray();

            List<int> AList = A.ToList();
            AList.Sort();

            Console.WriteLine(AList[N - 1] + AList[N - 2]);
        }
    }
}
