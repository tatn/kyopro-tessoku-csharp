namespace KyoproTessokuCsharp.chap06
{
    internal class A40
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();
            int[] A = ReadIntArray();

            int[] countBar = new int[101];

            for (int i = 0; i < N; i++)
            {
                countBar[A[i]] += 1;
            }

            long answer = 0L;
            for (int i = 1; i <= 100; i++)
            {
                answer += ((long)countBar[i]) * ((long)countBar[i] - 1L) * ((long)countBar[i] - 2L) / 6L;
            }


            Console.WriteLine(answer);
        }
    }
}
