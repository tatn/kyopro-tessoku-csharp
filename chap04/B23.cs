namespace KyoproTessokuCsharp.chap04
{
    internal class B23
    {
        public static void Main(string[] args)
        {
            int ReadInt() => int.Parse(Console.ReadLine()!);
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            int N = ReadInt();

            int[,] XY = new int[N, 2];

            for (int i = 0; i < N; i++)
            {
                int[] xy = ReadIntArray();
                XY[i, 0] = xy[0];
                XY[i, 1] = xy[1];
            }

            // TODO 5
        }
    }
}
