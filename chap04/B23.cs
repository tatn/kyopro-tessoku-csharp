namespace KyoproTessokuCsharp.chap04
{
    internal class B23
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int[] NM = ReadIntArray();
            int N = NM[0];
            int M = NM[1];

            int[,] A = new int[M+1, N+1];


            // TODO
        }
    }
}
