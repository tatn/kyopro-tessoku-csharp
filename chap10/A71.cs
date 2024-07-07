namespace KyoproTessokuCsharp.chap10
{
    internal class A71
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();
            int[] A = ReadIntArray();
            int[] B = ReadIntArray();

            List<int> ASorted = A.ToList();
            ASorted.Sort();

            List<int> BSorted = B.ToList();
            BSorted.Sort();
            BSorted.Reverse();

            int answer = ASorted.Select((a, index) => new { a, index }).Sum(x => x.a * BSorted[x.index]);

            Console.WriteLine(answer);
        }
    }
}
