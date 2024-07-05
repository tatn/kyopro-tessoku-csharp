namespace KyoproTessokuCsharp.chap06
{
    internal class B40
    {
        public static void Main(string[] args)
        {
            int[] ReadIntArray() => Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int ReadInt() => int.Parse(Console.ReadLine()!);

            int N = ReadInt();
            int[] A = ReadIntArray();

            int[] countMod100 = new int[100];

            for (int i = 0; i < N; i++)
            {
                countMod100[A[i] % 100] += 1;
            }

            long answer = 0L;

            answer += ((long)countMod100[0]) * ((long)countMod100[0] - 1L) / 2L;
            answer += ((long)countMod100[50]) * ((long)countMod100[50] - 1L) / 2L;

            for (int i = 1; i <= 49; i++)
            {
                answer += ((long)countMod100[i]) * ((long)countMod100[100-i]);
            }

            Console.WriteLine(answer);
        }
    }
}
