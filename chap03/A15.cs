namespace KyoproTessokuCsharp.chap03
{
    internal class A15
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!.Trim());
            int[] ReadIntArray() => Console.ReadLine()!.Trim().Split().Select(int.Parse).ToArray();

            int N = ReadInt();
            int[] A = ReadIntArray();

            int[] ADistinct = A.Distinct().ToArray();
            int[] ASorted = ADistinct.OrderBy(x => x).ToArray();

            for (int i = 0; i < N; i++)
            {
                Console.Write(Array.BinarySearch(ASorted, A[i]) + 1);
                if(i < N - 1)
                {
                    Console.Write(' ');
                }
            }
        }
    }
}
